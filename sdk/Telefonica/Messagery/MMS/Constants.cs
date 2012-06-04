// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.MMS
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Bluevia MMS constants, including the definition of Bluevia MMS enumerators.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Constants
    {
        public static readonly string apiMMS = "/REST/MMS{0}";

        public static readonly string MMSMessageMT = "{0}";
        public static readonly string MMSMessageMO = "{0}";
        public static readonly string MMSMessageMT_Send = "/requests";
        public static readonly string MMSMessageMTGetStatus = "/requests/{0}/deliverystatus";
        public static readonly string MMSMessageMOGetMessages = "/{0}/messages";
        public static readonly string MMSMessageMOGetMessage = "/{0}/messages/{1}";
        public static readonly string MMSMessageMOGetAttachment = "/{0}/messages/{1}/attachments/{2}";
        public static readonly string MMSNotificationManagerSubscribeNotification = "/subscriptions";
        public static readonly string MMSNotificationManagerUnSubscribeNotification = "/subscriptions/{0}";

        public static readonly string attachmentUrlKey = "useAttachmentURLs";
    }

    /// <summary>The Bluevia supported <a href="http://www.iana.org/assignments/media-types/index.html">mime types</a>.</summary>
    public enum MIMEType
    {
        /// <summary>Type text/plain.</summary>
        text = 0,
        /// <summary>Type image/jpeg.</summary>
        jpeg = 1,
        /// <summary>Type image/bmp.</summary>
        bmp = 2,
        /// <summary>Type image/gif.</summary>
        gif = 3,
        /// <summary>Type image/png.</summary>
        png =4,
        /// <summary>Type audio/amr.</summary>
        amr = 5,
        /// <summary>Type audio/midi.</summary>
        midi = 6,
        /// <summary>Type audio/mp3.</summary>
        mp3 = 7,
        /// <summary>Type audio/mpeg.</summary>
        mpeg = 8,
        /// <summary>Type audio/wav.</summary>
        wav = 9,
        /// <summary>Type video/mp4.</summary>
        mp4 = 10,
        /// <summary>Type video/avi.</summary>
        avi = 11,
        /// <summary>Type video/3gpp.</summary>
        v3gp = 12,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>This class defines the content-types allowed in MMS</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class MMSContentTypes
    {
        public static readonly string app = "application/xml;charset=UTF-8";
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
        public static readonly string v3gp = "video/3gpp";
    }
}
