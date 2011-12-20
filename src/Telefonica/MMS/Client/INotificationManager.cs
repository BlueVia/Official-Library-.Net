// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations that covers the notifications managing. 
    ///     See NotificationManager class for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface INotificationManager
    {
        string Subscribe(Bluevia.MMS.Schemas.MessageNotificationType message);
        void UnSubscribeNotification(string notificationId);
    }
}
