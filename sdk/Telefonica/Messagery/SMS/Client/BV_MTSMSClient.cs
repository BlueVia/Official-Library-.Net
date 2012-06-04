// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Tools;
using Bluevia.Core.Schemas;
using Bluevia.Messagery.Schemas;
using Bluevia.Messagery.SMS.Schemas;
using Bluevia.Messagery.SMS.Tools;

namespace Bluevia.Messagery.SMS.Client
{
    public class BV_MTSMSClient : BV_MTClient
    {
        ISerializer xmlSerializer = null;
        IParser xmlParser = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Mobile Terminated SMS functional block, to work 
        /// as a trusted client. 
        /// It calls the base Init function, wich creates the SSL client's certificate, the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitTrusted(BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            base.InitTrusted(mode, consumer, consumerSecret, certPath, certPasswd);
            InitApiUrlAndObjects();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Mobile Terminated SMS functional block, to work 
        /// as an untrusted client. 
        /// It calls the base Init function, wich creates the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret
            , string token = "", string tokenSecret = "")
        {
            base.InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>SMS sending process.</summary>
        /// <param name="destination">The address of the recipient of the message.</param>
        /// <param name="text">The message text to send.</param>
        /// <param name="originAddress">The sender's phone Number</param>
        /// <param name="xChargedId">The phone number of the api payer. If not indicated, the payer will be the sender.</param>
        /// <param name="senderName">Human-readable text for remitent.</param>
        /// <param name="endpoint">String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the smsId of the SMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string SendProcess(string[] destination, string text, SMS.Schemas.UserIdType originAddress
            , string xChargedId, string senderName
            , string endpoint, string correlator)
        {
            SMSTextType smsTextType=null;
            SimpleReferenceType reference=null;
            if (destination == null || destination.Length <= 0)
            {
                throw new BlueviaException("Null destination when sending SMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new BlueviaException("Null or Empty text when sending MMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            if(!string.IsNullOrEmpty(endpoint)&&!string.IsNullOrEmpty(correlator))//Both endpoint and correlator arent null nor empty
            {
                reference= new SimpleReferenceType(){endpoint=endpoint,correlator=correlator};
            }
            else if(!(string.IsNullOrEmpty(endpoint)&&string.IsNullOrEmpty(correlator)))//One of enpoint or correlator is null or empty
            {
                throw new BlueviaException("Both endpoint and correlator parameters,are mandatory when sending message for status notifications."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Building the object wich will be serialized to serve as body
            smsTextType = SMSTools.CreateSMSTextType(text, originAddress, senderName, reference, destination);

            Dictionary<string,string> headers = CreateHeaders(HttpTools.ContetTypeXML);
            if(!string.IsNullOrEmpty(xChargedId))
            {
                headers.Add(Messagery.Constants.XChargedKey,xChargedId);
            }

            //Selecting the apropiate parser/serializer for the operation:
            serializer = xmlSerializer;
            parser = null;
         
            BaseCreate<string, SMSTextType>(
                string.Format(url, Constants.SMSMessageMT_Send)
                , CreateParameters()
                , smsTextType
                , headers);

            //As the usefull info of the response isnt in the body, 
            //lets look for it in the Location header of the response 
            string statusUrl = null;
            response.GetResponseHeaders().TryGetValue("Location", out statusUrl);
            string[] parts = statusUrl.Split(new Char[] { '/' });
            //And return only the statusId
            return parts[8];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows to know the delivery status of a previous sent message using Bluevia API</summary>
        /// <param name="messageId">The id of the message previously sent using this API.</param>
        /// <returns>An arrayList containing the DeliveryInfo for each destination address from the sent message.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DeliveryInfo[] GetDeliveryStatus(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new BlueviaException("Null or Empty messageId when retrieving SMS status."
                        , ExceptionCode.InvalidArgumentException);
            }


            string messageService = string.Format(Constants.SMSMessageMTGetStatus,messageId);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = xmlParser;

            SMSDeliveryStatusType smsDeliveryStatusType = BaseRetrieve<SMSDeliveryStatusType>(
                string.Format(url, messageService)
                , CreateParameters());

            return SMSSimplifiers.SimplifySMSDeliveryStatusType(smsDeliveryStatusType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            sandboxString = sandboxString.Replace("{0}", "");//As in MT, a different way of building the url is used
            url = string.Format(url, string.Format(Constants.apiSMS, sandboxString), Constants.SMSMessageMT);

            xmlSerializer = new XMLSerializer();
            xmlParser = new XMLParser();
        }

        
    }
}
