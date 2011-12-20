// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Schemas
{
    public class MIMEContent
    {
        public byte[] Content { get; set; }

        public System.Net.Mime.ContentType ContentType { get; set; }

        public string Name { get; set; }

        public string Encoding { get; set; }
    }
}
