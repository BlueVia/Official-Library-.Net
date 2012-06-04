// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;

using Bluevia.Messagery.Schemas;
using Bluevia.Messagery.MMS.Schemas;

namespace Bluevia.Messagery.MMS.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MMSSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of MMS API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class MMSSimplifiers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex ReceivedMessagesType object, into a MMSMessageInfos array.</summary>
        /// <param name="receivedMessagesType">A complex ReceivedMessagesType.</param>
        /// <returns>An array of simplified MMSMessageInfos.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static MMSMessageInfo[] SimplifyReceivedMessagesType(ReceivedMessagesType receivedMessagesType)
        {
            //CAN BE IMPROVED
            //This function could be implemented with a for loop, to save the List instantiation

            List<MMSMessageInfo> messageList = new List<MMSMessageInfo>();
            if (receivedMessagesType != null)
            {
                MMSMessageInfo temp = null;

                //Simplifying the response
                foreach (var receivedMessage in receivedMessagesType.receivedMessages)
                {
                    temp = new MMSMessageInfo()
                    {
                        messageId = receivedMessage.messageIdentifier,
                        destination = (string)receivedMessage.destinationAddress.Item,
                        subject = receivedMessage.subject,
                        originAddress = (string)receivedMessage.originAddress.Item,
                        date = Convert.ToString(receivedMessage.dateTime)
                    };
                    //if (attachUrl)
                    if (receivedMessage.attachmentURL!= null && receivedMessage.attachmentURL.Length > 0)
                    {
                        List<AttachmentInfo> attachmentList = new List<AttachmentInfo>();
                        AttachmentInfo tempAttach = null;
                        foreach (var attach in receivedMessage.attachmentURL)
                        {
                            tempAttach = new AttachmentInfo(attach.href, attach.contentType);
                            attachmentList.Add(tempAttach);
                        }
                        temp.attachmentInfos = attachmentList.ToArray();
                    }
                    messageList.Add(temp);
                }
            }
            return messageList.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex MessageDeliveryStatusType object, into a DeliveryInfos array.</summary>
        /// <param name="messageDeliveryStatusType">A complex MessageDeliveryStatusType.</param>
        /// <returns>An array of simplified DeliveryInfos.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DeliveryInfo[] SimplifyMessageDeliveryStatusType(MessageDeliveryStatusType messageDeliveryStatusType)
        {
            //CAN BE IMPROVED
            //This function could be implemented with a for loop, to save the List instantiation

            List<DeliveryInfo> deliveryInfoList = new List<DeliveryInfo>();
            DeliveryInfo temp = null;
            //Simplifying the response
            foreach (var status in messageDeliveryStatusType.messageDeliveryStatus)
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
