// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.SGAP.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to the reception of Avertisings.
    ///     See AdRequest class for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IAdRequest
    {
        Bluevia.SGAP.Schemas.SimpleAdResponse Send(Bluevia.SGAP.Schemas.SimpleAdRequest adrequest);
        Bluevia.SGAP.Schemas.SimpleAdResponse Send(Bluevia.SGAP.Schemas.SimpleAdRequest adrequest, bool twoLegged);
    }
}
