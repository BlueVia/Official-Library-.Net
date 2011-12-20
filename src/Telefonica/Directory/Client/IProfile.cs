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
    ///     information about the profile of the user, such as whether the roaming is active, the SIM
    ///     type or the Operator giving service to the user. See Profile class for further information.
    /// </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IProfile
    {
        Bluevia.Directory.Schemas.UserProfileType Get();
        Bluevia.Directory.Schemas.UserProfileType Get(Bluevia.Directory.Schemas.ProfileFields fields);
    }
}
