// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AttachmentInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Representing  the attachment information retrieved when you use the getAllMessages function
    /// and the attachmentUrl parameter is set to true.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class AttachmentInfo
    {
        /// <value>The attachment uri/id, to retrieve it with GetAttachment function.</value>
        public string url;

        /// <value>The attachment MIMEType.</value>
        public string contentType;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="AttachmentInfo"/>.</summary>
        /// <param name="url">The attachment uri/id.</param>
        /// <param name="type">The attachment MIMEType.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public AttachmentInfo(string url, string type)
        {
            this.url = url;
            this.contentType = type;
        }
    }
}
