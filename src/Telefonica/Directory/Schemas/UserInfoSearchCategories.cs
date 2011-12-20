// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.Directory.Schemas
{
    [Flags]
    public enum UserInfoSearchCategories
    {
        Profile = 1,
        AccessInfo = 2,
        TerminalInfo = 4
    }
}
