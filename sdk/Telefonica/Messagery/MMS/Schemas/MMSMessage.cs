// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MIMEContent.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This class defines the received answer of the GetMessage().</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MMSMessage
    {
        /// <value>Object which contains the MMS info.</value>
        public MessageType messageInfo;

        /// <value>List of MIMEContens each one with the attachment data.</value>
        public List<MIMEContent> contents;
    }
}
