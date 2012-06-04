// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Schemas;
using Bluevia.Core.Tools;

using Bluevia.Messagery.Schemas;
using Bluevia.Messagery.MMS.Schemas;
using Bluevia.Messagery.MMS.Tools;

namespace Bluevia.Messagery.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MTMMSClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary> Set of functionality whose purpose is the reception of MMSs (MMS-MT) using polling.
    /// And enabling applications to set up and tear down notifications for multimedia messages online.
    /// <a href="">BlueVia (MMS-MO) service.</a>
    /// It has also extra parsers and serializer, to properly switch between them and null on each operation.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MTMMSClient : BV_MTClient
    {
        /// <summary>A Multipart serializer for: Send.</summary>
        ISerializer multipartSerializer = null;

        /// <summary>An XML parser for: GetDeliveryStatus.</summary>
        IParser xmlParser = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Mobile Terminated MMS functional block, to work 
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
        /// <summary>This Init function prepares the Mobile Terminated MMS functional block, to work 
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
        /// <summary>MMS sending process.</summary>
        /// <param name="destination">An array of address of the recipient of the message.</param>
        /// <param name="subject">The subject of the mms to send.</param>
        /// <param name="originAddress">The sender's phone Number</param>
        /// <param name="xChargedId">The phone number of the api payer. If not indicated, the payer will be the sender.</param>
        /// <param name="senderName">Human-readable text for remitent.</param>
        /// <param name="message">A text message that will be sent as a text attachment.</param>
        /// <param name="attachments">List of attachments to be sent.</param>
        /// <param name="endpoint">String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the mmsId of the MMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string SendProcess(string[] destination, string subject, MMS.Schemas.UserIdType originAddress
            , string xChargedId, string senderName 
            , string message, Attachment[] attachments
            , string endpoint, string correlator)
        {
            MultipartMessageType multipartMessageType = null;

            if (destination == null || destination.Length <= 0)
            {
                throw new BlueviaException("Null or Empty destinations when sending MMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new BlueviaException("Null or Empty subject when sending MMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            if (!(string.IsNullOrEmpty(endpoint) && string.IsNullOrEmpty(correlator)))//One of enpoint or correlator is null or empty
            {
                throw new BlueviaException("Both endpoint and correlator parameters,are mandatory when sending message for status notifications."
                        , ExceptionCode.InvalidArgumentException);
            }
            
            //Building the object wich will be serialized to serve as body
            multipartMessageType = MMSTools.CreateMultipartMessageType(destination, subject, originAddress
                , senderName, message, attachments, endpoint, correlator);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = multipartSerializer;
            parser = null;

            
            BaseCreate<string, MultipartMessageType>(
                string.Format(url, Constants.MMSMessageMT_Send)
                , CreateParameters()
                , multipartMessageType
                , CreateHeaders(HttpTools.ContetTypeMultipart));

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

            string messageService = string.Format(Constants.MMSMessageMTGetStatus, messageId);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = xmlParser;

            //The Bluevia´s complex response object, as result of the call:
            MessageDeliveryStatusType smsDeliveryStatusType = BaseRetrieve<MessageDeliveryStatusType>(
                string.Format(url, messageService)
                , CreateParameters());

            return MMSSimplifiers.SimplifyMessageDeliveryStatusType(smsDeliveryStatusType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            sandboxString = sandboxString.Replace("{0}", "");//As in MT, a different way of building the url is used
            url = string.Format(url, string.Format(Constants.apiMMS, sandboxString), Constants.MMSMessageMT);

            multipartSerializer = new BV_MultipartSerializer();
            xmlParser = new XMLParser();
        }
    }
}
