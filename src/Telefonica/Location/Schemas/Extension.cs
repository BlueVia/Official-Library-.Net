// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Location.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Object that contains the necessary info to make the desired petition </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class TerminalLocationParams
    {
        private string acceptableAccuracy;

        public string AcceptableAccuracy
        {
            get { return acceptableAccuracy; }
            set { acceptableAccuracy = value; }
        }
    }
}
