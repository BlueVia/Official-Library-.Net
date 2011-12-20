// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Bluevia.Core.Schemas;
using OAuthSchemas = Bluevia.Core.Schemas.OAuth.QueryString;

namespace Bluevia.Core
{
    public class TwoLeggedOAuth : OAuthBase
    {
        private String timeStamp;
        private String nonce;
        private String normalizedUrl;
        private String normalizedParams;
        private String consumerKey;
        private String consumerSecret;
        private String callBack;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Set the callback address</summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void setCallBack(string callBack)
        {
            this.callBack = callBack;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public HttpWebRequest generateTwoLeggedOAuthRequest(Uri uri, WebMethod method)
        {
            consumerKey = Core.Configuration.Client.Consumer;
            consumerSecret = Core.Configuration.Client.ConsumerSecret;

            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(uri);
            string oAuthHeader = this.GetTwoLeggedHeader(uri, method);
            request.Headers.Add(HttpRequestHeader.Authorization, oAuthHeader);
            request.Method = method.ToString();
            return request;
        }

        public HttpWebRequest generateTwoLeggedOAuthRequest(Uri uri, WebMethod method, IDictionary<string, string> pairs)
        {
            this.pairs = pairs;
            return generateTwoLeggedOAuthRequest(uri, method);
        }

        private string GetTwoLeggedHeader(Uri uri, WebMethod method)
        {
            string head;
            string signature;

                signature = GenerateSignatureHMAC(uri, method);

            head="OAuth " +
                OAuthSchemas.oauthConsumer + "=\"" + consumerKey + "\"," +
                OAuthSchemas.oauthNonce + "=\"" + nonce + "\"," +
                OAuthSchemas.oauthSignatureMethod + "=\"" + HMACSHA1SignatureType + "\"," +
                OAuthSchemas.oauthSignature + "=\"" + signature + "\"," +
                OAuthSchemas.oauthVersion + "=\"" + OAuthVersion + "\"," +
                OAuthSchemas.oauthTimestamp + "=\"" + timeStamp + "\",";

            if (isForPaymentRequest || isForSMSHandshake)
            {
                if(isForPaymentRequest)
                {
                    if(Bluevia.Core.Configuration.Client.Sandbox){
                        head = String.Concat(
                            head,
                            Bluevia.Core.Schemas.OAuth.QueryString.telefonicaApiName + "=\"" + "Payment_Sandbox" + "\"," 
                            );
                    }else{
                        head = String.Concat(
                            head,
                            Bluevia.Core.Schemas.OAuth.QueryString.telefonicaApiName + "=\"" + "Payment" + "\","
                            );
                    }
                }
                head = String.Concat(
                    head,
                    Bluevia.Core.Schemas.OAuth.QueryString.oauthCallback + "=\"" + UrlEncode(callBack) + "\""
                    );
            }
            else
            {
                head = String.Concat(head,
                OAuthSchemas.oauthToken + "=\"" + String.Empty + "\"");
            }
            return head;

        }

        
        private string GenerateSignatureHMAC(Uri uri, WebMethod method)
        {
            timeStamp = GenerateTimeStamp();
            nonce = GenerateNonce();
            string api;

            if (isForPaymentRequest)
            {
                if (Bluevia.Core.Configuration.Client.Sandbox)
                {
                    api = "Payment_Sandbox";
                }
                else
                {
                    api = "Payment";
                }
            }
            else
            {
                api = "";
            }
            string signature = this.GenerateSignature(uri, consumerKey, consumerSecret, String.Empty, String.Empty, method.ToString(), timeStamp, nonce, callBack, api, out normalizedUrl, out normalizedParams);

            return signature;
        }

    }
}
