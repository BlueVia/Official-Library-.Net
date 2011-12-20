// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The Base Client that contains the ServiceBuilder. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class BaseClient
    {
        protected IServiceBuilder callBuilder;

        public BaseClient() { }

        public BaseClient (IServiceBuilder builder)
        {
            this.callBuilder = builder;
        }
    }
}
