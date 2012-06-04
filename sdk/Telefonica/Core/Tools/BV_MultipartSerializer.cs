// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 
using System.Text;
using System.Collections.Generic;

using Bluevia.Messagery.MMS.Schemas;

namespace Bluevia.Core.Tools
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MultipartSerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serialize a MultipartMessageType into a sendable byteArray.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MultipartSerializer : ISerializer
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform a full builded object from the Bluevia Schemas,
        /// to a MIME/Multipart in a single byte array. By converting the Bluevia MMSMultipartType message and attachments,
        /// To a single System.Net.Mail.Attachment List, and serializting it with MultipartSerializer.Serialize().</summary>
        /// <typeparam name="T">The type of the Schemas."object".</typeparam>
        /// <param name="entity">The MultipartMessageType to be serialized.</param>
        /// <returns> The serialized Multipart.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] Serialize<T>(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            MultipartMessageType multipart = entity as MultipartMessageType;
            List<AttachmentObject> attachmentList = new List<AttachmentObject>();
            AttachmentObject tempAttachment;

            //First, serializing the message object into a string, and setting it as the first attachment
            tempAttachment =new AttachmentObject(
                Encoding.UTF8.GetString(new BV_XMLSerializer().Serialize(multipart.messageType)),
                false,
                "form-data; name=\"root-fields\"",
                Messagery.MMS.MMSContentTypes.app,
                "binary"
            );
            attachmentList.Add(tempAttachment);

            //In case the message field is filled, must be sent as a text attachment
            if(!string.IsNullOrEmpty(multipart.message))
            {
                tempAttachment = new AttachmentObject(
                    multipart.message,
                    false,
                    "form-data; name=\"attachments\"; filename=\"message.txt\"",
                    Messagery.MMS.MMSContentTypes.plain,
                    "binary"
                ); 
                attachmentList.Add(tempAttachment);
            }

            //Once the mandatory and optional message attachments are setted, the rest of the attachments must be buildt.
            foreach (var attach in multipart.attachments)
            {
                tempAttachment = new AttachmentObject(
                    attach.url,
                    true,
                    "form-data; name=\"attachments\"; filename=\""+ System.IO.Path.GetFileName(attach.url) + "\"",
                    attach.contentType,
                    "binary"
                ); 
                attachmentList.Add(tempAttachment);
            }

            MultipartSerializer multipartSerializer = new MultipartSerializer();

            return multipartSerializer.Serialize(attachmentList);
        }
    }
}
