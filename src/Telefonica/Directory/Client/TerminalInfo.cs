// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schemas = Bluevia.Directory.Schemas;
using CoreSchemas = Bluevia.Core.Schemas;
using Bluevia.Core;
using System.Xml.Serialization;


namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the Terminal that is being used by a certain User.  </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class TerminalInfo : BaseClient, Bluevia.Directory.Client.ITerminalInfo
    {
        public TerminalInfo(IServiceBuilder builder) : base(builder) { }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Retrieval of all of the available information. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <returns>   Requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserTerminalInfoType Get()
        {
            Schemas.UserTerminalInfoType personalInfo = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_TerminalInfo_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                .SetMethod(CoreSchemas.WebMethod.Get)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserTerminalInfoType>(); })
                .Call();

            return personalInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Retrieval of all or part of the available information. </summary>
        /// <remarks>   04/05/2010. </remarks>
        /// <param name="fields">   The requested parts of the information, i.e.: the requested fields of
        ///                         information. </param>
        /// <returns>   Requested information available. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserTerminalInfoType Get(Schemas.TerminalInfoFields fields)
         {
             Schemas.UserTerminalInfoType personalInfo = null;

             callBuilder
                 .SetBaseUri(Bluevia.Core.Configuration.UriManager.Directory_TerminalInfo_Get.FormatWithInvariantCulture(Schemas.GuidType.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken()))
                 .SetMethod(CoreSchemas.WebMethod.Get)
                 .AddQueryString(CoreSchemas.QueryString.currentVersion)
                 .AddQueryString("fields", fields.ToFlagStringQuoted())
                 .AddAcceptableStatus(200)
                 .SetCallback(resp => { personalInfo = resp.ParseXml<Schemas.UserTerminalInfoType>(); })
                 .Call();

             return personalInfo;
         }
    }
}
