using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Schemas
{
    
    /// <summary>
    /// 
    /// </summary>
    public class StreamAttachment
    {
        private System.IO.MemoryStream stream;
        private string mimeType;
        private string fileName;

        public StreamAttachment() { }
        
        public StreamAttachment(byte[] data, string mimeType, string fileName)
        {
            this.Data = new System.IO.MemoryStream(data);
            this.MimeType = mimeType;
            this.FileName = fileName;
        }

        public StreamAttachment(System.IO.MemoryStream data, string mimeType, string fileName)
        {
            this.Data = data;
            this.MimeType = mimeType;
            this.FileName = fileName;
        }

        public System.IO.Stream Data { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }

    }
}
