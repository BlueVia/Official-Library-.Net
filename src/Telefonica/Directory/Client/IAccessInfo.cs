// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines information about the network where the user is connected, 
    ///     such as the IP address, or if she is accessing by GPRS, UMTS, etc . 
    ///     See AccessInfo class for further information.
    /// </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IAccessInfo
    {       
        global::Bluevia.Directory.Schemas.UserAccessInfoType Get();
        global::Bluevia.Directory.Schemas.UserAccessInfoType Get(global::Bluevia.Directory.Schemas.AccessInfoFields fields);
    }
}
