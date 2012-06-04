// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Schemas;
using Bluevia.Core.Tools;

using Bluevia.OAuth.Tools;

namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_OAuth.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for OAuth operations.</summary>
    /// <remarks>2012/03/19</remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_OAuthClient : BV_BaseClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Oauth functional block, to work 
        /// as an untrusted client. 
        /// It calls the base Init function, wich creates the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret
            , string token = "", string tokenSecret = "")
        {
            base.InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the Request Token.</summary>
        /// <remarks>2012/03/19</remarks>
        /// <param name="callback">Optional. If exists, it indicates a valid URL where the verifier code
        /// for the OAuth process, is going to be sent (Out of Band mode by default).</param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public RequestToken GetRequestToken(string callback = "oob")
        {
            if (string.IsNullOrEmpty(callback))
            {
                callback = "oob";
            }
            else
            {
                long result = 0;
                bool isNumericCallback = long.TryParse(callback, out result);

                if (isNumericCallback)
                {
                    throw new BlueviaException("Invalid callback parameter while making RequestTokens."
                        , ExceptionCode.InvalidArgumentException);
                }
            }
            return GetRequestTokensProcess(callback);
        }
        

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the Request Token, by SMS Handshake: the final user is not using a browser,
        /// and therefore the server will send an SMS to the User’s handset
        /// with a link as an alternative to the usual redirection to AA Portal mechanism. </summary>
        /// <remarks>2012/03/22</remarks>
        /// <param name="phoneNumber">MSISDN Identifier of the final User.</param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public RequestToken GetRequestTokenSMSHandshake(string phoneNumber)
        {
            Core.Tools.Extension.checkIsNumber(phoneNumber, "phoneNumber");
            if (bvMode != BVMode.LIVE)
            {
                throw new BlueviaException("OAuth by SMSHandShake is only available on LIVE MODE"
                    , ExceptionCode.InvalidArgumentException);
            }
            return GetRequestTokensProcess(phoneNumber);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Makes the process to retrieve the Request Tokens, once the parameter has been checked.</summary>
        /// <remarks>2012/03/22</remarks>
        /// <param name="callback">Callback or msisdn.</param>
        /// <param name="paymentFields">Optional: A dictionary containing the payment data, for a payment case.</param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected RequestToken GetRequestTokensProcess(string callback, Dictionary<string,string> paymentFields = null)
        {
            //Forcing the connector to function as 2leggedConnector:
            connector.SetTokens(string.Empty, string.Empty);

            //Extra OAuth parameters for the RequestToken operation
            Dictionary<string, string> oauthExtra = new Dictionary<string, string>();
            oauthExtra.Add(OAuthConstants.OAuthCallbackKey, callback);

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            Dictionary<string, string> pairs = null;
             if (paymentFields != null)
            {
                oauthExtra.Add("xoauth_apiName", "Payment"+string.Format(sandboxString,""));
                connector.SetOAuthParams(oauthExtra);
                pairs = BaseCreate<Dictionary<string, string>, Dictionary<string, string>>(
                string.Format(url, Constants.OAuthRequestTokenGet)
                , CreateParameters()
                , paymentFields, CreateHeaders(HttpTools.ContetTypeFormUrl));
            }
            else
            {
                 connector.SetOAuthParams(oauthExtra);
                 //The Bluevia´s complex response object, as result of the call:
                 pairs = BaseCreate<Dictionary<string, string>, string>(
                     string.Format(url, Constants.OAuthRequestTokenGet)
                     , CreateParameters()
                     , null, CreateHeaders(HttpTools.ContetTypeVoid));
            }            

            //Filling the RequestToken result fields:
            RequestToken requestToken = (RequestToken)OAuthSimplifiers.SimplifyTokenType(pairs);

            if (bvMode == BVMode.LIVE)
            {
                requestToken.authUrl = string.Format(Core.Constants.authoriseHostLive, requestToken.key);
            }
            else
            {
                requestToken.authUrl = string.Format(Core.Constants.authoriseHostTest, requestToken.key);
            }

            //Setting the RequestTokens into the Connector:
            connector.SetTokens(requestToken.key, requestToken.secret);

            return requestToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the Access Token.</summary>
        /// <remarks>2012/03/20</remarks>
        /// <param name="oauthVerifier">OAuth verifier for the token. </param>
        /// <param name="requestToken">Optional: The previously received requestToken 
        /// (its autosetted during the requestToken process, and can be setted also during the client construction).</param>
        /// <param name="requestSecret">Optional: The previously received requestTokenSecret
        /// (its autosetted during the requestToken process, and can be setted also during the client construction).</param>
        /// <returns>AccessToken for the app.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Core.Schemas.Token GetAccessToken(string oauthVerifier, string requestToken = null, string requestSecret=null )
        {
            if (string.IsNullOrEmpty(oauthVerifier))
            {
                throw new BlueviaException("Invalid Verifier PinCode while getting Access Tokens."
                        , ExceptionCode.InvalidArgumentException);
            }
            if (!string.IsNullOrEmpty(requestToken) && !string.IsNullOrEmpty(requestSecret))
            {
                //Setting the RequestTokens into the Connector:
                connector.SetTokens(requestToken, requestSecret);
            }
            else
            {
                if (string.IsNullOrEmpty(connector.GetToken()))
                {
                    throw new BlueviaException("RequestTokens must be provided, to use GetAccessToken on this way."
                        , ExceptionCode.InvalidArgumentException);
                }
            }

            //Extra OAuth parameters for the AccessToken operation
            Dictionary<string, string> oauthExtra = new Dictionary<string, string>();
            oauthExtra.Add(OAuthConstants.OAuthVerifierKey,oauthVerifier);
            connector.SetOAuthParams(oauthExtra);

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            Dictionary<string, string> pairs = BaseCreate<Dictionary<string, string>, string>(
                    string.Format(url, Constants.OAuthAccessTokenGet)
                    , CreateParameters()
                    , null, CreateHeaders(HttpTools.ContetTypeVoid));


            Token accessToken = OAuthSimplifiers.SimplifyTokenType(pairs);

            //Setting the RequestTokens into the Connector:
            connector.SetTokens(accessToken.key, accessToken.secret);

            return accessToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            url = string.Format(url, Constants.apiOAuth);

            //As the whole api uses the same parser and serializer, 
            //these two are instanciated and fixed
            serializer = new FormUrlSerializer();
            parser = new FormUrlParser();
        }
    }
}
