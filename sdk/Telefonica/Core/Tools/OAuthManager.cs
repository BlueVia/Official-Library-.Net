// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

using Bluevia.Core.Connectors;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="OAuthManager.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The OAuthManager: This class manages the authorization control to access the 
    /// BlueVia services, using the Open Authority system.
    /// All the client's authentication info, as the requet's info, will be stored in this class.
    /// This class wil be instanced once, as a property in the BV_HTTP_OAuth_Connector constructor.</summary>
    /// <remarks>   2012/02/09. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class OAuthManager    {

        //User's relative info:

        /// <value>The application Identifier.</value>
        public string consumer = string.Empty;

        /// <value>The application Identifier.</value>
        public string consumerSecret = string.Empty;

        /// <value>The final customer Identifier (only for 3legged access).</value>
        public string token = string.Empty;

        /// <value>The final customer Secret (only for 3legged access).</value>
        public string tokenSecret = string.Empty;


        //Request's relative info:

        /// <value>The list of oauth header fields.</value>
        public Dictionary<string, string> oauthFields;

        /// <value>The endpoint url+params.</value>
        public Uri uri;

        /// <value>The FormUrl parameters (only if the request contents FormUrl data). </value>
        public string body = string.Empty;

        /// <value>The Http access method.</value>
        public string method = string.Empty;

        //3Legged Constructor
        /// <summary>Initializes a new instance of the <see cref="OAuthManager"/>.</summary>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        public OAuthManager(string consumer, string consumerSecret,string token,string tokenSecret)
        {
            this.consumer = consumer;
            this.consumerSecret = consumerSecret;
            this.token = token;
            this.tokenSecret = tokenSecret;
        }

        //Overloaded 2legged Constructor
        /// <summary>Initializes a new instance of the <see cref="OAuthManager"/>Overload constructor for non "customer authenticated services".</summary>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        public OAuthManager(string consumer, string consumerSecret) : this(consumer, consumerSecret, string.Empty, string.Empty) { }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This method creates the Key:Value initial oauthFields Dictionary.
        /// Every value could be modified, and also new fields could be added,
        /// before making the authentication process.</summary>
        /// <remarks>   2012/02/17 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void StartOAuthFields()
        {
            //If the OauthFields Dictionary, hasnt been initialized with extra parameters form the client:
            //"BV_HTTP_OAuth_Connector.SetOAuthParams". the fields are initialized here.
            if (oauthFields == null)
            {
                oauthFields = new Dictionary<string, string>();
            }

            oauthFields.Add(OAuthConstants.OAuthTokenKey, token);
            oauthFields.Add(OAuthConstants.OAuthConsumerKeyKey, consumer);
            oauthFields.Add(OAuthConstants.OAuthNonceKey, HttpTools.GenerateNonce());
            oauthFields.Add(OAuthConstants.OAuthSignatureMethodKey, OAuthConstants.HMACSHA1SignatureType);
            //The signature will be setted during the Authentication process
            oauthFields.Add(OAuthConstants.OAuthVersionKey, OAuthConstants.OAuthVersion);
            //Maybe the timeStamp hasn't be setted during the SetOAuthParams:
            if (!(oauthFields.ContainsKey(OAuthConstants.OAuthTimestampKey)))
            {
                oauthFields.Add(OAuthConstants.OAuthTimestampKey, HttpTools.GenerateTimeStamp());
            }//Else the timeStamp has been setted before.

            
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This method deletes the request's relative fields, 
        /// to avoid future requests malfunctioning.</summary>
        /// <remarks>2012/02/22</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CleanRequestFields()
        {
            if (oauthFields!=null)
            {
                oauthFields.Clear();
            }
            body = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //                          ******** SIGNATURE GENERATING BLOCK ********
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The main Oauth method wich generates the Oauth authorization header </summary>
        /// <remarks>   2012/02/16 </remarks>
        /// <returns>The content of the authorization header.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GenerateOAuthHeader()
        {
            //Generating the signature field:
            oauthFields.Add(OAuthConstants.OAuthSignatureKey, GenerateSignature());

            //Building the authorization Header:
            string oauthHeader = "OAuth ";
            foreach (var pair in oauthFields)
            {
                oauthHeader = oauthHeader + pair.Key + "=\"" + pair.Value + "\",";
            }


            return oauthHeader.Remove(oauthHeader.Length - 1);//Deleting last ","

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generates a signature using the specified signatureType.</summary>		
        /// <returns>A base64 string of the hash value.</returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GenerateSignature()
        {            
            string signatureBase = GenerateSignatureBase();
            HMACSHA1 hmacsha1 = new HMACSHA1();

            hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", HttpTools.UrlEncode(consumerSecret), HttpTools.UrlEncode(tokenSecret)));

            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(signatureBase);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

            return HttpTools.UrlEncode(Convert.ToBase64String(hashBytes));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generate the signature base that is used to produce the signature:
        /// Must follow the following <a href="https://bluevia.com/en/knowledge/APIs.API-Guides.OAuth#NormalizedRequestParameters">format</a>
        /// Modified since BlueVia1.6.</summary>
        /// <returns>The signature base</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GenerateSignatureBase()
        {
            string normalizedUrl = null;
            string normalizedRequestParameters = null;

            //As the queryParameters are all-in-a-string, and percentEncoded in the Uri object,
            //a percentDecoding (UrlDecoding) and isolation of each parameter, must be done.

            List<KeyValuePair<string, string>> parameters = GetQueryParameters(Uri.UnescapeDataString(uri.Query));

            foreach(var pair in oauthFields)
            {
                parameters.Add(new KeyValuePair<string,string>(pair.Key,pair.Value));
            }
            

            //Body parameters
            if (!string.IsNullOrEmpty(body))
            {
                List<KeyValuePair<string, string>> bodyFields = GetQueryParameters(Uri.UnescapeDataString(body));

                foreach (var pair in bodyFields)
                {
                    parameters.Add(pair.Key, pair.Value);
                }

            }
            parameters.Sort(new QueryParameterComparer());

            normalizedUrl = string.Format("{0}://{1}", uri.Scheme, uri.Host);
            if (!((uri.Scheme == "http" && uri.Port == 80) || (uri.Scheme == "https" && uri.Port == 443)))
            {
                normalizedUrl += ":" + uri.Port;
            }

            normalizedUrl += uri.AbsolutePath;
            normalizedRequestParameters = HttpTools.NormalizeRequestParameters(parameters);

            StringBuilder signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}&", method.ToUpper());
            signatureBase.AppendFormat("{0}&", HttpTools.UrlEncode(normalizedUrl));
            signatureBase.AppendFormat("{0}", HttpTools.UrlEncode(normalizedRequestParameters));
            
            return signatureBase.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Internal function to cut out all non oauth query string parameters (all parameters not begining with "oauth_")
        /// Modified since BlueVia1.6.</summary>
        /// <param name="parameters">The query string part of the Url.</param>
        /// <returns>A list of string pairs, each containing the parameter name and value.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        List<KeyValuePair<string,string>> GetQueryParameters(string parameters)
        {
            //For the case, that the start parameters symbol, also comes.
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(parameters))
            {
                //spliting each keyValue parameters form others
                string[] p = parameters.Split('&');

                foreach (string s in p)
                {
                    if (!string.IsNullOrEmpty(s) && !s.StartsWith(OAuthConstants.OAuthParameterPrefix))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(temp[0], temp[1]);
                        }
                        else
                        {
                            result.Add(s, string.Empty);
                        }
                    }
                }
            }

            return result;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Comparer class used to perform the sorting of the query parameters.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected class QueryParameterComparer : IComparer<KeyValuePair<string,string>> {

            #region IComparer<QueryParameter> Members

            public int Compare(KeyValuePair<string,string> x, KeyValuePair<string,string> y) {
                if (x.Key == y.Key) {
                    return string.Compare(x.Value, y.Value);
                } else {
                    return string.Compare(x.Key, y.Key);
                }
            }

            #endregion
        }


    }
}
