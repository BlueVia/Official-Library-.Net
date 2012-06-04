// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Bluevia messagery constants, including the definition of Bluevia messagery common enumerators.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Constants
    {
        public static readonly string serviceMO = "{0}/inbound{1}";
        public static readonly string serviceMT = "{0}/outbound{1}";

        public static readonly string XChargedKey = "X-ChargedId";

    }
    /// <summary>The delivery status of the message.</summary>
    public enum DeliveryStatus
    {
        /// <summary>Default.</summary>
        None,
        /// <summary>The message has been delivered to the network. 
        /// Another state could be available later to inform if the message was finally delivered to the handset.</summary>
        DeliveredToNetwork,
        /// <summary>Delivery status unknown.</summary>
        DeliveryUncertain,
        /// <summary>Unsuccessful delivery; the message could not be delivered before it expired.</summary>
        DeliveryImpossible,
        /// <summary>The message is still queued for delivery. 
        /// This is a temporary state, pending transition to another state.</summary>
        MessageWaiting,
        /// <summary>The message has been successful delivered to the handset.</summary>
        DeliveredToTerminal,
        /// <summary>Unable to provide delivery status information because 
        /// it is not supported by the network.</summary>
        DeliveryNotificationNotSupported
    }
}
