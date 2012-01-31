// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to send and schedule various types of Short Messages
    ///     and to subsequently poll for delivery status. See MessageMT class for further information.
    /// </summary>
    /// <remarks>   19/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IMessageMT
    {
        string Send(Bluevia.SMS.Schemas.SMSTextType message);
        string Send(string[] destinationAddress, string smsText);
        Bluevia.SMS.Schemas.SMSDeliveryStatusType GetStatus(string messageId);
        Bluevia.SMS.Schemas.SMSDeliveryStatusType GetStatus(string messageId, out string status);
    }
}