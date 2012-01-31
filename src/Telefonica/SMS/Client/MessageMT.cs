// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Linq;
using Bluevia.Core;
using CoreSchemas = Bluevia.Core.Schemas;
using UriManager = Bluevia.Core.Configuration.UriManager;

namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This functional block covers the manage the  functionality to send and schedule various types of Short Messages
    ///     and to subsequently poll for delivery status. 
    /// </summary>
    /// <remarks>   19/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MessageMT : BaseClient, Bluevia.SMS.Client.IMessageMT
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   , 05/09/2010. </remarks>
        ///
        /// <param name="builder">  The builder. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MessageMT(IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The application invokes the sendSms operation to send an SMS message. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="message">  The message. </param>
        /// <returns>   
        ///     Informs of the success or error in the operation and returns a request identification. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(Schemas.SMSTextType message)
        {

            Uri resource = null;
            callBuilder
                .SetMethod(CoreSchemas.WebMethod.Post)
                .SetBaseUri(UriManager.SMS_MessageMT_Send)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetRequestContentAsType<Schemas.SMSTextType>(message)
                .AddAcceptableStatus(201)
                .SetCallback(resp => { resource = resp.HeadersLocation(); })
                .Call();

            return resource.Segments.BeforeLast().Trim('/');
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The application invokes the sendSms operation to send an SMS message
        /// </summary>
        /// <remarks>   04/11/2010. </remarks>
        /// <param name="destinationAddress">     List of Destination addresses. </param>
        /// <param name="smsText">                Message content. </param>
        /// <returns>   
        /// Informs of the success or error in the operation and returns a request identification. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(string[] destinationAddress, string smsText)
        {
            Bluevia.SMS.Schemas.SMSTextType sms = new SMS.Schemas.SMSTextType(destinationAddress, smsText);
            return Send(sms);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// The application invokes the GetStatus operation to request the status of a previous SMS
        /// delivery request identified by messageId. The information on the status is returned in
        /// SmsDeliveryStatusType, which is an array of status related to the request identified by
        /// MessageId. The status is identified by a couple indicating a user address and the associated
        /// delivery status. This method can be invoked multiple times by the application even if the
        /// status has reached a final value. However, after the status has reached a final value, status
        /// information will be available only for a limited period of time as defined by a service
        /// policy. 
        /// </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="messageId">    It identifies a specific SMS delivery request. </param>
        /// <returns>   Informs of the success or error in the operation and returns the delivery status. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.SMSDeliveryStatusType GetStatus(string messageId)
        {
            Schemas.SMSDeliveryStatusType smsDeliveryStatus = null;
            callBuilder
                .SetMethod(CoreSchemas.WebMethod.Get)
                .SetBaseUri(UriManager.SMS_MessageMT_GetStatus.FormatWithInvariantCulture(messageId))
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { smsDeliveryStatus = resp.ParseXml<Schemas.SMSDeliveryStatusType>(); })
                .Call();

            return smsDeliveryStatus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// The application invokes the GetStatus operation to request the status of a previous SMS
        /// delivery request identified by messageId. The information on the status is returned in
        /// SmsDeliveryStatusType, which is an array of status related to the request identified by
        /// MessageId. The status is identified by a couple indicating a user address and the associated
        /// delivery status. This method can be invoked multiple times by the application even if the
        /// status has reached a final value. However, after the status has reached a final value, status
        /// information will be available only for a limited period of time as defined by a service
        /// policy. 
        /// </summary>
        ///
        /// <remarks>   19/04/2010. </remarks>
        ///
        /// <param name="messageId">    Identifier for the message. </param>
        /// <param name="status">       [out] Delivery status. </param>
        ///
        /// <returns>   
        /// Informs of the success or error in the operation and returns the delivery status. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.SMSDeliveryStatusType GetStatus(string messageId, out string status)
        {
            var returned = GetStatus(messageId);
            status = returned.smsDeliveryStatus.FirstOrDefault().deliveryStatus;
            return returned;
        }

    }
}
