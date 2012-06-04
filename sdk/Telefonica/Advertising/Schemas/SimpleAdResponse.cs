// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Advertising.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="SimpleAdResponse.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>The advertising retrieved information object. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SimpleAdResponse
    {
        /// <value>This is a unique identifier of the relative request.</value>
        public string RequestId;

        /// <value>The Advertisings retrieved info.</value>
        public CreativeElement[] AdvertisingList;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="SimpleAdResponse"/></summary>
        /// <param name="Id">The id of the relative request sent.</param>
        /// <param name="elements">The Advertisings retrieved info.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SimpleAdResponse(string Id, CreativeElement[] elements)
        {
            RequestId = Id;
            AdvertisingList = elements;
        }
    }
}
