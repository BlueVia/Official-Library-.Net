// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.SMS
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Bluevia SMS constants.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Constants
    {
        public static readonly string apiSMS = "/REST/SMS{0}";

        public static readonly string SMSMessageMT = "{0}";
        public static readonly string SMSMessageMO = "{0}";
        public static readonly string SMSMessageMT_Send = "/requests";
        public static readonly string SMSMessageMTGetStatus = "/requests/{0}/deliverystatus";
        public static readonly string SMSMessageMOGetMessages = "/{0}/messages";
        public static readonly string SMSNotificationManagerSubscribeNotification = "/subscriptions";
        public static readonly string SMSNotificationManagerUnSubscribeNotification = "/subscriptions/{0}"; 
    }
}
