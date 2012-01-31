// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.SGAP.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client interface regarding SGAP (Advertising). </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IBlueviaClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Service to request advertising. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        IAdRequest AdRequest { get; }
    }
}
