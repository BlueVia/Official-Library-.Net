// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 
using System;
using System.Collections.Generic;

using Bluevia.Advertising.Schemas;

namespace Bluevia.Advertising.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AdvertisingSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of Advertising API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class AdvertisingSimplifiers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex adResponse object, into a collection of SimpleCreativeElements.</summary>
        /// <param name="simpleAdresponse">A complex adResponse</param>
        /// <returns>A collection of SimpleCreativeElements</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static SimpleAdResponse SimplifyAdResponse(Bluevia.Advertising.Schemas.SimpleAdResponseType simpleAdresponse)
        {
            //CAN BE IMPROVED
            //This function could be implemented with a for loop, to save the List instantiation

            List<CreativeElement> response = new List<CreativeElement>();
            foreach (CreativeElementType cet in simpleAdresponse.ad.resource.creative_element)
            {
                CreativeElement sce = new CreativeElement();
                sce.type = (TypeId)Enum.Parse(typeof(TypeId), cet.type);
                //Searching for the advertise attribute
                foreach (AttributeType attribute in cet.attribute)
                {
                    if (("text".Equals(cet.type.ToLower())
                        && attribute.type.ToLower().Equals("adtext")) ||
                        ("image".Equals(cet.type.ToLower())
                        && attribute.type.ToLower().Equals("locator")))
                    {
                        sce.value = attribute.Value;
                        break;
                    }
                }

                sce.interaction = cet.interaction[0].attribute[0].Value;
                response.Add(sce);
            }
            return new SimpleAdResponse(simpleAdresponse.id, response.ToArray());
        }

        
    }
}
