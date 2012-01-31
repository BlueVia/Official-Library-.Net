// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core;

namespace Bluevia.SMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This class defines the information needed to make a SMS sending. Following the Schemas.cs/SMSTextType
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class SMSTextType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Clear constructor. Data must be filled.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SMSTextType () {}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Second constructor.
        /// </summary>
        /// <param name="destinations">An string array with the destination numbers, alias, ...</param>
        /// <param name="message">The test message</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SMSTextType(string[] destinations, string message)
        {
            this.message = message;

            if (destinations == null) destinations = new string[0];
            List<UserIdType> destinationsList = new List<UserIdType>();
            foreach (var destination in destinations)
            {
                destinationsList.Add(new SMS.Schemas.UserIdType() { Item = destination, ItemElementName = SMS.Schemas.ItemChoiceType1.phoneNumber });
            }
            address = destinationsList.ToArray();
            originAddress = new SMS.Schemas.UserIdType() { Item = BlueviaConsumer.TokenManager.getActiveToken(), ItemElementName = SMS.Schemas.ItemChoiceType1.alias };
        }


    }

}
