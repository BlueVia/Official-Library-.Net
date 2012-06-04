// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;

namespace Bluevia.OAuth.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_OAuth.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for OAuth (Authorization), to make the process of retrieving 
    /// authorization credentials with <a href="http://www.void.com"> BlueVia OAuth service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_OAuth : BV_OAuthClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_OAuth"/>.2 and 3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">Optional: The final customer Identifier</param>
        /// <param name="tokenSecret">Optional: The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_OAuth(BVMode mode, string consumer, string consumerSecret, string token = "", string tokenSecret ="")
        {
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }
    }
}
