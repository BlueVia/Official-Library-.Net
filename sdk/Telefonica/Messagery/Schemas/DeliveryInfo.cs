// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MOMMS.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to encapsulate the delivery status of a MMS message.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class DeliveryInfo
    {
        /// <value>The destination.</value>
        public string destination;

        /// <value>A simple status.</value>
        public DeliveryStatus status;

        /// <value>An extended status description.</value>
        public string statusDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Depending on the delivery status string, received for the SMS,
        /// this function creates a DeliveryStatus enum for the status property,
        /// and extends the description. To a comprehensive one</summary>
        /// <param name="statusString">The status received from the service.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetStatus(string statusString)
        {
            switch (statusString)
            {
                case "DeliveredToNetwork":
                    status = DeliveryStatus.DeliveredToNetwork;
                    statusDescription = "The message has been delivered to the network. Another state could be available later to inform if the message was finally delivered to the handset.";
                    break;
                case "DeliveredToTerminal":
                    status = DeliveryStatus.DeliveredToTerminal;
                    statusDescription = "The message has been successful delivered to the handset.";
                    break;
                case "DeliveryImpossible":
                    status = DeliveryStatus.DeliveryImpossible;
                    statusDescription = "Unsuccessful delivery; the message could not be delivered before it expired.";
                    break;
                case "DeliveryNotificationNotSupported":
                    status = DeliveryStatus.DeliveryNotificationNotSupported;
                    statusDescription = "Unable to provide delivery status information because it is not supported by the network.";
                    break;
                case "DeliveryUncertain":
                    status = DeliveryStatus.DeliveryUncertain;
                    statusDescription = "Delivery status unknown.";
                    break;
                case "MessageWaiting":
                    status = DeliveryStatus.MessageWaiting;
                    statusDescription = "The message is still queued for delivery. This is a temporary state, pending transition to another state.";
                    break;
                default:
                    status = DeliveryStatus.None;
                    statusDescription = "No status received.";
                    break;
            }
        }
    }
}
