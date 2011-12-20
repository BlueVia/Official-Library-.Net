// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.MMS.Schemas
{
    public enum DeliveryStatus
    {
        None,
        DeliveredToNetwork,
        DeliveryUncertain,
        DeliveryImpossible,
        MessageWaiting,
        DeliveredToTerminal,
        DeliveryNotificationNotSupported
    }
}
