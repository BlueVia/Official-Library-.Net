// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.SMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="SMSMessage.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This class defines a received answer part of the GetMessages().</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SMSMessage
    {
        /// <value>The destination of the received message.</value>
        public string destination;

        /// <value>The text message.</value>
        public string message;

        /// <value>The sender address of the message (Token or phone number).</value>
        public string originAddress;

        /// <value>The date and time when the message was sent.</value>
        public string date;
    }
}
