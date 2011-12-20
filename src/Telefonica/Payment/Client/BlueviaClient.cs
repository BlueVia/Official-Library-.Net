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

namespace Bluevia.Payment.Client
{
    public class BlueviaClient : BaseClient, Bluevia.Payment.Client.IBlueviaClient
    {
        public BlueviaClient(IServiceBuilder builder) : base(builder) { }

        public IAmountCharging AmountCharging { get { return new AmountCharging(callBuilder); } }
    }
}
