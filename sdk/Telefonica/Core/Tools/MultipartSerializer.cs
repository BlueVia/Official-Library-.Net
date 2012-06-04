// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Bluevia.Messagery.MMS.Schemas;


namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MultipartSerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serialize a generic Multipart into a sendable byteArray.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MultipartSerializer : ISerializer
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform an AttachmentObject List,
        /// to MIME/Multipart in a single string.</summary>
        /// <remarks>   2012/03/05. </remarks>
        /// <typeparam name="T">The type of the Schemas."object".</typeparam>
        /// <param name="entity">The AttachmentObject list.</param>
        /// <returns> The serialized Multipart.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] Serialize<T>(T entity)
        {
            List<AttachmentObject> attachmentList = entity as List<AttachmentObject>;

            //Creating a temporal Boundary:
            string temporalBoundary = "--BLUEVIA's-DotNet-SDK-First-Boundary";
            bool boundaryNotValid = true;
            byte[] clrf = Encoding.Default.GetBytes("\r\n");
            string dispositionKey = "Content-Disposition: ";
            string typeKey = "Content-Type: ";
            string encodingKey = "Content-Transfer-Encoding: ";
            string lengthKey = "Content-Length: ";

            byte[] bytes = null;
            do
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    foreach (AttachmentObject attach in attachmentList)
                    {

                        //boundary+\r\n
                        bytes = Encoding.Default.GetBytes(temporalBoundary);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Write(clrf, 0, clrf.Length);

                        //*headers+\r\n
                        bytes = Encoding.Default.GetBytes(dispositionKey + attach.disposition);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Write(clrf, 0, clrf.Length);

                        bytes = Encoding.Default.GetBytes(typeKey + attach.type);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Write(clrf, 0, clrf.Length);

                        bytes = Encoding.Default.GetBytes(encodingKey + attach.encoding);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Write(clrf, 0, clrf.Length);

                        bytes = Encoding.Default.GetBytes(lengthKey + attach.content.Length);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Write(clrf, 0, clrf.Length);

                        //\r\n+content+\r\n
                        stream.Write(clrf, 0, clrf.Length);
                        stream.Write(attach.content, 0, attach.content.Length);
                        stream.Write(clrf, 0, clrf.Length);
                    }

                    //adding boundary+"--" to the message
                    bytes = Encoding.Default.GetBytes(temporalBoundary + "--");
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Write(clrf, 0, clrf.Length);

                    bytes = stream.ToArray();
                    //Converting the bytearray Multipart into string to search boundaries
                    string stringMultipart = Encoding.Default.GetString(bytes);

                    if (Tools.Extension.CountStringOccurrences(stringMultipart, temporalBoundary) > attachmentList.Count + 1)
                    {
                        temporalBoundary = temporalBoundary.Replace("First", Guid.NewGuid().ToString());
                    }
                    else
                    {
                        boundaryNotValid = false;
                    }
                }
            } while (boundaryNotValid);

            return bytes;
        }
    }
}
