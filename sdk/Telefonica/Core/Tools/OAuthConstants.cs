// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="OAuthConstants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The OAuth constants</summary>
    /// <remarks>   2012/02/23.
    /// 2012/03/29. Name an functionallity changed.</remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class OAuthConstants
    {
        

        //Constants:
        // List of know and used oauth parameters' names
        public static string OAuthVersion = "1.0";
        public static string OAuthParameterPrefix = "oauth_";
        public static string OAuthConsumerKeyKey = "oauth_consumer_key";
        public static string OAuthCallbackKey = "oauth_callback";
        public static string OAuthVerifierKey = "oauth_verifier";
        public static string OAuthVersionKey = "oauth_version";
        public static string OAuthSignatureMethodKey = "oauth_signature_method";
        public static string OAuthSignatureKey = "oauth_signature";
        public static string OAuthTimestampKey = "oauth_timestamp";
        public static string OAuthNonceKey = "oauth_nonce";
        public static string OAuthTokenKey = "oauth_token";
        public static string OAuthTokenSecretKey = "oauth_token_secret";
        public static string OAuthApiNameKey = "xoauth_apiName";
        public static string OAuthCallbackConfirmedKey = "oauth_callback_confirmed";

        public static string HMACSHA1SignatureType = "HMAC-SHA1";
        public static string PlainTextSignatureType = "PLAINTEXT";
        public static string RSASHA1SignatureType = "RSA-SHA1";
    }
}
