// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;

namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to send and schedule various types of Short Messages
    ///     and to subsequently poll for delivery status. See MessageMT class for further information.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IMessageMT
    {
        string Send(Bluevia.MMS.Schemas.MessageType message, params Core.Schemas.FileAttachment[] filePaths);
        string Send(Bluevia.MMS.Schemas.MessageType message, Bluevia.Core.Schemas.StreamAttachment[] streamAttachments);
        string Send(string[] destinationAddress, string mmsSubject, params Core.Schemas.FileAttachment[] filePaths);
        Schemas.MessageDeliveryStatusType GetStatus(string messageId);
        Schemas.MessageDeliveryStatusType GetStatus(string messageId, out string status);
    }

}
