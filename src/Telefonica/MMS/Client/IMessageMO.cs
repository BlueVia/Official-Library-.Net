// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to the reception of MMSs(MMS-MO) using polling. 
    ///     See MessageMO class for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IMessageMO
    {
        Bluevia.MMS.Schemas.ReceivedMMS GetMessage(string registrationId, string messageId);
        Bluevia.MMS.Schemas.ReceivedMessagesType GetMessages(string registrationId, bool useAttachmentUrl);
        Bluevia.Core.Schemas.MIMEContent GetAttachment(string registrationId, string messageId, string attachmentId);
    }
}
