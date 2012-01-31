// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     Class to contain the information of an Attachment 
    /// </summary>
    /// <remarks>   10/05/2011. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class FileAttachment
    {
        private string path;
        private string mime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Complete constructor 
        /// </summary>
        /// <remarks>   10/05/2011. </remarks>
        /// <param name="path">   the path to the file. </param>
        /// <param name="mime">   the mime type of the file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public FileAttachment(string path, string mime)
        {
            this.path = path;
            this.mime = mime;
        }

        public string Path() { return path;}
        public string Mime() { return mime; }
    }
}
