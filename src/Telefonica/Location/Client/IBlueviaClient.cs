// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Location.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client interface regarding Location api. </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IBlueviaClient
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///  Service operations to retrieve location and distance information 
        ///  of a terminal or a group of terminals
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////
        ITerminalLocation TerminalLocation { get; }
        
    }
}
