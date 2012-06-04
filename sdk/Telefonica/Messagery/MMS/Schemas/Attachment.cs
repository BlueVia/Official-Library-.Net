using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Attachment.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>A class to hold the info of an attachment from your file system.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Attachment
    {
        /// <value>The attachment MIMEType.</value>
        public MIMEType mimeType;

        /// <summary>The attachment path.</summary>
        public string fileName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="Attachment"/>.</summary>
        /// <param name="filePath">The attachment path.</param>
        /// <param name="mime">The attachment MIMEType.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Attachment(string filePath, MIMEType mime)
        {
            mimeType = mime;
            fileName = filePath;
        }

    }
}
