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

namespace Bluevia.Location.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client for Location. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BlueviaClient : BaseClient, Bluevia.Location.Client.IBlueviaClient
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager for location. </summary>
        /// <value> The location manager. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ITerminalLocation TerminalLocation { get { return new TerminalLocation(callBuilder); } }
    }
}
