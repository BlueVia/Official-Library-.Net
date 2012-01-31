using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This class defines the content-types allowed in MMS
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MMSContentTypes
    {
        public static readonly string plain = "text/plain;charset=UTF-8";
        public static readonly string jpeg = "image/jpeg";
        public static readonly string bmp = "image/bmp";
        public static readonly string gif = "image/gif";
        public static readonly string png = "image/png";
        public static readonly string amr = "audio/amr";
        public static readonly string midi = "audio/midi";
        public static readonly string mp3 = "audio/mp3";
        public static readonly string mpeg = "audio/mpeg";
        public static readonly string wav = "audio/wav";
        public static readonly string mp4 = "video/mp4";
        public static readonly string avi = "video/avi";
        public static readonly string v3gp ="video/3gpp";

    }
}
