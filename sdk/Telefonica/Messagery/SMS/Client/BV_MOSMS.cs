// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;

namespace Bluevia.Messagery.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MOSMS.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Mobile originated SMS, to request MO SMS info from the
    /// <a href=""> BlueVia SMS service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MOSMS : BV_MOSMSClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_MOSMS"/>.2 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_MOSMS(BVMode mode, string consumer, string consumerSecret)
        {
            InitUntrusted(mode, consumer, consumerSecret);
        }
    }
}
