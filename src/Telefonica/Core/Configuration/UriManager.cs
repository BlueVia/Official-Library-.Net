// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace Bluevia.Core.Configuration
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Endpoint (URI) Manager. </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class UriManager
    {
        private const string REST = "/REST";
        private const string RPC = "/RPC";

        public static readonly string SMS_MessageMT_Send = "/outbound/requests";        
        public static readonly string SMS_MessageMT_GetStatus = "/outbound/requests/{0}/deliverystatus";
        public static readonly string SMS_MessageMO_GetMessages = "/inbound/{0}/messages";
        public static readonly string SMS_NotificationManager_SubscribeNotification = "/inbound/subscriptions";
        public static readonly string SMS_NotificationManager_UnSubscribeNotification = "/inbound/subscriptions/{0}";
        public static readonly string SMS_NotificationManager_UnSubscribeDelivery = "/outbound/subscriptions/{0}";
        public static readonly string OAuth_RequestToken_Get = "/Oauth/getRequestToken";
        public static readonly string OAuth_AccessToken_Get = "/Oauth/getAccessToken";
        public static readonly string SGAP_AdRequest_Send = "/simple/requests";
        public static readonly string MMS_MessageMO_GetMessages = "/inbound/{0}/messages";
        public static readonly string MMS_MessageMO_GetMessage = "/inbound/{0}/messages/{1}";
        public static readonly string MMS_MessageMO_GetAttachments = "/inbound/{0}/messages/{1}/attachments";
        public static readonly string MMS_MessageMO_GetAttachment = "/inbound/{0}/messages/{1}/attachments/{2}";
        public static readonly string MMS_MessageMT_Get = "/outbound/requests/{0}/deliverystatus";
        public static readonly string MMS_MessageMT_Send = "/outbound/requests";
        public static readonly string MMS_NotificationManager_UnSubscribeDelivery = "/outbound/subscriptions/{0}";
        public static readonly string MMS_NotificationManager_SubscribeNotification = "/inbound/subscriptions";
        public static readonly string MMS_NotificationManager_UnSubscribeNotification = "/inbound/subscriptions/{0}";
        public static readonly string Directory_AccessInfo_Get = "/{0}/UserInfo/UserAccessInfo";
        public static readonly string Directory_Profile_Get = "/{0}/UserInfo/UserProfile";
        public static readonly string Directory_TerminalInfo_Get = "/{0}/UserInfo/UserTerminalInfo";
        public static readonly string Location_Terminal_GetLocation = "/TerminalLocation";
        public static readonly string Payment_Payment = "/payment";
        public static readonly string Payment_CancelAuthorization = "/cancelAuthorization";
        public static readonly string Payment_GetPaymentStatus = "/getPaymentStatus";


        private const string Directory = "/Directory{0}";
        private const string MMS = "/MMS{0}";
        private const string GAP = "/Advertising{0}";
        private const string SMS = "/SMS{0}";
        private const string Location = "/Location{0}";
        private const string Payment = "/Payment{0}";



        /// <summary>
        /// URI's contained in this class are relative, so the host is added dynamically.
        /// The host is stored in the Client.cs
        /// </summary>
        /// 
        
        static UriManager()
        {
            UpdateFields();
        }

        public static void UpdateFields()
        {
            string host = Client.BlueviaHost;
            FieldInfo[] fields = typeof(UriManager).GetFields(BindingFlags.Public | BindingFlags.Static);
            int i = 0;
            foreach (var field in fields)
            {
                field.SetValue(null, host + getServiceType(field.Name) + getServiceUrl(field.Name) + returnValue(field.Name));
                i++;
            }
        }

        public static string returnValue(string value)
        {
            string result = string.Empty;
            switch (value)
            {
                case "SMS_MessageMT_Send":
                    result = "/outbound/requests";
                    break;
                case "SMS_MessageMT_GetStatus":
                    result = "/outbound/requests/{0}/deliverystatus";
                    break;
                case "SMS_MessageMO_GetMessages":
                    result = "/inbound/{0}/messages";
                    break;
                case "SMS_NotificationManager_SubscribeNotification":
                    result = "/inbound/subscriptions";
                    break;
                case "SMS_NotificationManager_UnSubscribeNotification":
                    result = "/inbound/subscriptions/{0}";
                    break;
                case "SMS_NotificationManager_UnSubscribeDelivery":
                    result = "/outbound/subscriptions/{0}";
                    break;
                case "OAuth_RequestToken_Get":
                    result = "/Oauth/getRequestToken";
                    break;
                case "OAuth_AccessToken_Get":
                    result = "/Oauth/getAccessToken";
                    break;
                case "SGAP_AdRequest_Send":
                    result = "/simple/requests";
                    break;
                case "MMS_MessageMO_GetMessages":
                    result = "/inbound/{0}/messages";
                    break;
                case "MMS_MessageMO_GetMessage":
                    result = "/inbound/{0}/messages/{1}";
                    break;
                case "MMS_MessageMO_GetAttachments":
                    result = "/inbound/{0}/messages/{1}/attachments";
                    break;
                case "MMS_MessageMO_GetAttachment":
                    result = "/inbound/{0}/messages/{1}/attachments/{2}";
                    break;
                case "MMS_MessageMT_Get":
                    result = "/outbound/requests/{0}/deliverystatus";
                    break;
                case "MMS_MessageMT_Send":
                    result = "/outbound/requests";
                    break;
                case "MMS_NotificationManager_UnSubscribeDelivery":
                    result = "/outbound/subscriptions/{0}";
                    break;
                case "MMS_NotificationManager_SubscribeNotification":
                    result = "/inbound/subscriptions";
                    break;
                case "MMS_NotificationManager_UnSubscribeNotification":
                    result = "/inbound/subscriptions/{0}";
                    break;
                case "Directory_AccessInfo_Get":
                    result = "/{0}/UserInfo/UserAccessInfo";
                    break;
                case "Directory_Profile_Get":
                    result = "/{0}/UserInfo/UserProfile";
                    break;
                case "Directory_TerminalInfo_Get":
                    result = "/{0}/UserInfo/UserTerminalInfo";
                    break;
                case "Location_Terminal_GetLocation":
                    result = "/TerminalLocation";
                    break;
                case "Payment_Payment":
                    result = "/payment";
                    break;
                case "Payment_CancelAuthorization":
                    result = "/cancelAuthorization";
                    break;
                case "Payment_GetPaymentStatus":
                    result = "/getPaymentStatus";
                    break;
            }
            return result;
        }
        

        private static string getServiceUrl (string servicePropertyName)
        {
            if (servicePropertyName.StartsWith("Directory", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(Directory, Client.Environment);
            else if (servicePropertyName.StartsWith("MMS", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(MMS, Client.Environment);
            else if (servicePropertyName.StartsWith("GAP", StringComparison.InvariantCultureIgnoreCase) || servicePropertyName.StartsWith("SGAP", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(GAP, Client.Environment);
            else if (servicePropertyName.StartsWith("SMS", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(SMS, Client.Environment);
            else if (servicePropertyName.StartsWith("Location", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(Location, Client.Environment);

            else if (servicePropertyName.StartsWith("Payment", StringComparison.InvariantCultureIgnoreCase))
                return string.Format(Payment, Client.Environment);


            else return string.Empty;
        }

        private static string getServiceType(string servicePropertyName)
        {
            if (servicePropertyName.StartsWith("Payment", StringComparison.InvariantCultureIgnoreCase))
                return RPC;
            else   
                return REST;
        }
    }
}
