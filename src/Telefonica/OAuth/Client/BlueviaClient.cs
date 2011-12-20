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

namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client for OAuth operations. </summary>
    /// <remarks>   03/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class BlueviaClient : BaseClient, Bluevia.OAuth.Client.IBlueviaClient 
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        public IAccessToken AccessToken { get { return new AccessToken(); } }
        public IRequestToken RequestToken { get { return new Bluevia.OAuth.Client.RequestToken(callBuilder); } }
    }
}
