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
using Bluevia.Directory.Client;

namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client for Directory operations. </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BlueviaClient : BaseClient, Bluevia.Directory.Client.IBlueviaClient
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager for information describing the access to the network. </summary>
        /// <value> AccessInfo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IAccessInfo AccessInfo { get { return new AccessInfo(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the information describing the User Profile. </summary>
        /// <value> ProfileInfo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IProfile ProfileInfo { get { return new Profile(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the information describing the Terminal. </summary>
        /// <value> TerminalInfo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ITerminalInfo TerminalInfo { get { return new TerminalInfo(callBuilder); } }

    }
}
