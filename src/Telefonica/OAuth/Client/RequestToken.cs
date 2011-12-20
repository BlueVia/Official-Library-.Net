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
        public Bluevia.Core.Schemas.OAuthToken Get(string callbackUrl = "oob")
        {

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

                if (string.IsNullOrEmpty(callbackUrl))
                {
                    callbackUrl = "oob";
                }
                requestParameters.Add(Bluevia.Core.Schemas.OAuth.QueryString.oauthCallback, callbackUrl);

                DesktopConsumer cons = new DesktopConsumer(BlueviaConsumer.ServiceDescription, BlueviaConsumer.TokenManager);
                string token;
                cons.RequestUserAuthorization(requestParameters, redirectParameters, out token);
                return new Core.Schemas.OAuthToken() { Token = token, TokenSecret = BlueviaConsumer.TokenManager.GetTokenSecret(token) };
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Request Token. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="callback">   it indicates a valid msisdn Identifier of the final User.
        ///                             The inclusion of this parameter means that the final User is not
        ///                             using a browser and therefore the Server will send an SMS to the
        ///                             User’s handset with a link as an alternative to the usual
        ///                             redirection to AA Portal mechanism. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.Core.Schemas.OAuthToken GetWithSMSHandshake(string callbackUrl)
        {
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

            return token;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Overload for Getting the Request Token in Payment Api case. </summary>
        /// <remarks>   13/06/2011. </remarks>
        /// <param name="apiName">      if included, specifies the concrete API for which the Request
        ///                             Token wants to be obtained. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.Core.Schemas.OAuthToken Get(Payment.Schemas.PaymentInfoType paymentInfo, OAuth.Schemas.ServiceInfo serviceInfo, string callbackUrl = "oob")
        {
            if (string.IsNullOrEmpty(paymentInfo.currency))
            {
                throw new Exception("Missing mandatory paymentInfo.currency parameter");
            }
            if (string.IsNullOrEmpty(serviceInfo.name) || string.IsNullOrEmpty(serviceInfo.serviceID))
            {
                throw new Exception("Missing mandatory serviceInfo parameter");
            }
            if (string.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = "oob";
            }
            string uri = Bluevia.Core.Configuration.UriManager.OAuth_RequestToken_Get;
            Bluevia.Core.Schemas.OAuthToken token = null;
            Bluevia.Core.KeyValueUrl qs = new Bluevia.Core.KeyValueUrl();

            //Adding body parameters. Sorted to match oauth requeriments.
            qs.Add("paymentInfo.amount", Convert.ToString(paymentInfo.amount));
            qs.Add("paymentInfo.currency", paymentInfo.currency);


            qs.Add("serviceInfo.name", serviceInfo.name);
            qs.Add("serviceInfo.serviceID", serviceInfo.serviceID);

            //If callback is a numeric value, request token should be retrieved by sms handshake mode.
            long result = 0;
            bool isNumericCallback = long.TryParse(callbackUrl, out result);

            //SMS HandShake not available for Payment
            if (isNumericCallback)
            {
                throw new Exception("Invalid URL callback while requesting Tokens.");
            }

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

             return token;
        }

        private OAuthToken responseParser(string response)
        {
            Console.WriteLine(response);
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
            Console.WriteLine(Convert.ToString(token));
            return token;
        }

    }
}
