// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;
using Bluevia.Core;
using Bluevia.Core.Configuration;
using Bluevia.SGAP.Schemas;
using CoreSchemas = Bluevia.Core.Schemas;
using System.Linq;
namespace Bluevia.SGAP.Client
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   This functional block covers the Ad Request submission following GAP (Generic Advertising Protocol). 
    /// </summary>
    /// <remarks>   03/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class AdRequest : BaseClient, Bluevia.SGAP.Client.IAdRequest
    {
        public AdRequest(IServiceBuilder builder) : base(builder) { }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends AdRequest using SGAP protocol. </summary>
        /// <remarks>   22/08/2010. </remarks>
        /// <param name="adrequest">    The (simple) adrequest. </param>
        /// <returns>   Ad Resource created. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.SGAP.Schemas.SimpleAdResponse Send(Bluevia.SGAP.Schemas.SimpleAdRequest adrequest)
        {
            Bluevia.SGAP.Schemas.SimpleAdResponseType adresponse = null;
            callBuilder
                .EnableIsFormUrlEncoded()
                .SetMethod(CoreSchemas.WebMethod.Post)
                .SetBaseUri(UriManager.SGAP_AdRequest_Send)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetRequestContentAsType<Bluevia.Core.KeyValueUrl>(adrequest.ToHttpQueryString())
                .AddAcceptableStatus(201)
                .SetCallback(resp => { adresponse = resp.ParseXml<Bluevia.SGAP.Schemas.SimpleAdResponseType>(); })
                .Call();

            Bluevia.SGAP.Schemas.SimpleAdResponse simpleAdResponse = SimplifyAdResponse(adresponse);

            return simpleAdResponse;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends AdRequest using SGAP protocol. In this overload it's given a chance to make a TwoleggedOauth request </summary>
        /// <remarks>   22/08/2010. </remarks>
        /// <param name="adrequest">    The (simple) adrequest. </param>
        /// <param name="twoLegged">    the boolean that marks the request as twoLegged </param>
        /// <returns>   Ad Resource received contained in a SimpleAdResponse. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.SGAP.Schemas.SimpleAdResponse Send(Bluevia.SGAP.Schemas.SimpleAdRequest adrequest, bool twoLegged)
        {
            if (twoLegged)
            {
                callBuilder.EnableTwoLeggedAuth();
            }
            return Send(adrequest);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert complex adResponse object in a collection of SimpleCreativeElements.
        /// </summary>
        /// <param name="adresponse">A complex adResponse</param>
        /// <returns>A collection of SimpleCreativeElements</returns>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////
        private Bluevia.SGAP.Schemas.SimpleAdResponse SimplifyAdResponse(Bluevia.SGAP.Schemas.SimpleAdResponseType adresponse)
        {
            Bluevia.SGAP.Schemas.SimpleAdResponse response = new Bluevia.SGAP.Schemas.SimpleAdResponse();
            foreach (CreativeElementType cet in adresponse.ad.resource.creative_element)
            {
                Bluevia.SGAP.Schemas.SimpleCreativeElement sce = new Bluevia.SGAP.Schemas.SimpleCreativeElement();
                sce.type_name = cet.type;
                sce.type_id = adresponse.ad.resource.ad_presentation;
                foreach (AttributeType attribute in cet.attribute)
                {
                    if (("text".Equals(sce.type_name.ToLower())
                        && attribute.type.ToLower().Equals("adtext")) ||
                        ("image".Equals(sce.type_name.ToLower())
                        && attribute.type.ToLower().Equals("locator")))
                    {
                        sce.value = attribute.Value;
                        break;
                    }
                }
                sce.interaction = cet.interaction.ElementAt(0).attribute.ElementAt(0).Value;
                response.CreativeElements.Add(sce);
            }
            return response;
        }
    }
}
