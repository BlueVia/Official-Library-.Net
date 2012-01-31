// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.SGAP.Schemas
{
    /// <summary>
    /// 1 – low. Moderately explicit content (I am youth; you can show me moderately explicit content).
    /// 2 – safe. Not rated content. (I am a kid, please, show me only safe content) 
    /// 3 – high. Explicit content. (I am an adult; I am over 18 so you can show me any content including very explicit content).
    /// </summary>
    public enum ProtectionPolicy
    {
        low = 1,
        safe = 2,
        high = 3
    }
}
