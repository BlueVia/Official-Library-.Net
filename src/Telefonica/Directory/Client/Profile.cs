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
    ///     Information about the profile of the user, such as whether the roaming is active, the SIM
    ///     type or the Operator giving service to the user. 
    /// </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Profile : BaseClient, Bluevia.Directory.Client.IProfile
    {
        public Profile(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all information. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <returns>   Returns the requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserProfileType Get()
        {
            Schemas.UserProfileType personalInfo = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_Profile_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                .SetMethod(CoreSchemas.WebMethod.Get)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserProfileType>(); })
                .Call();

            return personalInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <param name="fields">   The fields. </param>
        /// <returns>   Returns the requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserProfileType Get(Schemas.ProfileFields fields)
        {
            Schemas.UserProfileType personalInfo = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_Profile_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                .SetMethod(CoreSchemas.WebMethod.Get)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddQueryString("fields", fields.ToFlagStringQuoted())
                .AddAcceptableStatus(200)
                .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserProfileType>(); })
                .Call();

            return personalInfo;
        }

    }
}
