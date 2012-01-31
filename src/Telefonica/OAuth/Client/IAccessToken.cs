// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to get the Access Token. 
    ///     See AccessToken class for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IAccessToken
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Access Token. </summary>
        ///
        /// <remarks>   05/09/2010. </remarks>
        ///
        /// <param name="request">          The request token. </param>
        /// <param name="verificationCode"> The verification code. </param>
        ///
        /// <returns>   Access Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        Bluevia.Core.Schemas.OAuthToken Get(Bluevia.OAuth.Schemas.RequestToken request, string verificationCode);
    }
}
