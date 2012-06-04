// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;

namespace Bluevia.Advertising.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AdvertisingTools.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Additional static methods to serve to the API main classes.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class AdvertisingTools
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Creates a Full SimpleAdRequest from the single request's advertising fields.</summary>
        /// <param name="adSpace">Unique ID that identifies the ad-space, the place the ad is going to be placed within the 
        /// channel. This parameter should be unique for partner_id.</param>
        /// <param name="country">The requester's country.</param>
        /// <param name="targetUserId">The user identification.</param>
        /// <param name="adRequestId">Advertisement page Request Id identification.</param>
        /// <param name="adPresentation">Format of the target advertising space.</param>
        /// <param name="keywords">Array of keywords the ads are related to.</param>
        /// <param name="protectionPolicy">The adult control policy. It will be safe, low, high.</param>
        /// <param name="userAgent">The user agent of the user's navigator.</param>
        /// <returns>A full builded SimpleAdRequest ready to be serialized.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Schemas.SimpleAdRequest CreateSimpleAdRequest(string adSpace, string country,
            string targetUserId, string adRequestId, TypeId adPresentation,
            string[] keywords, ProtectionPolicy protectionPolicy, string userAgent)
        {
            Schemas.SimpleAdRequest simpleAdRequest = new Schemas.SimpleAdRequest()
            {
                adSpace = adSpace,
                country = country,
                targetUserId = targetUserId,
                adRequestId = adRequestId,
                adPresentation = AdvertisingTools.TranslateTypeId(adPresentation),
                keywords = AdvertisingTools.ConvertKeywordsToString(keywords),
                protectionPolicy = Convert.ToString(protectionPolicy.GetHashCode()),
                userAgent = userAgent
            };
            //To avoid sending protection policy, if the developer hasn't specified it
            if (simpleAdRequest.protectionPolicy.Equals("0"))
            {
                simpleAdRequest.protectionPolicy = null;
            }
            return simpleAdRequest;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This function translates the enumeration selection of the advertising TypeId (Image, Text),
        /// into the relative code needed to make the request.</summary>
        /// <param name="typeId">The selected TypeId (Image, Text).</param>
        /// <returns>The relative code of the selected advertising type: Image->0101; Text->0104.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string TranslateTypeId(TypeId typeId)
        {
            switch (typeId)
            {
                case TypeId.image:
                    return "0101";
                case TypeId.text:
                    return "0104";
                default:
                    return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method to serialize the array of keywords related to the advertising request,
        /// into a string with "keyword|keyword|..." format.</summary>
        /// <param name="keywords">The keyword array.</param>
        /// <returns>The serialized keywords.</returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ConvertKeywordsToString(string[] keywords)
        {
            if (keywords == null) return null;
            if (keywords.Length <= 0) return null;
            StringBuilder builder = new StringBuilder();
            foreach (string value in keywords)
            {
                builder.Append(value);
                builder.Append('|');
            }
            return builder.Remove(builder.Length - 1, 1).ToString();
        }
    }
}
