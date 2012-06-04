// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;

using Bluevia.Messagery.SMS.Schemas;
using Bluevia.Messagery.Schemas;

namespace Bluevia.Messagery.SMS.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="SMSSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of SMS API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class SMSSimplifiers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Convert complex ReceivedSMSType object in a SMSMessages array.</summary>
        /// <param name="receivedSMSType">A complex ReceivedSMSType.</param>
        /// <returns>An array of simplified SMSMessages.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static SMSMessage[] SimplifyReceivedSMSType(ReceivedSMSType receivedSMSType)
        {
            //CAN BE IMPROVED
            //This function could be implemented with a for loop, to save the List instantiation

            List<SMSMessage> messageList = new List<SMSMessage>();
            if (receivedSMSType != null)
            {
                SMSMessage temp = null;
                //Simplifying the response
                foreach (var receivedMessage in receivedSMSType.receivedSMS)
                {
                    temp = new SMSMessage()
                    {
                        destination = (string)receivedMessage.destinationAddress.Item,
                        message = receivedMessage.message,
                        originAddress = (string)receivedMessage.originAddress.Item,
                        date = Convert.ToString(receivedMessage.dateTime)
                    };
                    messageList.Add(temp);
                }
            }
            return messageList.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Convert complex SMSDeliveryStatusType object in a DeliveryInfos array.</summary>
        /// <param name="smsDeliveryStatusType">A complex SMSDeliveryStatusType.</param>
        /// <returns>An array of simplified DeliveryInfos.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DeliveryInfo[] SimplifySMSDeliveryStatusType(SMSDeliveryStatusType smsDeliveryStatusType)
        {
            //CAN BE IMPROVED
            //This function could be implemented with a for loop, to save the List instantiation

            List<DeliveryInfo> deliveryInfoList = new List<DeliveryInfo>();
            DeliveryInfo temp = null;
            //Simplifying the response
            foreach (var status in smsDeliveryStatusType.smsDeliveryStatus)
            {
                temp = new DeliveryInfo();
                temp.destination = (string)status.address.Item;
                temp.SetStatus(status.deliveryStatus);
                deliveryInfoList.Add(temp);
            }
            return deliveryInfoList.ToArray();
        }
    }
}
