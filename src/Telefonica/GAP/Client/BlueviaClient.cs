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
using Bluevia.SGAP.Schemas;

namespace Bluevia.SGAP.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client for SGAP (Advertising). </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class BlueviaClient : BaseClient, Bluevia.SGAP.Client.IBlueviaClient
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Service to request advertising. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IAdRequest AdRequest { get { return new Bluevia.SGAP.Client.AdRequest(callBuilder); } }
    }
}
