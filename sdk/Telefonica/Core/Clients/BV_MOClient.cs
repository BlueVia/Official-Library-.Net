// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Clients
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MOClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Abstract client interface for the REST binding of the Bluevia Messagery MO (MobileOriginated)
    /// Service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MOClient : BV_BaseClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Client, to work as a trusted client. 
        /// It calls the base Init function, wich creates the SSL client's certificate, the Bluevia Connector and
        /// sets the operational mode. 
        /// Then concatenates itself the MO string in the service url.</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitTrusted(BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            base.InitTrusted(mode, consumer, consumerSecret, certPath, certPasswd);
            url = string.Format(url, Messagery.Constants.serviceMO);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Client, to work as a trusted client. 
        /// It calls the base Init function, wich creates the Bluevia Connector and
        /// sets the operational mode. 
        /// Then concatenates itself the MO string in the service url.</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret,
            string token = "", string tokenSecret = "")
        {
            base.InitUntrusted(mode, consumer, consumerSecret);
            url = string.Format(url, Messagery.Constants.serviceMO);
        }
    }
}
