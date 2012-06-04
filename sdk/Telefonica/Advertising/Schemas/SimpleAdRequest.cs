// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 
using System.Collections.Generic;

namespace Bluevia.Advertising.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="SimpleAdRequest.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   AdRequest object using SGAP protocol. </summary>
    /// <remarks>   22/08/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SimpleAdRequest
    {

        /// <value> Advertisement page Request Id identification.</value>
        public string adRequestId;
        
        /// <value>Format of the target advertising space.</value> 
        public string adPresentation;
        
        /// <value>Unique ID that identifies the ad-space, the place the ad is going to be placed within the 
        /// channel. This parameter should be unique for partner_id.</value>
        public string adSpace;

        /// <value>The user agent of the user's navigator.</value>
        public string userAgent;
        
        /// <value>Keywords the ads are related to, if provided (pipe separated "|").</value>
        public string keywords;
        
        /// <value> The adult control policy. It will be safe, low, high. </value>
        public string protectionPolicy;

        /// <value>The requester's country.</value>
        public string country;
        
        /// <value>The user identification.</value>
        public string targetUserId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function that creates a collection with all the nonEmpty fields of the AdRequest</summary>
        /// <returns>The collection of all the nonEmpty fields.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Dictionary<string,string> ToDictionary()
        {
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            if (!string.IsNullOrEmpty(adPresentation)) dictionary.Add("ad_presentation", adPresentation);
            if (!string.IsNullOrEmpty(adRequestId)) dictionary.Add("ad_request_id", adRequestId);
            if (!string.IsNullOrEmpty(adSpace)) dictionary.Add("ad_space", adSpace);
            if (!string.IsNullOrEmpty(country)) dictionary.Add("country", country);
            if (!string.IsNullOrEmpty(keywords)) dictionary.Add("keywords", keywords);
            if (!string.IsNullOrEmpty(protectionPolicy)) dictionary.Add("protection_policy", protectionPolicy);
            if (!string.IsNullOrEmpty(targetUserId)) dictionary.Add("target_user_id", targetUserId);
            if (!string.IsNullOrEmpty(userAgent)) dictionary.Add("user_agent", userAgent);

            return dictionary;
        }
    }
}

