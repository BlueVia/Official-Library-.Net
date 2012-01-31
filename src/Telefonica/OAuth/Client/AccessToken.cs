// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core;

namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   This functional block covers the Access Token Request.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class AccessToken :  Bluevia.OAuth.Client.IAccessToken
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
        public Core.Schemas.OAuthToken Get(OAuth.Schemas.RequestToken request, string verificationCode)
        {
            DotNetOpenAuth.OAuth.DesktopConsumer cons = new DotNetOpenAuth.OAuth.DesktopConsumer(BlueviaConsumer.ServiceDescription, BlueviaConsumer.TokenManager);
            var accessToken = cons.ProcessUserAuthorization(request.Token, verificationCode);
            return new Core.Schemas.OAuthToken() { Token = accessToken.AccessToken, TokenSecret = BlueviaConsumer.TokenManager.GetTokenSecret(accessToken.AccessToken) };
        }

    }
}
