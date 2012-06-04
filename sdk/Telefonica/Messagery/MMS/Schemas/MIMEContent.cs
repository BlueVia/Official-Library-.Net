// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MIMEContent.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class representing a Mime Content (an attachment) of a received MMS.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MIMEContent
    {
        /// /// <value>The content in byte array format.</value>
        public byte[] content;

        /// <value>The content type.</value>
        public string contentType;

        /// <value>The file name of the attachment.</value>
        public string name;

        /// <value>The attachment encoding.</value>
        public string encoding;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="MIMEContent"/>.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MIMEContent(){}

        /// <summary>Initializes a new instance of the <see cref="MIMEContent"/>, filling its fields.</summary>
        /// <param name="name">The file name of the attachment.</param>
        /// <param name="contentType">The content type.</param>
        /// <param name="content">The content in byte array format.</param>
        public MIMEContent(string name, string contentType, byte[] content)
        {
            this.name = name;
            this.contentType = contentType;
            this.content = content;
        }
    }
}
