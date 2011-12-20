// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client interface regarding OAuth operations. </summary>
    /// <remarks>   05/09/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IBlueviaClient
    {
        IAccessToken AccessToken { get; }
        IRequestToken RequestToken { get; }
    }
}
