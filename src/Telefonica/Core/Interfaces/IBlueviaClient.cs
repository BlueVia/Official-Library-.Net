// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client Interface. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IBlueviaClient
    {
        Bluevia.OAuth.Client.IBlueviaClient OAuth { get; }
        Bluevia.Directory.Client.IBlueviaClient Directory { get; }
        Bluevia.MMS.Client.IBlueviaClient MMS { get; }
        Bluevia.SMS.Client.IBlueviaClient SMS { get; }
        Bluevia.SGAP.Client.IBlueviaClient SGAP { get; }
        Bluevia.Location.Client.IBlueviaClient Location { get; }
        Bluevia.Payment.Client.IBlueviaClient Payment { get; }

        IBlueviaClient AuthenticateClient();
        IBlueviaClient CreateRequest();
    }
}
