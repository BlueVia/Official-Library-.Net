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

using Bluevia.Messagery.MMS.Schemas;
using Bluevia.Messagery.MMS.Tools;

namespace Bluevia.Messagery.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MOMMSClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary> Set of functionality whose purpose is the reception of MMSs (MMS-MO) using polling.
    /// <a href="">BlueVia (MMS-MO) service.</a>
    /// It has also extra parsers and serializer, to properly switch between them and null, on each operation.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MOMMSClient : BV_MOClient
    {

        /// <summary>An XML serializer for: StartNotification.</summary>
        ISerializer xmlSerializer= null;

        /// <summary>A Multipart parser for: GetMessage.</summary>
        IParser multipartParser = null;

        /// <summary>An XML parser for: GetAllMessages.</summary>
        IParser xmlParser= null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Mobile Originated MMS functional block, to work 
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
        /// <summary>This Init function prepares the Mobile Originated MMS functional block, to work 
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
        ///     Poll for new messages received that fulfil the criteria identified by registrationId. The
        ///     application can get new messages of two ways, according to messageidentifier which is
        ///     returned in this operation. One way is when the application will invoke get Message and
        ///     the application will read the messages received. The other option will read the messages
        ///     received through of the operations get Messages URIs and get Attachement. 
        /// </summary>
        /// <remarks>   
        ///     10/05/2010. Each received message will be automatically removed from the
        ///     server after an agreed time interval, as defined by a service policy. 
        /// </remarks>
        /// <param name="registrationId"> Identifies the provisioning step that enables the application
        /// to receive notification of Message reception according to specified criteria. </param>
        /// <param name="attachUrl">Optional: The boolean parameter to retrieve the IDs of the attachments or not
        /// (false by default).</param>
        /// <returns>   
        ///     New list of received messages: i.e. only the received messages that the application has
        ///     not retrieved by previous invocations of this operation. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MMSMessageInfo[] GetAllMessages(string registrationId, bool attachUrl=false)
        {
            var parameters = CreateParameters();
            parameters.Add(Constants.attachmentUrlKey, attachUrl.ToString().ToLower());

            if (string.IsNullOrEmpty(registrationId))
            {
                throw new BlueviaException("Null or Empty registrationId when retrieving all MMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            string messageService = string.Format(Constants.MMSMessageMOGetMessages, registrationId);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = xmlParser;

            //The Bluevia´s complex response object, as result of the call:
            ReceivedMessagesType receivedMessagesType = BaseRetrieve<ReceivedMessagesType>(
                string.Format(url, messageService)
                , parameters);
            return MMSSimplifiers.SimplifyReceivedMessagesType(receivedMessagesType);
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This method will retrieve the whole message, and its attachments</summary>
        /// <param name="registrationId"> Identifier obtained in a provisioning step that enables the
        /// application to receive the inbound reception according to specified criteria. </param>
        /// <param name="messageId">It identifies the message which attachments belong to. </param>
        /// <returns>   
        ///     It returns the message root fields (e.g. origin, destination address, priority, etc.)
        ///     and its attachments. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MMSMessage GetMessage(string registrationId, string messageId)
        {
            if (string.IsNullOrEmpty(registrationId) || string.IsNullOrEmpty(messageId))
            {
                throw new BlueviaException("Null or Empty parameters when getting MMS."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = multipartParser;

            string messageService = string.Format(Constants.MMSMessageMOGetMessage, registrationId, messageId);

            //The Bluevia´s simple response object, as result of the call:
            var receivedMMS = BaseRetrieve<MMSMessage>(
                string.Format(url, messageService)
                , CreateParameters());

            return receivedMMS;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This method allows to retrieve a single multimedia attachment of the MMS. </summary>
        /// <param name="registrationId">Identifier obtained in a provisioning step that enables the
        /// application to receive the inbound reception according to specified criteria. </param>
        /// <param name="messageId"> Identifier for the message.</param>
        /// <param name="attachmentId">Identifier of the attachment, returned by the server, for a 
        /// certain inbound message.</param>
        /// <returns>The multimedia content, as a MIME body part in the HTTP response. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MIMEContent GetAttachment(string registrationId, string messageId, string attachmentId)
        {
            if (string.IsNullOrEmpty(registrationId) || string.IsNullOrEmpty(messageId) || string.IsNullOrEmpty(attachmentId))
            {
                throw new BlueviaException("Null or Empty parameters when getting an attachment."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = null; 
            
            string messageService = string.Format(Constants.MMSMessageMOGetAttachment, registrationId, messageId, attachmentId);
            //Call
            BaseRetrieve<string>(
                string.Format(url, messageService)
                , CreateParameters());

            string contentHeader;
            response.GetResponseHeaders().TryGetValue(HttpTools.ContetTypeKey, out contentHeader);
            string[] parts = contentHeader.Split(new Char[] { ';' });

            return new MIMEContent(parts[1], parts[0], response.GetResponseBody());
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Request to the application to start notifications for a given destination address and
        /// criteria.</summary>
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
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(endpoint) || criteria == null)
            {
                throw new BlueviaException("Null or Empty parameter when starting MMS notifications."
                        , ExceptionCode.InvalidArgumentException);
            }
            if (string.IsNullOrEmpty(correlator))
            {
                correlator = (criteria.Substring(0, 5) + Guid.NewGuid().ToString().Replace("-", "_")).Substring(0, 20);
            }
            long result = 0;
            bool isNumericDestination = long.TryParse(phoneNumber, out result);
            if (!isNumericDestination)
            {
                throw new BlueviaException("Invalid phoneNumber when starting MMS Notifications."
                        , ExceptionCode.InvalidArgumentException);
            }
            //Building the object wich will be serialized to serve as body
            MessageNotificationType messageNotificationType = new MessageNotificationType()
            {
                reference = new SimpleReferenceType() { correlator = correlator, endpoint = endpoint },
                destinationAddress = new MMS.Schemas.UserIdType[] { new MMS.Schemas.UserIdType() { Item = phoneNumber, ItemElementName = ItemChoiceType1.phoneNumber } },
                criteria = criteria
            };

            //Selecting the apropiate parser/serializer for the operation:
            serializer = xmlSerializer;
            parser = null;

            //Call
            BaseCreate<string, MessageNotificationType>(
                string.Format(url, Constants.MMSNotificationManagerSubscribeNotification)
                , CreateParameters()
                , messageNotificationType
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
                throw new BlueviaException("Null or Empty \"correlator\" parameter when stopping MMS notifications."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Selecting the apropiate parser/serializer for the operation:
            parser = null;

            string notificationService = string.Format(Constants.MMSNotificationManagerUnSubscribeNotification, correlator);
            
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
            url = string.Format(url, string.Format(Constants.apiMMS, sandboxString), Constants.MMSMessageMO);

            xmlSerializer = new BV_XMLSerializer();
            multipartParser = new MultipartParser();
            xmlParser = new XMLParser();
        }

    }
}
