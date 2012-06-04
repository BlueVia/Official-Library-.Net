// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MMSMessageInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class representing the MmsMessageInfo elements that will be received using the MMS Client API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MMSMessageInfo
    {
        /// <value>The message identifier to retrieve it with GetMessage function.</value>
        public string messageId;

        /// <value>The destination of the message.</value>
        public string destination;

        /// <value>The mms subject.</value>
        public string subject;

        /// <value>The sender address of the message (Token or phone number).</value>
        public string originAddress;

        /// <value>The date and time when the message was sent.</value>
        public string date;

        /// <value>An array containing all the attachment information.</value>
        public AttachmentInfo[] attachmentInfos;
    }
}
