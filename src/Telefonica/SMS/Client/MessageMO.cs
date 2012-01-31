// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;
using Bluevia.Core.Schemas;


namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This functional block covers the set of functionality related to the reception of SMSs
    ///     (SMS-MO) using polling. 
    /// </summary>
    /// <remarks>   19/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MessageMO : BaseClient, Bluevia.SMS.Client.IMessageMO
    {
        public MessageMO(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     The invocation of GetMessages retrieves all the SMS messages received that fullfil the
        ///     criteria identified by RegistrationId. The method returns only the list of SMS messages
        ///     received since the previous invocation of the same method, i.e. each time the method is
        ///     executed the messages returned are removed from the server. Moreover, each SMS message
        ///     will be automatically removed from the server after a maximum time interval as defined by
        ///     a service policy. 
        /// </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="registrationId">   Identifies the provisioning step that enables the application
        ///                                 to receive notification of SMS reception according to
        ///                                 specified criteria. </param>
        /// <returns>   
        ///     Informs of the success or error in the operation and provide the received SMS since last
        ///     invocation. It might return null if there are no messages to retrieve.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.ReceivedSMSType GetMessages(string registrationId)
        {
            Schemas.ReceivedSMSType receivedSMS = null;
            callBuilder
                .EnableTwoLeggedAuth()
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.SMS_MessageMO_GetMessages.FormatWithInvariantCulture(registrationId))
                .AddQueryString(Bluevia.Core.Schemas.QueryString.currentVersion)
                .SetMethod(Bluevia.Core.Schemas.WebMethod.Get)
                .AddAcceptableStatus(200, 204)
                .SetCallback(resp => { if ((int)resp.Status == 200) receivedSMS = resp.ParseXml < Schemas.ReceivedSMSType>(); })
                .Call();

            return receivedSMS;
        }
    }
}
