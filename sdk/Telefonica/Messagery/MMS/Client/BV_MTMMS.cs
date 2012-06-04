// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;

namespace Bluevia.Messagery.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_MTMMS.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Mobile terminated MMS, to send MMS and retrieve status with the
    /// <a href=""> BlueVia MMS service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_MTMMS : BV_MTMMSClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_MTMMS"/>.3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">The final customer Identifier</param>
        /// <param name="tokenSecret">The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_MTMMS(BVMode mode, string consumer, string consumerSecret, string token, string tokenSecret)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(tokenSecret))
            {
                throw new Bluevia.Core.Schemas.BlueviaException(
                    "Null or Empty tokens when creating MTMMS Client. Two legged mode is not available in MTMMS."
                    , Bluevia.Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows to send and MMS to the Bluevia endpoint. And offers to check the delivery status,
        /// following a notification strategy.</summary>
        /// <param name="destination">The address of the recipient of the message.</param>
        /// <param name="subject">The subject of the mms to send.</param>
        /// <param name="message">Optional: A text message that will be sent as a text attachment.</param>
        /// <param name="attachments">Optional: List of attachments to be sent.</param>
        /// <param name="endpoint"> Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the mmsId of the MMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(string destination, string subject
            , string message = null, Schemas.Attachment[] attachments = null
            , string endpoint = null, string correlator = null)
        {
            return base.SendProcess(new string[] { destination }, subject
                , new MMS.Schemas.UserIdType()
            { Item = connector.GetToken(), ItemElementName = MMS.Schemas.ItemChoiceType1.alias }
                , null, null
                , message, attachments
                , endpoint, correlator);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows to send and MMS to the Bluevia endpoint. And offers to check the delivery status,
        /// following a notification strategy.</summary>
        /// <param name="destination">Array of address of the recipients of the message.</param>
        /// <param name="subject">The subject of the mms to send.</param>
        /// <param name="message">Optional: A text message that will be sent as a text attachment.</param>
        /// <param name="attachments">Optional: List of attachments to be sent.</param>
        /// <param name="endpoint"> Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>It returns a String containing the mmsId of the MMS sent. To poll for delivery status.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(string[] destination, string subject
            , string message = null, Schemas.Attachment[] attachments = null
            , string endpoint = null, string correlator = null)
        {
            return base.SendProcess(destination, subject
                , new MMS.Schemas.UserIdType()
            { Item = connector.GetToken(), ItemElementName = MMS.Schemas.ItemChoiceType1.alias }
                , null, null
                , message, attachments
                , endpoint, correlator);
        }
    }
}
