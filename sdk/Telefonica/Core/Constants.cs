// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core
{
    //Constants relative to Bluevia Http, are specified in Core.Tools.HttpTools
    //Constants relative to Bluevia OAuth, are specified in Core.Tools.OauthTools
    //Constants relative to Bluevia Exceptions, are specified in Core.Schemas.Exception
    //Constants relative to each Bluevia Api, are specified in Api.Constants

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Bluevia Constants, including the definition of Bluevia enumerators.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Constants
    {
        public static readonly string blueviaURLBase = "https://api.bluevia.com/services{0}";

        public static readonly string authoriseHostTest = "https://bluevia.com/test-apps/authorise?oauth_token={0}";
        public static readonly string authoriseHostLive = "https://connect.bluevia.com/authorise?oauth_token={0}";
        public static readonly int blueviaTimeout = 20000;//20 seconds

        public static readonly string blueviaRPCAccessVersionKey = "version";
        public static readonly string blueviaRPCAccessVersion = "v1";

        public static readonly string blueviaVersionKey = "version";
        public static readonly string blueviaVersion = "v1";

        public static readonly string spaceNameCommon = "http://www.telefonica.com/schemas/UNICA/REST/common/v1";
        public static readonly string spaceNameDirectory = "http://www.telefonica.com/schemas/UNICA/REST/directory/v1/";
        public static readonly string spaceNameMMS = "http://www.telefonica.com/schemas/UNICA/REST/mms/v1/";
        public static readonly string spaceNameSMS = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/";
        
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary><a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">BVMode.</a></summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum BVMode
    {
        /// <summary>
        /// In Live mode your application uses the real network, which means that you will be able to send 
        /// real transactions to real Movistar, O2 and Vivo customers in the applicable country.
        /// This is the mode to use when your application is ready for end users.
        /// </summary>
        LIVE,

        /// <summary>
        /// The Sandbox mode offers you the exact same experience as the Live environment 
        /// except that no traffic is generated on the live network, 
        /// meaning you can experiment and play until your heart’s content. 
        /// </summary>
        SANDBOX,

        /// <summary>
        /// In Live mode your application also uses the real network, but BlueVia offers 
        /// a bundle of SMS and MMS API credits to ensure you can familiarise yourself 
        /// with our Live SMS and MMS APIs free of charge.  
        /// </summary>
        TEST,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html#sec9.html">Web Access Method.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum WebMethod
    {
        /// <summary>Related to the CRUD's Retrieve.</summary>
        Get = 0,
        /// <summary>Related to the CRUD's Create.</summary>
        Post = 1,
        /// <summary>Related to the CRUD's Delete.</summary>
        Delete = 2,
        /// <summary>Related to the CRUD's Update.</summary>
        Put = 3,
    }
}
