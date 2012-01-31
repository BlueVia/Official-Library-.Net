// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core;

namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client for SMS messages. </summary>
    /// <remarks>   03/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BlueviaClient : BaseClient, Bluevia.SMS.Client.IBlueviaClient
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager for notification. </summary>
        /// <value> The notification manager. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public INotificationManager NotificationManager { get { return new NotificationManager(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager for the reception of messages which source is the mobile. </summary>
        /// <value> The message mo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IMessageMO MessageMO { get { return new MessageMO(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager for the reception of messages which target is the mobile. </summary>
        /// <value> The message mt. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IMessageMT MessageMT { get { return new MessageMT(callBuilder); } }
    }
}
