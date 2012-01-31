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

namespace Bluevia.SGAP.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   AdRequest object using SGAP protocol. </summary>
    /// <remarks>   22/08/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SimpleAdRequest
    {
        private String adReqId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Clear constructor. Data must be filled.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SimpleAdRequest() {
            ad_request_id = getComposedAdRequestId();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Second constructor.
        /// </summary>
        /// <param name="adSpace">Unique ID that identifies the ad-space, the place the ad is going to be placed within the
        /// channel.</param>
        /// <param name="userAgent">The user agent of the user handset</param>
        /// <param name="protectionPolicy">The adult control policy.</param>
        /// <param name="adRequestId">Advertisement page Request Id identification.</param>
        /// <param name="targetUserId">Identifier of the Target User.</param>
        /// <param name="country">Country of the Target User / Country where the Target User is located.</param>
        /// <param name="adPresentationSize">Size of the advertising space.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SimpleAdRequest(string adSpace, string userAgent, string protectionPolicy, string adRequestId = null, string targetUserId = null, string country = null, string adPresentationSize = null)
        {
            ad_space = adSpace;
            user_agent = userAgent;
            protection_policy = protectionPolicy.ToString();
            if (adRequestId != null)
            {
                adReqId = adRequestId;
                ad_request_id = adReqId;
            }
            else
            {
                adReqId = getComposedAdRequestId();
                ad_request_id = adReqId;
            }
            this.country = country;
            target_user_id = targetUserId;
            ad_presentation_size = adPresentationSize;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets or sets the ad request id </summary>
        /// <value> Advertisement page Request Id identification </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ad_request_id { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets or sets the ad presentation </summary>
        /// <value>Format of the target advertising space</value> 
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ad_presentation { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets or sets the ad presentation size</summary>
        /// <value>Size of the advertising space</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ad_presentation_size { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the ad space. </summary>
        /// <value> 
        ///     Unique ID that identifies the ad-space, the place the ad is going to be placed within the
        ///     channel. This parameter should be unique for partner_id.. 
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ad_space { get; set; } 

 
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user agent. </summary>
        /// <value> 
        ///     The user agent of the user handset defined as the unique identifier of the mobile device
        ///     sending the request. 
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string user_agent { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the keywords. </summary>
        /// <value> Keywords the ads are related to, if provided (pipe separated “|”). </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string keywords { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the protection policy. </summary>
        /// <value> The adult control policy. It will be safe, low, high. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string protection_policy { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets or sets the country</summary>
        /// <value>the country</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string country { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets or sets the user identification</summary>
        /// <value>the user identification</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string target_user_id { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Return a composed RequestId, to manage it for the user</summary>
        /// <value> the composed Ad_Request_id</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private string getComposedAdRequestId()
        {
            string accessToken = Bluevia.Core.BlueviaConsumer.TokenManager.getActiveToken();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (ad_space != null)
            {
                if (ad_space.Length > 10)
                    sb.Append(ad_space.Substring(0, 10));
                else sb.Append(ad_space);
            }
            String timestamp = DateTime.Now.ToString("yyyMMMddHH:mm:ss");
            sb.Append(timestamp);

            if (!string.IsNullOrEmpty(accessToken))
            {
                if (accessToken.Length > 10)
                    sb.Append(accessToken.Substring(0, 10));
                else sb.Append(accessToken);
            }

            return sb.ToString();
        }

        public KeyValueUrl ToHttpQueryString()
        {
            Bluevia.Core.KeyValueUrl qs = new Bluevia.Core.KeyValueUrl();

            qs.Add("ad_presentation", ad_presentation);
            qs.Add("ad_presentation_size", ad_presentation_size);
            qs.Add("ad_request_id", ad_request_id);
            qs.Add("ad_space", ad_space);
            qs.Add("country", country);
            qs.Add("keywords", keywords);
            qs.Add("protection_policy", protection_policy);
            qs.Add("target_user_id", target_user_id);
            qs.Add("user_agent", user_agent);

            return qs;
        }
    }
}

