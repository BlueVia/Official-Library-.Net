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
using Bluevia.Core.Configuration;
using Bluevia.Core.Schemas;

using DotNetOpenAuth.OAuth;

namespace Bluevia.OAuth.Client
{

    public class RequestToken : BaseClient, Bluevia.OAuth.Client.IRequestToken
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This constructor covers  the RequestToken process to reach the oauth process for Payment case.
        /// </summary>
        /// <remarks>   21/06/2011. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
         public RequestToken(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Request Token. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="userNick">     if included, it indicates a valid Identifier of the final User.
        ///                             The inclusion of this parameter means that the final User is not
        ///                             using a browser and therefore the Server will send an SMS to the
        ///                             User’s handset with a link as an alternative to the usual
        ///                             redirection to AA Portal mechanism. </param>
        /// <param name="callbackUrl">  URL of the callback. </param>
        /// <param name="apiName">      if included, specifies the concrete API for which the Request
        ///                             Token wants to be obtained. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.OAuth.Schemas.RequestToken Get(string callbackUrl = "oob")
        {
            if (string.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = "oob";
            }

            //If callback is a numeric value, request token should be retrieved by sms handshake mode.
            long result = 0;
            bool isNumericCallback = long.TryParse(callbackUrl, out result);

            if (isNumericCallback)
            {
                if (result > 0)
                {
                    return GetWithSMSHandshake(callbackUrl);
                }
                else throw new Exception("Invalid MSISDN number while requesting Tokens.");
            }
            else
            {
                IDictionary<string, string> redirectParameters = new Dictionary<string, string>();
                IDictionary<string, string> requestParameters = new Dictionary<string, string>();

                string uri = Bluevia.Core.Configuration.UriManager.OAuth_RequestToken_Get;

                requestParameters.Add(Bluevia.Core.Schemas.OAuth.QueryString.oauthCallback, callbackUrl);

                DesktopConsumer cons = new DesktopConsumer(BlueviaConsumer.ServiceDescription, BlueviaConsumer.TokenManager);
                string token;
                cons.RequestUserAuthorization(requestParameters, redirectParameters, out token);
                return new OAuth.Schemas.RequestToken() 
                { 
                    Token = token, 
                    TokenSecret = BlueviaConsumer.TokenManager.GetTokenSecret(token),
                    AuthoriseUrl = Bluevia.Core.Configuration.Client.AuthoriseHost + "?oauth_token="+token
                };
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Request Token by SMSHANDSHAKE way. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="callback">   it indicates a valid msisdn Identifier of the final User.
        ///                             The inclusion of this parameter means that the final User is not
        ///                             using a browser and therefore the Server will send an SMS to the
        ///                             User’s handset with a link as an alternative to the usual
        ///                             redirection to AA Portal mechanism. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.OAuth.Schemas.RequestToken GetWithSMSHandshake(string callbackUrl)
        {
            if(!Bluevia.Core.Configuration.Client.dataStore.live){
                throw new Exception("OAuth by SMSHandShake is only available on LIVE MODE");
            }
            string uri = Bluevia.Core.Configuration.UriManager.OAuth_RequestToken_Get;
            Bluevia.Core.Schemas.OAuthToken token = null;

            callBuilder
               .SetCallBackUrl(callbackUrl)
               .EnableIsForSMSHandshake()
               .EnableTwoLeggedAuth()
               .SetMethod(Core.Schemas.WebMethod.Post)
               .SetBaseUri(uri)
               .AddQueryString(Core.Schemas.QueryString.currentVersion)
               .AddAcceptableStatus(200)
               .SetCallback(resp =>
               {
                   string response = resp.GetResponseReader().ReadToEnd();
                   token = responseParser(response);
               })
               .Call();
            //return token;
            return new OAuth.Schemas.RequestToken()
            {
                Token = token.Token,
                TokenSecret = token.TokenSecret,
                AuthoriseUrl = Bluevia.Core.Configuration.Client.AuthoriseHost + "?oauth_token=" + token.Token
            };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Overload for Getting the Request Token in Payment Api case. </summary>
        /// <remarks>   13/06/2011. </remarks>
        /// <param name="apiName">      if included, specifies the concrete API for which the Request
        ///                             Token wants to be obtained. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.OAuth.Schemas.RequestToken Get(uint amount, String currency, String name, String serviceID, string callbackUrl = "oob")
        {
            if (Bluevia.Core.Configuration.Client.dataStore.test)
            {
                throw new Exception("OAuth for payment is not available on TEST MODE");
            }
            if (amount <= 0)
            {
                throw new Exception("Wrong amount value for the payment.");
            }
            if (string.IsNullOrEmpty(currency))
            {
                throw new Exception("Wrong value: currency");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Wrong value: name");
            }
            if (string.IsNullOrEmpty(serviceID))
            {
                throw new Exception("Wrong value: serviceID");
            }
            if (string.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = "oob";
            }

            //If callback is a numeric value, request token should be retrieved by sms handshake mode.
            long result = 0;
            bool isNumericCallback = long.TryParse(callbackUrl, out result);

            //SMS HandShake not available for Payment.
            if (isNumericCallback)
            {
                throw new Exception("Invalid URL callback while requesting Tokens.");
            }

            string uri = Bluevia.Core.Configuration.UriManager.OAuth_RequestToken_Get;
            Bluevia.Core.Schemas.OAuthToken token = null;
            Bluevia.Core.KeyValueUrl qs = new Bluevia.Core.KeyValueUrl();

            //Adding body parameters. Sorted to match oauth requeriments.
            qs.Add("paymentInfo.amount", Convert.ToString(amount));
            qs.Add("paymentInfo.currency", currency);


            qs.Add("serviceInfo.name", name);
            qs.Add("serviceInfo.serviceID", serviceID);



             callBuilder
                .SetCallBackUrl(callbackUrl)
                .EnableIsForPaymentRequest()
                .EnableTwoLeggedAuth()
                .EnableIsFormUrlEncoded()
                .SetMethod(Core.Schemas.WebMethod.Post)
                .SetBaseUri(uri)
                .AddQueryString(Core.Schemas.QueryString.currentVersion)
                .SetRequestContentAsType<Bluevia.Core.KeyValueUrl>(qs)
                .AddAcceptableStatus(200)
                .SetCallback(resp => {
                    string response = resp.GetResponseReader().ReadToEnd();
                    token = responseParser(response);
                })
                .Call();

             //return token;
             return new OAuth.Schemas.RequestToken()
             {
                 Token = token.Token,
                 TokenSecret = token.TokenSecret,
                 AuthoriseUrl = Bluevia.Core.Configuration.Client.AuthoriseHost + "?oauth_token=" + token.Token
             };
        }

        private OAuthToken responseParser(string response)
        {
            OAuthToken token;
            string tok1;
            string tok2;
            response  = response.Substring(response.IndexOf("=")+1);
            tok1 = response.Substring(0, response.IndexOf("&"));
            response = response.Substring(response.IndexOf("=")+1);
            tok2 = response.Substring(0, response.IndexOf("&"));
            token = new OAuthToken();
            token.Token = tok1;
            token.TokenSecret = tok2;
            return token;
        }

    }
}
