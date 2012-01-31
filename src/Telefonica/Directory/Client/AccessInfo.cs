// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Xml.Serialization;
using Bluevia.Core;
using CoreSchemas = Bluevia.Core.Schemas;


namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     Information about the network the user is connected to, such as the IP address, or if she
    ///     is accessing by GPRS, UMTS, etc . 
    /// </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class AccessInfo : BaseClient, Bluevia.Directory.Client.IAccessInfo
    {
        public AccessInfo (IServiceBuilder builder) : base(builder) { }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Retrieval of all or part of the available information. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <param name="fields">   specifies the requested parts of the information, i.e.: the requested
        ///                         fields of information. </param>
        /// <returns>   Requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserAccessInfoType Get(Schemas.AccessInfoFields fields)
        {
            Schemas.UserAccessInfoType personalInfo = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_AccessInfo_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                .SetMethod(CoreSchemas.WebMethod.Get)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddQueryString("fields", fields.ToFlagStringQuoted())
                .AddAcceptableStatus(200)
                .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserAccessInfoType>(); })
                .Call();

            return personalInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Retrieval of all of the available information. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <returns>   Requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserAccessInfoType Get()
        {
            Schemas.UserAccessInfoType personalInfo = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_AccessInfo_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                .SetMethod(CoreSchemas.WebMethod.Get)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserAccessInfoType>(); })
                .Call();

            return personalInfo;
        }

    }
}
