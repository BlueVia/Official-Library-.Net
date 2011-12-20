// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bluevia.Core.Schemas
{
    public static class QueryString
    {
        public static readonly KeyValuePair<string, string> currentVersion = new KeyValuePair<string, string>("version", "v1");
        public static readonly KeyValuePair<string, string> jsonFormat = new KeyValuePair<string, string>(format, "json");
        public static readonly KeyValuePair<string, string> xmlFormat = new KeyValuePair<string, string>(format, "xml");

        public enum responseFormat
        {
            xml,
            json
        }

        public const string format = "alt";
    }
}

namespace Bluevia.Core.Schemas.OAuth
{
    public static class QueryString
    {
        // OAuth Standard related
        public const string oauthParameterPrefix = "oauth_";
        public const string oauthVersion = "oauth_version";
        public static readonly KeyValuePair<string, string> version1 = new KeyValuePair<string, string>(oauthVersion, "1.0");
        public const string oauthConsumer = "oauth_consumer_key";
        public const string oauthCallback = "oauth_callback";
        public const string oauthSignatureMethod = "oauth_signature_method";
        public const string oauthSignature = "oauth_signature";
        public const string oauthTimestamp = "oauth_timestamp";
        public const string oauthNonce = "oauth_nonce";
        public const string oauthToken = "oauth_token";
        public const string oauthTokenSecret = "oauth_token_secret";
        public const string oauthVerificationCode = "oauth_verifier";

        // Telefonica related
        public const string telefonicaApiName = "xoauth_apiName";
        public const string telefonicaUserNick = "xoauth_userNick";

    }
}

