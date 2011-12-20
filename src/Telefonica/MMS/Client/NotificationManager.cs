// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Linq;
using Bluevia.Core;
using CoreSchemas = Bluevia.Core.Schemas;
using Bluevia.Core.Configuration;

namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     The multimedia message notification manager enables applications to set up and tear down
    ///     notifications for multimedia messages online. 
    /// </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class NotificationManager : BaseClient, Bluevia.MMS.Client.INotificationManager
    {
        public NotificationManager(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Request to the application to start notifications for a given destination address and
        ///     criteria. 
        /// </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="message">  The correlator provided in the reference must be unique for the
        ///                         application at the time the notification is initiated. If specified,
        ///                         criteria will be used to filter messages that are to be delivered to
        ///                         an application. If criteria are not provided, or are an empty string,
        ///                         then all messages for the Destination Address will be delivered to
        ///                         the application. </param>
        /// <returns>   Unique identifier associated to the subscription. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Subscribe(Schemas.MessageNotificationType message)
        {
            Uri subscription = null;
            callBuilder
                .SetBaseUri(UriManager.MMS_NotificationManager_SubscribeNotification)
                .SetMethod(CoreSchemas.WebMethod.Post)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetRequestContentAsType<Schemas.MessageNotificationType>(message)
                .AddAcceptableStatus(201)
                .SetCallback(resp => { subscription = resp.HeadersLocation(); })
                .Call();

            return subscription.Segments.Last();
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The application may end delivery receipt notification using this operation. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="notificationId">   Identifier for the notification. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UnSubscribeNotification(string notificationId)
        {
            callBuilder
                .SetBaseUri(string.Format(UriManager.MMS_NotificationManager_UnSubscribeNotification, notificationId))
                .SetMethod(CoreSchemas.WebMethod.Delete)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(204)
                .Call();
        }

    }
}
