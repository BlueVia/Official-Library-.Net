// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Messagery.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MultipartMessageType.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This class defines the information needed to make a MMS sending.
    /// Following the Schemas.cs/MessageType</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MultipartMessageType 
    {
        /// <value>A MMS Mesage (without attachments).</value>
        public MessageType messageType;

        /// <value>An optional message, that will be converted into a text attachment.</value>
        public string message;

        /// <value>The attachment info array.</value>
        public AttachmentInfo[] attachments;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="MultipartMessageType"/>.Clear constructor.
        /// Data must be filled.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MultipartMessageType() { }

    }
}
