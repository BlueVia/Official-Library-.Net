// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 


using Bluevia.Core;

namespace Bluevia.Messagery.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MTSMS.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Mobile terminated SMS, to send SMS and retrieve status with the
    /// <a href=""> BlueVia MMS service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MTSMS : BV_MTSMSClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_MTSMS"/>.3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">The final customer Identifier</param>
        /// <param name="tokenSecret">The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_MTSMS(BVMode mode, string consumer, string consumerSecret, string token, string tokenSecret)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(tokenSecret))
            {
                throw new Bluevia.Core.Schemas.BlueviaException(
                    "Null or Empty tokens when creating MTSMS Client. Two legged mode is not available in MTSMS."
                    , Bluevia.Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows to send and SMS to the Bluevia endpoint. And offers to check the delivery status,
        /// following a notification strategy.</summary>
        /// <param name="destination">The address of the recipient of the message.</param>
        /// <param name="text">The message text to send.</param>
        /// <param name="endpoint"> Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the smsId of the SMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(string destination, string text, string endpoint = null, string correlator = null)
        {
            return base.SendProcess(new string[] { destination }, text
                , new SMS.Schemas.UserIdType()
                { Item = connector.GetToken(), ItemElementName = SMS.Schemas.ItemChoiceType1.alias }
                , null, null
            , endpoint, correlator);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows to send and SMS to the Bluevia endpoint. And offers to check the delivery status,
        /// following a notification strategy.</summary>
        /// <param name="destination">Array of address of the recipients of the message.</param>
        /// <param name="text">The message text to send.</param>
        /// <param name="endpoint"> Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the smsId of the SMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string Send(string[] destination, string text, string endpoint = null, string correlator = null)
        {
            return base.SendProcess(destination, text
                , new SMS.Schemas.UserIdType()
                { Item = connector.GetToken(), ItemElementName = SMS.Schemas.ItemChoiceType1.alias }
                , null, null
            , endpoint, correlator);
        }
    }
}
