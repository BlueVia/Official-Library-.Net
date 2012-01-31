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
    /// <summary>   
    ///     This interface defines operations to get the location of the users device.
    ///     See TerminalLocation for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface ITerminalLocation
    {
        Schemas.TerminalLocationListType GetLocation(Schemas.TerminalLocationParams terminalLocationParams);      
    }
}
