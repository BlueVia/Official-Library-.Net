// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Tools;
using Bluevia.Core.Schemas;
using Bluevia.Messagery.SMS.Schemas;
using Bluevia.Messagery.SMS.Tools;

namespace Bluevia.Messagery.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MOSMSClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary> Set of functionality whose purpose is the reception of SMSs (SMS-MO) using polling.
    /// <a href="">BlueVia (SMS-MO) service.</a>
    /// It has also an extra parser, to properly switch betwenn it and null on each operation.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MOSMSClient : BV_MOClient
    {
        /// <summary>An XML parser for: GetAllMessages.</summary>
        IParser xmlParser = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Mobile Originated SMS functional block, to work 
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
        /// <summary>This Init function prepares the Mobile Originated SMS functional block, to work 
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
        /// <summary>   
        ///     Poll for new messages received that fulfil the criteria identified by registrationId.
        /// </summary>
        /// <remarks>   
        ///     10/05/2010. Each received message will be automatically removed from the
        ///     server after an agreed time interval, as defined by a service policy. 
        /// </remarks>
        /// <param name="registrationId"> Identifies the provisioning step that enables the application
        /// to receive notification of Message reception according to specified criteria. </param>
        /// <returns>   
        ///     New list of received messages: i.e. only the received messages that the application has
        ///     not retrieved by previous invocations of this operation. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SMSMessage[] GetAllMessages(string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new BlueviaException("Null or Empty registrationId when retrieving all SMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            string messageService = string.Format(Constants.SMSMessageMOGetMessages, registrationId);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = xmlParser;

            //The Bluevia´s simple response object, as result of the call:
            ReceivedSMSType receivedSMSType = BaseRetrieve<ReceivedSMSType>(
                string.Format(url, messageService)
                , CreateParameters());

            return SMSSimplifiers.SimplifyReceivedSMSType(receivedSMSType); ;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Request to the application to start notifications for a given destination address and
        ///     criteria. 
        /// </summary>
        /// <param name="phoneNumber">the Destination Address wich messages will be, 
        /// delivered to the application</param>
        /// <param name="endpoint"> The url of the notification server.</param>
        /// <param name="criteria">Criteria will be used to filter messages 
        /// that are to be delivered to an application. If criteria is not provided,
        /// or are an empty string, then all messages for the Destination Address will be 
        /// delivered to the application.</param>
        /// <param name="correlator"> Optional: The correlator provided in the reference 
        /// must be unique for the application at the time the notification is initiated.</param>
        /// <returns>Unique identifier associated to the subscription.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string StartNotification(string phoneNumber, string endpoint, string criteria, string correlator = null)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(criteria))
            {
                throw new BlueviaException("Null or Empty parameter when starting SMS notifications."
                        , ExceptionCode.InvalidArgumentException);
            }
            if(string.IsNullOrEmpty(correlator))
            {
                correlator = (criteria.Substring(0, 5) + Guid.NewGuid().ToString().Replace("-", "_")).Substring(0, 20);
            }
            long result = 0;
            bool isNumericDestination =  long.TryParse(phoneNumber, out result);
            if (!isNumericDestination)
            {
                throw new BlueviaException("Invalid phoneNumber when starting SMS Notifications."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Building the object wich will be serialized to serve as body
            SMSNotificationType smsNotificationType = new SMSNotificationType()
            {
                reference = new SimpleReferenceType() { correlator = correlator, endpoint = endpoint },
                destinationAddress = new SMS.Schemas.UserIdType[] { new SMS.Schemas.UserIdType() { Item = phoneNumber, ItemElementName = ItemChoiceType1.phoneNumber } },
                criteria = criteria
            };

            //Selecting the apropiate parser/serializer for the operation:
            parser = null;

            BaseCreate<string, SMSNotificationType>(
                string.Format(url, Constants.SMSNotificationManagerSubscribeNotification)
                , CreateParameters()
                , smsNotificationType
                , CreateHeaders(HttpTools.ContetTypeXML));

            return correlator;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The application may end delivery receipt notification using this operation. </summary>
        /// <param name="correlator">Identifier for the notification. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool StopNotification(string correlator)
        {
            if (string.IsNullOrEmpty(correlator))
            {
                throw new BlueviaException("Null or Empty \"correlator\" parameter when stopping SMS notifications."
                        , ExceptionCode.InvalidArgumentException);
            }

            string notificationService = string.Format(Constants.SMSNotificationManagerUnSubscribeNotification, correlator);

            //Selecting the apropiate parser/serializer for the operation:
            parser = null;

            BaseDelete<string>(
                string.Format(url, notificationService)
                , CreateParameters());

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            sandboxString = sandboxString.Replace("{0}", "");//As in MO, a different way of building the url is used
            url = string.Format(url, string.Format(Constants.apiSMS, sandboxString), Constants.SMSMessageMO);

            serializer = new XMLSerializer();
            xmlParser = new XMLParser();
        }
    }
}
