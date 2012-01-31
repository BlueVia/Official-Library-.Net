// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.Core
{
    public interface IOAuthToken
    {
        bool CallbackConfirmed { get; set; }
        string Token { get; set; }
        string TokenSecret { get; set; }
    }
}
