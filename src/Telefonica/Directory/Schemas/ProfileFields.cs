// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.Directory.Schemas
{
    [Flags]
    public enum ProfileFields
    {
        userType = 1,
        icb = 2,
        ocb = 4,
        parentalControl = 8,
        operatorId = 16,
        segment = 32
    }
}
