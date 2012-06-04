// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

namespace Bluevia.Messagery.MMS.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MMSTools.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Additional static methods to serve to the API main classes.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class MMSTools
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Funtion to build a full MultipartMessageType, from simple fields.</summary>
        /// <param name="destinations">An array of phoneNumber destinations.</param>
        /// <param name="subject">The subject of the MMS.</param>
        /// <param name="originAddress">The sender address.</param>
        /// <param name="senderName">Optional: A sender name.</param>
        /// <param name="message">Optional: A text message that will be sent as a text attachment.</param>
        /// <param name="attachments">Optional: List of attachments to be sent.</param>
        /// <param name="endpoint">Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>A MultipartMessageType, ready to be serialized and sent.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Schemas.MultipartMessageType CreateMultipartMessageType(string[] destinations, string subject
            , MMS.Schemas.UserIdType originAddress
            , string senderName = null, string message = null, Schemas.Attachment[] attachments = null
            , string endpoint = null, string correlator = null)
        {

            Schemas.MultipartMessageType multipartMessage = new Schemas.MultipartMessageType();
            Schemas.MessageType messageType = new Schemas.MessageType();

            messageType.address = new Schemas.UserIdType[destinations.Length];
            for (int i = 0; i < destinations.Length; i++)
            {
                Core.Tools.Extension.checkIsNumber(destinations[i], "destination");
                messageType.address[i] = new Schemas.UserIdType() { Item = destinations[i]
                    , ItemElementName = Schemas.ItemChoiceType1.phoneNumber 
                };
            }

            messageType.originAddress =  originAddress;

            messageType.subject = subject;

            messageType.senderName = senderName;

            if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(correlator))//Both endpoint and correlator arent null nor empty
            {
                messageType.receiptRequest = new Schemas.SimpleReferenceType() { endpoint = endpoint, correlator = correlator };
            }

            multipartMessage.message = message;

            //Translating attachments to attachmentInfos
            Schemas.AttachmentInfo[] attachmentInfos = null;
            if (attachments == null)
            {
                attachmentInfos = new Schemas.AttachmentInfo[0];
            }
            else
            {
                attachmentInfos = new Schemas.AttachmentInfo[attachments.Length];
                for (var i = 0; i < attachments.Length; i++)
                {
                    if (attachments[i] != null)
                    {
                        attachmentInfos[i] = new Schemas.AttachmentInfo(
                            attachments[i].fileName, Tools.MMSTools.extractMIMEText(attachments[i].mimeType)
                            );
                    }
                }
            }
            multipartMessage.attachments = attachmentInfos;

            multipartMessage.messageType = messageType;

            return multipartMessage;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Class to change the MIMEType, for the apropiate mime text.</summary>
        /// <param name="mimeEnum">The selected MIMEType</param>
        /// <returns>The mime descriptive string.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string extractMIMEText(MIMEType mimeEnum)
        {
            switch (mimeEnum)
            {
                case MIMEType.amr:
                    return MMSContentTypes.amr;
                case MIMEType.avi:
                    return MMSContentTypes.avi;
                case MIMEType.bmp:
                    return MMSContentTypes.bmp;
                case MIMEType.gif:
                    return MMSContentTypes.gif;
                case MIMEType.jpeg:
                    return MMSContentTypes.jpeg;
                case MIMEType.midi:
                    return MMSContentTypes.midi;
                case MIMEType.mp3:
                    return MMSContentTypes.mp3;
                case MIMEType.mp4:
                    return MMSContentTypes.mp4;
                case MIMEType.mpeg:
                    return MMSContentTypes.mpeg;
                case MIMEType.png:
                    return MMSContentTypes.plain;
                case MIMEType.text:
                    return MMSContentTypes.plain;
                case MIMEType.v3gp:
                    return MMSContentTypes.v3gp;
                case MIMEType.wav:
                    return MMSContentTypes.wav;
                default:
                    return null;
            }
        }
    }
}
