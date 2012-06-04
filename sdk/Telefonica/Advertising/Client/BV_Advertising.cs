// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;

namespace Bluevia.Advertising.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Advertising.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for SGAP (Advertising), to request an ad from the 
    /// <a href="https://www.bluevia.com/en/page/tech.APIs.AdvertisingAPI">BlueVia advertisement service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Advertising : BV_AdvertisingClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Advertising"/>. 2 and 3 Legged Constructor.</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Advertising(BVMode mode, string consumer, string consumerSecret, string token = "", string tokenSecret = "")
        {
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Requests the retrieving of an advertisement. This function can only be used 
        /// in 2-legged-mode (To use when the OAuth token hasn't been included in the construction of the client).</summary>
        /// <param name="adSpace">The adSpace of the Bluevia application.</param>
        /// <param name="country">Country where the target user is located.
        /// Must follow <a href="http://www.iso.org/iso/country_codes.htm)">ISO-3166</a>.</param>
        /// <param name="targetUserId">Optional: Identifier of the Target User.</param>
        /// <param name="adRequestId">Optional: an unique id for the request.  
        /// (if it is not set, the SDK will generate it automatically).</param>
        /// <param name="adPresentation">Optional: The value is a code that represents the ad format type</param>
        /// <param name="keywords">Optional: If you wish to retrieve advertisings related to some keywords.</param>
        /// <param name="protectionPolicy">Optional: The adult control policy. It will be safe, low, high. 
        /// It should be checked with the application SLA in the Bluevia endpoint</param>
        /// <param name="userAgent">Optional: The user agent of the client. ("none" by default).</param>
        /// <returns>The result returned by the server that contains the advertising meta-data</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.SimpleAdResponse GetAdvertising2L(string adSpace, string country
            , string targetUserId = null
            , string adRequestId = null, TypeId adPresentation = 0, string[] keywords = null
            , ProtectionPolicy protectionPolicy = 0, string userAgent = "none")
        {
            return GetAdvertising2L(adSpace, country, targetUserId, adRequestId, adPresentation, keywords, protectionPolicy, userAgent, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Requests the retrieving of an advertisement. This function can only be used 
        /// in 3-legged-mode (To use when the OAuth token has been included in the construction of the client).</summary>
        /// <param name="adSpace">The adSpace of the Bluevia application.</param>
        /// <param name="country">Optional: country where the target user is located.
        /// Must follow <a href="http://www.iso.org/iso/country_codes.htm)">ISO-3166</a>.</param>
        /// <param name="adRequestId">Optional: an unique id for the request. 
        /// (if it is not set, the SDK will generate it automatically).</param>
        /// <param name="adPresentation">Optional: The value is a code that represents the ad format type</param>
        /// <param name="keywords">Optional: If you wish to retrieve advertisings related to some keywords.</param>
        /// <param name="protectionPolicy">Optional: The adult control policy. It will be safe, low, high. 
        /// It should be checked with the application SLA in the Bluevia endpoint</param>
        /// <param name="userAgent">Optional: The user agent of the client. ("none" by default).</param>
        /// <returns>The result returned by the server that contains the advertising meta-data</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public new Schemas.SimpleAdResponse GetAdvertising3L(string adSpace, string country = null
            , string adRequestId = null, TypeId adPresentation = 0, string[] keywords = null
            , ProtectionPolicy protectionPolicy = 0, string userAgent = "none")
        {
            return base.GetAdvertising3L(adSpace, country, adRequestId, adPresentation, keywords, protectionPolicy, userAgent);
        }
    }
}
