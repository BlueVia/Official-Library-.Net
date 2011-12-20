// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the Terminal that is being used by a certain User.  </summary>
    /// <remarks>   04/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface ITerminalInfo
    {
        Bluevia.Directory.Schemas.UserTerminalInfoType Get();
        Bluevia.Directory.Schemas.UserTerminalInfoType Get(Bluevia.Directory.Schemas.TerminalInfoFields fields);
    }
}
