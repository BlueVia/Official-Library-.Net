// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.SGAP.Schemas
{
    ///////////////////////////////////////////////////////////////////////////////////
    /// <summary> Object that defines the response of an advertising petition</summary>
    /// ////////////////////////////////////////////////////////////////////////////////
    public class SimpleAdResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clear constructor. Is filled at a response.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SimpleAdResponse() { CreativeElements = new List<SimpleCreativeElement>(); }
        public List<SimpleCreativeElement> CreativeElements { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Simplified SimpleAdResponseType
    /// </summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SimpleCreativeElement
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clear constructor.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SimpleCreativeElement() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Second constructor, used by SimplifyAdResponse method in Client/AdRequest.cs class
        /// </summary>
        /// <param name="type_id">identifier of the ad selected.</param>
        /// <param name="type_name">describes the different elements that shape the adsource. For instance a small 
        ///                         banner link in line, could have two elements (image and text)</param>
        /// <param name="value">value of adresource</param>
        /// <param name="interaction">interaction may have different attributes (such as remittent in click2call or 
        ///                           the tiny URL in SMS). It will be returned one link to the action page.</param>
        public SimpleCreativeElement(string type_id, string type_name, string value, string interaction)
        {
            this.type_id = type_id;
            this.type_name = type_name;
            this.value = value;
            this.interaction = interaction;
        }

        public string type_id { get; set; }
        public string type_name { get; set; }
        public string value { get; set; }
        public string interaction { get; set; }
    }
}
