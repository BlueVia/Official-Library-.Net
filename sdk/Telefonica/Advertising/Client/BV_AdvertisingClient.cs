// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 
using System;
using System.Collections.Generic;

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Tools;
using Bluevia.Core.Schemas;
using Bluevia.Advertising.Schemas;
using Bluevia.Advertising.Tools;

namespace Bluevia.Advertising.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_AdvertisingClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This functional block covers the Ad Request submission following 
    /// <a href="https://www.bluevia.com/en/page/tech.APIs.AdvertisingAPI">GAP (Generic Advertising Protocol).</a></summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_AdvertisingClient : BV_BaseClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Advertising functional block, to work 
        /// as a trusted client. 
        /// It calls the base Init function, wich creates the SSL client's certificate, the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitTrusted(BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            base.InitTrusted(mode, consumer, consumerSecret, certPath, certPasswd);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Advertising functional block, to work 
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
        /// <summary>As this function can only be used in 2-legged-mode, this function checks that,
        /// and if needed, generates the apropiate identifier. Then calls <see cref="GetAdvertisingProcess"/>
        /// </summary>
        /// <param name="adSpace">The adSpace of the Bluevia application.</param>
        /// <param name="country">Country where the target user is located.
        /// Must follow <a href="http://www.iso.org/iso/country_codes.htm)">ISO-3166</a>.</param>
        /// <param name="targetUserId">Identifier of the Target User.</param> 
        /// <param name="adRequestId">An unique id for the request.  
        /// (if it is not set, the SDK will generate it automatically).</param>
        /// <param name="adPresentation">The value is a code that represents the ad format type</param>
        /// <param name="keywords">If you wish to retrieve advertisings related to some keywords.</param>
        /// <param name="protectionPolicy">The adult control policy. It will be <a href=""> safe, low, high.</a> 
        /// It should be checked with the application SLA in the Bluevia endpoint</param>
        /// <param name="userAgent">The user agent of the client. ("none" by default).</param>
        /// <param name="xPhoneNumber">Will be used to convey the MSISDN to whom the advertising is targeted in trusted behavior.</param>
        /// <returns>The result returned by the server that contains the ad meta-data</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected SimpleAdResponse GetAdvertising2L(string adSpace, string country ,string targetUserId
            , string adRequestId, TypeId adPresentation, string[] keywords
            , ProtectionPolicy protectionPolicy, string userAgent, string xPhoneNumber)
        {
            if(!connector.IsTwoLegged())
            {
                throw new BlueviaException("GetAdvertising2L is only for requesting advertising by twolegged mode."
                           , ExceptionCode.InvalidModeException);
            }
            if (string.IsNullOrEmpty(xPhoneNumber))
            {
                if (string.IsNullOrEmpty(country))
                {
                    throw new BlueviaException("Null or empty \"country\" when calling GetAdvertising2L."
                            , ExceptionCode.InvalidArgumentException);
                }
            }
            //RequestId is mandatory for the request, so if the developer hasn't specified it, a new one is created
            //without token
            if (string.IsNullOrEmpty(adRequestId))
            {
                adRequestId = string.Concat(
                    Guid.NewGuid().ToString().Replace("-", "_")
                    , Convert.ToString(DateTime.UtcNow));
            }
            return GetAdvertisingProcess(adSpace,country,targetUserId
            ,adRequestId,adPresentation,keywords
            ,protectionPolicy,userAgent,xPhoneNumber);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>As this function can only be used in 3-legged-mode, this function checks that,
        /// and if needed, generates the apropiate identifier. Then calls <see cref="GetAdvertisingProcess"/>
        /// </summary>
        /// <param name="adSpace">The adSpace of the Bluevia application.</param>
        /// <param name="country">Country where the target user is located.
        /// Must follow <a href="http://www.iso.org/iso/country_codes.htm)">ISO-3166</a>.</param>
        /// <param name="adRequestId">An unique id for the request. 
        /// (if it is not set, the SDK will generate it automatically).</param>
        /// <param name="adPresentation">The value is a code that represents the ad format type</param>
        /// <param name="keywords">If you wish to retrieve advertisings related to some keywords.</param>
        /// <param name="protectionPolicy">The adult control policy. It will be <a href=""> safe, low, high.</a> 
        /// It should be checked with the application SLA in the Bluevia endpoint</param>
        /// <param name="userAgent">The user agent of the client. ("none" by default).</param>
        /// <returns>The result returned by the server that contains the advertising meta-data</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected SimpleAdResponse GetAdvertising3L(string adSpace, string country
            , string adRequestId, TypeId adPresentation, string[] keywords
            , ProtectionPolicy protectionPolicy, string userAgent)
        {
            if (connector.IsTwoLegged())
            {
                throw new BlueviaException("GetAdvertising is only for requesting advertising by threelegged mode."
                           , ExceptionCode.InvalidModeException);
            }
            //RequestId is mandatory for the request, so if the developer hasnt specified it, a new one is created
            //with token
            if (string.IsNullOrEmpty(adRequestId))
            {
                adRequestId = string.Concat(connector.GetToken(), Convert.ToString(DateTime.UtcNow));
            }

            return GetAdvertisingProcess(adSpace, country, null
            , adRequestId, adPresentation, keywords
            , protectionPolicy, userAgent, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function creates and calls the advertising request, with the data received from
        /// <see cref="GetAdvertising2L"/> and <see cref="GetAdvertising3L"/>.</summary>
        /// <param name="adSpace">The adSpace of the Bluevia application.</param>
        /// <param name="country">Country where the target user is located.
        /// Must follow <a href="http://www.iso.org/iso/country_codes.htm)">ISO-3166</a>.</param>
        /// <param name="targetUserId">Identifier of the Target User.</param> 
        /// <param name="adRequestId">An unique id for the request.  
        /// (if it is not set, the SDK will generate it automatically).</param>
        /// <param name="adPresentation">The value is a code that represents the ad format type</param>
        /// <param name="keywords">If you wish to retrieve advertisings related to some keywords.</param>
        /// <param name="protectionPolicy">The adult control policy. It will be <a href=""> safe, low, high.</a> 
        /// It should be checked with the application SLA in the Bluevia endpoint</param>
        /// <param name="userAgent">The user agent of the client. ("none" by default).</param>
        /// <param name="xPhoneNumber">Will be used to convey the MSISDN to whom the advertising is targeted in trusted behavior.</param>
        /// <returns>The result returned by the server that contains the ad meta-data</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private SimpleAdResponse GetAdvertisingProcess(string adSpace, string country, string targetUserId
            , string adRequestId, TypeId adPresentation, string[] keywords
            , ProtectionPolicy protectionPolicy, string userAgent, string xPhoneNumber)
        {
            if (string.IsNullOrEmpty(adSpace))
            {
                throw new BlueviaException("Null or empty adSpace when getting Advertising."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Building the request object
            SimpleAdRequest simpleAdRequest = AdvertisingTools.CreateSimpleAdRequest(adSpace, country, targetUserId, adRequestId, adPresentation, keywords, protectionPolicy, userAgent);

            Dictionary<string,string> headers = CreateHeaders(HttpTools.ContetTypeFormUrl);
            if(!string.IsNullOrEmpty(xPhoneNumber))
            {
                headers.Add(Constants.XPhoneKey,xPhoneNumber);
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            SimpleAdResponseType simpleAdResponseType = BaseCreate<SimpleAdResponseType, Dictionary<string, string>>(
                string.Format(url, Constants.AdvertisingAdRequestSend)
                ,CreateParameters()
                ,simpleAdRequest.ToDictionary()
                , headers);

            return AdvertisingSimplifiers.SimplifyAdResponse(simpleAdResponseType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            url = string.Format(url, string.Format(Constants.apiAdvertising, sandboxString));
            //As the whole api uses the same parser and serializer, 
            //these two are instanciated and fixed
            serializer = new FormUrlSerializer();
            parser = new XMLParser();
        }
        
    }
}
