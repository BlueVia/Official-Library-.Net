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

namespace Bluevia.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This class defines the information needed to make a MMS sending. Following the Schemas.cs/MessageType
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class MessageType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Clear constructor. Data must be filled.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MessageType() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Second constructor.
        /// </summary>
        /// <param name="destinations">An string array with the destination numbers, alias, ...</param>
        /// <param name="subjectmessage">The test message</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MessageType(string[] destinations, string subjectmessage = null)
        {

            List<UserIdType> destinationsList = new List<UserIdType>();
            foreach (string destination in destinations)
            {
                destinationsList.Add(new UserIdType() { Item = destination, ItemElementName = ItemChoiceType1.phoneNumber });
            }

            address = destinationsList.ToArray();

            originAddress = new UserIdType() { Item = BlueviaConsumer.TokenManager.getActiveToken(), ItemElementName = ItemChoiceType1.alias };

            subject = (subjectmessage == null ? null : subjectmessage);
        }
    }
    

}
