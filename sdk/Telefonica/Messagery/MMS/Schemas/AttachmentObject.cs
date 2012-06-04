// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;
using System.IO;

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AttachmentObject.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serve as container of an attachment, storing it's data and metadata. 
    /// To further use it in a multipart object.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class AttachmentObject
    {
        /// <value>The content in byte array format.</value>
        public byte[] content;

        /// <value>The disposition in a multipart object.</value>
        public string disposition;

        /// <value>The content type.</value>
        public string type;

        /// <value>The content encoding.</value>
        public string encoding;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="AttachmentObject"/>.</summary>
        /// <param name="content">The attachment content. A filePath pointer, or a text.</param>
        /// <param name="isPath">A field to treat the content parameter as a filePath or as a text.</param>
        /// <param name="disposition">The disposition of the attachment in the multipart object.</param>
        /// <param name="type">The content type.</param>
        /// <param name="encoding">The content encoding.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public AttachmentObject(string content, bool isPath, string disposition, string type, string encoding)
        {
            if (isPath)//the content must be extracted from a file
            {
                if (type == Messagery.MMS.MMSContentTypes.plain)//Lets care the encoding if the attachment is a text
                {
                    this.content = Encoding.UTF8.GetBytes(File.ReadAllText(content, Encoding.Default));

                }
                else
                {
                    this.content = File.ReadAllBytes(content);
                }
            }
            else
            {
                this.content = Encoding.UTF8.GetBytes(content);
            }
            this.disposition = disposition;
            this.type = type;
            this.encoding = encoding;
        }
    }
}
