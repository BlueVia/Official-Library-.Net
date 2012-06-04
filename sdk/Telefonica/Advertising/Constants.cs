// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Advertising
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Advertising Constants, including the definition of Advertising enumerators.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Constants
    {
        public static readonly string apiAdvertising = "/REST/Advertising{0}";

        public static readonly string AdvertisingAdRequestSend = "/simple/requests";

        public static readonly string XPhoneKey = "X-PhoneNumber";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>It indicates the format of the ad you are requesting.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum TypeId
    {
        /// <summary>Value to request an Advertising image.</summary>
        image = 1,

        /// <summary>Value to request an Advertising text.</summary>
        text = 2
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>The protection policy that the retrived advertising must follow.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum ProtectionPolicy
    {

        /// <summary>Moderately explicit content (I am youth; you can show me moderately explicit content). 
        /// This is the default value if you don't include this parameter.</summary>
        low = 1,

        /// <summary>Not rated content (I am a kid, please, show me only safe content).</summary>
        safe = 2,

        /// <summary>Explicit content (I am an adult; 
        /// I am over 18 so you can show me any content including very explicit content).</summary>
        high = 3
    }
}
