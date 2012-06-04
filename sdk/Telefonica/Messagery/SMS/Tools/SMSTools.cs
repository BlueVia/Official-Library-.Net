// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

namespace Bluevia.Messagery.SMS.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="SMSTools.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Additional static methods to serve to the API main classes.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class SMSTools
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Funtion to build a full SMSTextType, from simple fields.</summary>
        /// <param name="text">The message text to send.</param>
        /// <param name="originAddress">The sender's phone Number.</param>
        /// <param name="senderName">Human-readable text for remitent.</param>
        /// <param name="reference">The Endpoint and correlator in a complex object.</param>
        /// <param name="destination">Array of address of the recipients of the message.</param>
        /// <returns>A SMSTextType, ready to be serialized and sent.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Schemas.SMSTextType CreateSMSTextType(string text, SMS.Schemas.UserIdType originAddress
            , string senderName, SMS.Schemas.SimpleReferenceType reference, string[] destination)
        {
            List<SMS.Schemas.UserIdType> destinationsList = new List<SMS.Schemas.UserIdType>();
            foreach (string dest in destination)
            {
                Core.Tools.Extension.checkIsNumber(dest, "destination");
                destinationsList.Add(new SMS.Schemas.UserIdType()
                {
                    Item = dest
                    ,
                    ItemElementName = SMS.Schemas.ItemChoiceType1.phoneNumber
                });
            }
            Schemas.SMSTextType smsTextType = new Schemas.SMSTextType();

            smsTextType.address = destinationsList.ToArray();
            smsTextType.originAddress = originAddress;
            smsTextType.message = text;
            smsTextType.senderName = senderName;
            smsTextType.receiptRequest = reference;
            return smsTextType;
        }
    }
}
