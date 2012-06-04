// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;
using System.Collections.Generic;
using System.Net;

using System.Security.Cryptography.X509Certificates;

using Bluevia.Core.Schemas;
using Bluevia.Core.Tools;

namespace Bluevia.Core.Connectors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Connector.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>The BV_HTTP_OAuth_Connector: Class wich extends the HttpConnector functionallity,
    /// providing <a href="http://oauth.net/"> OAuth authentication</a> info to access the 
    /// BlueVia services in Http way.
    /// It receives the invocation from the Bluevia client, formats the received data,
    /// and executes the HttpConnector's relative method. </summary>
    /// <remarks>   2012/02/09. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Connector : HTTPConnector, IBV_OAuth
    {

        /// <value>The authentication's manager.</value>
        private OAuthManager oauthManager;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Connector"/>.Trusted constructor</summary>
        /// <remarks>   2012/02/16. </remarks>
        /// <param name="consumerKey">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certCollection">The certificate collection to attach into the request,
        /// for SSL client authentication.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Connector(string consumerKey, string consumerSecret, X509CertificateCollection certCollection)
        {
            if (String.IsNullOrEmpty(consumerKey) || String.IsNullOrEmpty(consumerKey)||(certCollection==null))
            {
                BlueviaException ex = new BlueviaException("Null or Empty parameter when creating a Trusted BV_Connector.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }
            oauthManager = new OAuthManager(consumerKey, consumerSecret);
            base.certCollection = certCollection;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Connector"/>Untrusted 2 and 3 legged constructor</summary>
        /// <remarks>2012.05.8 Adding mutual check for token existence. </remarks>
        /// <param name="consumerKey">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Connector(string consumerKey, string consumerSecret, string token = "", string tokenSecret = "")
        {
            if (String.IsNullOrEmpty(consumerKey) || String.IsNullOrEmpty(consumerKey) )
            {
                BlueviaException ex = new BlueviaException("Null or Empty parameter when creating Untrusted BV_Connector.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }

            if ((string.IsNullOrWhiteSpace(token) && (!string.IsNullOrWhiteSpace(tokenSecret)))
                || ((!string.IsNullOrWhiteSpace(token)) && string.IsNullOrWhiteSpace(tokenSecret)))
            {
                throw new BlueviaException(
                    "Both token and tokenSecret must be properly filled, or empty, when creating Bluevia Connector."
                    , ExceptionCode.InvalidArgumentException);
            }

            oauthManager = new OAuthManager(consumerKey, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to change the behavior of the BV_HTTP_OAuth_Connector, from 2legged to 3legged.</summary>
        /// <remarks>   2012/02/16. </remarks>
        /// <param name="token">The access Token</param>
        /// <param name="tokenSecret">The Token Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetTokens(string token, string tokenSecret)
        {
            if ((string.IsNullOrWhiteSpace(token) && (!string.IsNullOrWhiteSpace(tokenSecret)))
                || ((!string.IsNullOrWhiteSpace(token)) && string.IsNullOrWhiteSpace(tokenSecret)))
            {
                throw new BlueviaException(
                    "Both token and tokenSecret must be properly filled, or empty, when setting tokens."
                    , ExceptionCode.InvalidArgumentException);
            }
            oauthManager.token = token;
            oauthManager.tokenSecret = tokenSecret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to retrieve the Access Token</summary>
        /// <remarks>   2012/03/08. </remarks>
        /// <return>The Access Token.</return>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetToken()
        {
            return oauthManager.token;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to know if the instance is a two legged Oauth Object</summary>
        /// <remarks>   2012/03/12. </remarks>
        /// <return>True, if the Object is OathTwolegged; False, if is ThreeLegged.</return>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool IsTwoLegged()
        {
            if (string.IsNullOrEmpty(oauthManager.token))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to provide, from the client, Bluevia's "special oauth options" 
        /// into the OAuthManager.</summary>
        /// <remarks>   2012/02/21. </remarks>
        /// <param name="extraParams">KeyValuePairs with extra Oauth fields or updated values.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetOAuthParams(Dictionary<string, string> extraParams)
        {
            if (extraParams == null)
            {
                throw new BlueviaException(
                    "Null parameters when using SetOAuthParams."
                    ,ExceptionCode.InvalidArgumentException);
            }
            //As requested Before the CRUD Method, this one starts here the oauthFields Dictionary in the OAuthManager.
            //In case this method is not called before the CRUD Method, the oauthFields dictionary, will be created in the StartOauthFields Method. 
            oauthManager.oauthFields = extraParams;

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to prepare or provide authentication info for the HTTP operation.</summary>
        /// <remarks>   2012/02/09. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public override void Authenticate()
        {
            //The request fields of the OauthManager are filled:
            oauthManager.StartOAuthFields();
            oauthManager.uri = uri;
            oauthManager.method = request.Method;
            if (headers!=null)
            {
                string contentType = null;
                headers.TryGetValue(Bluevia.Core.Tools.HttpTools.ContetTypeKey, out contentType);
                if (contentType.Contains("x-www-form"))
                {
                    oauthManager.body = Encoding.UTF8.GetString(this.body);
                }
            }
            //The Oauth Signature is builded, and attached to the request headers.
            request.Headers.Set(HttpRequestHeader.Authorization, oauthManager.GenerateOAuthHeader());
            //Once the authentication has been made, the OAuthManager oauthFields is deleted, to avoid malfunctioning in future requests.
            oauthManager.CleanRequestFields();
        }

    }
}
