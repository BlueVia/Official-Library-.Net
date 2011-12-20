// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Linq;
using Bluevia.Core;
using CoreSchemas = Bluevia.Core.Schemas;
using Conf = Bluevia.Core.Configuration;

namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This functional block covers the manage the notification functionality.
    /// </summary>
    /// <remarks>   19/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class NotificationManager : BaseClient, Bluevia.SMS.Client.INotificationManager
    {
        public NotificationManager(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Start notifications to the application for a given SMS Destination Address and criteria.
        ///     The correlator provided in the reference must be unique for the application Web Service
        ///     at the time the notification is initiated. If specified, criteria will be used to filter
        ///     messages that are to be delivered to an application. If criteria are not provided, or is
        ///     an empty string, then all messages for the Destination Address will be delivered to the
        ///     application.Note that the use of criteria will allow different notification endpoints to
        ///     receive notifications for the same Destination Address. The combination of Destination
        ///     Address and criteria must be unique, so that a notification will be delivered to only one
        ///     notification endpoint. 
        /// </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="message">  The notification message. </param>
        /// <returns>   It is a unique identifier associated to the resource that has been created. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Subscribe(Schemas.SMSNotificationType message)
        {
            Uri subscription = null;
            callBuilder
                .SetBaseUri(Conf.UriManager.SMS_NotificationManager_SubscribeNotification)
                .SetMethod(CoreSchemas.WebMethod.Post)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetRequestContentAsType<Schemas.SMSNotificationType>(message)
                .AddAcceptableStatus(201)
                .SetCallback(resp => { subscription = resp.HeadersLocation(); })
                .Call();

            return subscription.Segments.Last();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The application may end a short message notification using this operation. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="notificationId">   Correlator of request to end. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UnSubscribeNotification(string notificationId)
        {
            callBuilder
                .SetBaseUri(string.Format(Conf.UriManager.SMS_NotificationManager_UnSubscribeNotification, notificationId))
                .SetMethod(CoreSchemas.WebMethod.Delete)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(204)
                .Call();
        }
        
    }
}
