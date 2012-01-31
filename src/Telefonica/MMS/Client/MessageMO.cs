// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Text;
using Bluevia.Core;
using Bluevia.Core.Schemas;
using Bluevia.Core.Configuration;


namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     Set of functionality whose purpose is the reception of MMSs (MMS-MO) using polling. 
    /// </summary>
    /// <remarks>   10/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MessageMO : BaseClient, Bluevia.MMS.Client.IMessageMO
    {
        public MessageMO (IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Poll for new messages received that fulfil the criteria identified by RegistrationId. The
        ///     application can get new messages of two ways, according to messageidentifier which is
        ///     returned in this operation. One way is when the application will invoke get Message and
        ///     the application will read the messages received. The other option will read the messages
        ///     received through of the operations get Messages URIs and get Attachement. 
        /// </summary>
        /// <remarks>   
        ///     10/05/2010. Each received message will be automatically removed from the
        ///     server after an agreed time interval, as defined by a service policy. 
        /// </remarks>
        /// <param name="registrationId">   Identifies the provisioning step that enables the application
        ///                                 to receive notification of Message reception according to
        ///                                 specified criteria. </param>
        /// <returns>   
        ///     New list of received messages: i.e. only the received messages that the application has
        ///     not retrieved by previous invocations of this operation. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.ReceivedMessagesType GetMessages(string registrationId, bool useAttachmentUrl)
        {
            Schemas.ReceivedMessagesType receivedMessages = null;
            callBuilder
                .EnableTwoLeggedAuth()
                .SetBaseUri(string.Format(UriManager.MMS_MessageMO_GetMessages, registrationId))
                .AddQueryString(Bluevia.Core.Schemas.QueryString.currentVersion);
            if (useAttachmentUrl)
            {
                callBuilder.AddQueryString(Bluevia.MMS.Schemas.QueryString.useAttachmentURL);
            }
            else
            {
                callBuilder.AddQueryString(Bluevia.MMS.Schemas.QueryString.dontUseAttachmentURL);
            }

            callBuilder
                .SetMethod(Bluevia.Core.Schemas.WebMethod.Get)
                .AddAcceptableStatus(200, 204)
                .SetCallback(resp => { if ((int)resp.Status == 200) receivedMessages = resp.ParseXml<Schemas.ReceivedMessagesType>(); })
                .Call();

            return receivedMessages;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This method will read the whole message. identifier of the received message. </summary>
        /// <remarks>   10/05/2010. </remarks>
        /// <param name="registrationId">   Identifier obtained in a provisioning step that enables the
        ///                                 application to receive the inbound reception according to
        ///                                 specified criteria. </param>
        /// <param name="messageId">        It identifies the message which attachments belong to. </param>
        /// <returns>   
        ///     It returns the message root fields (e.g. origin, destination address, priority, etc.)
        ///     plus the attachments. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MMS.Schemas.ReceivedMMS GetMessage(string registrationId, string messageId)
        {
            MMS.Schemas.ReceivedMMS message = null;
            callBuilder
                .EnableTwoLeggedAuth()
                .SetBaseUri(string.Format(UriManager.MMS_MessageMO_GetMessage, registrationId, messageId))
                .AddQueryString(Bluevia.Core.Schemas.QueryString.currentVersion)
                .SetMethod(Bluevia.Core.Schemas.WebMethod.Get)
                .AddAcceptableStatus(200)
                .SetCallback(resp =>
                {
                    string boundary = resp.ContentType.Boundary;
                    string text = Bluevia.Core.Extension.WebResponseToString(resp.ResponseStream);
                    
                    message = new Schemas.ReceivedMMS(
                        //the complete message
                        text,
                        //the boundary
                        boundary
                    );
                })
                .Call();
            return message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This method allows to retrieve and individual multimedia attachment of the MMS. </summary>
        /// <remarks>   10/05/2010. </remarks>
        /// <param name="registrationId">   Identifier obtained in a provisioning step that enables the
        ///                                 application to receive the inbound reception according to
        ///                                 specified criteria.. </param>
        /// <param name="messageId">        Identifier for the message. </param>
        /// <param name="attachmentId">     Identifier of the attachment, returned by the server, for a
        ///                                 certain inbound message.. </param>
        /// <returns>   The multimedia content, as a MIME body part in the HTTP response. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Core.Schemas.MIMEContent GetAttachment(string registrationId, string messageId, string attachmentId)
        {
            Core.Schemas.MIMEContent response = new Core.Schemas.MIMEContent();

            callBuilder
                .EnableTwoLeggedAuth()
                .SetBaseUri(string.Format(UriManager.MMS_MessageMO_GetAttachment, registrationId, messageId, attachmentId))
                .AddQueryString(Bluevia.Core.Schemas.QueryString.currentVersion)
                .SetMethod(Bluevia.Core.Schemas.WebMethod.Get)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { response = resp.ParseAttachment(); })
                .Call();

            return response;
        }
    }
}
