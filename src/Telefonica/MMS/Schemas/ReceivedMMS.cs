using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core.Schemas;

namespace Bluevia.MMS.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This class defines the received answer of the MMS.MessageMO.GetMessage()
    ///     And the methods to parse the answer.
    ///     
    ///     Contains a Schemas.MessageType object which contains the MMS info.
    ///     Contains a List of MIMEContens each one with the attachment data
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ReceivedMMS
    {
        public MessageType messageInfo;
        public List<Bluevia.Core.Schemas.MIMEContent> contents;
        private string boundary;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructos which builds the ReceivedMMS object with the received response data og MessageMO.GetMessage </summary>
        /// <remarks>   19/05/2011. </remarks>
        /// <param name="message"> the body of the response. </param>
        /// <param name="boundary"> the boundary tag of the response. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ReceivedMMS(string message, string boundary)
        {
            this.boundary = boundary;
            messageInfo = new MessageType();
            parseMessageReferenceType(message);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Builds the Received MMS</summary>
        /// <remarks>   19/05/2011. </remarks>
        /// <param name="message"> the body of the response. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void parseMessageReferenceType(string message)
        {
            string head;
            string body;
            int firstOfHead = message.IndexOf("<NS1:");
            int lastOfHead = message.IndexOf("</NS1:message>");

            head = message.Substring(firstOfHead, (lastOfHead - firstOfHead));
            head = string.Concat(head, "</NS1:message>");
            body = message.Substring(firstOfHead + head.Length);

            try
            {

                messageInfo = Bluevia.Core.Parser.ParseXml<MessageType>(head);
                parseMMSMIMEContent(body);

            }
            catch (Exception e)
            {
                throw new Exception(String.Concat("Error while parsing the received MMS: ", e));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fills the list of attachments whith the attachments of the received MMS. </summary>
        /// <remarks>   20/05/2011. </remarks>
        /// <param name="message"> the Multipart message. </param>
        /// <param name="boundary"> the boundary. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void parseMMSMIMEContent(string message)
        {

            if (message.Contains("multipart/"))
            {
                if (message.Contains("multipart/related"))
                {
                    message = message.Substring(message.IndexOf("multipart/related"));//Finding multipart string

                    message = message.Substring(message.IndexOf("boundary=") + 9);//Reaching to the multipart boundary
                    if (message.StartsWith("\""))
                    {
                        message.Remove(0, 1);
                        boundary = message.Substring(0, message.IndexOf("\""));//Saving Multipart boundary
                    }
                    else
                    {
                        boundary = message.Substring(0, message.IndexOf("\n") - 1);//Saving Multipart boundary
                    }

                    message = message.Substring(boundary.Length);//Preparing the message for the parser
                }
                else
                {
                    message = message.Substring(message.IndexOf("multipart/mixed"));//Finding multipart string
                    message = message.Substring(message.IndexOf("boundary=") + 9);//Reaching to the multipart boundary
                    boundary = message.Substring(0, message.IndexOf("\n") - 1);//Saving Multipart boundary
                    message = message.Substring(boundary.Length);//Preparing the message for the parser
                }
                try
                {
                    contents = Bluevia.Core.Parser.ParseAttachments(message, boundary);
                }
                catch (Exception e)
                {
                    throw new Exception(String.Concat("Error parsing a multipart/related attachment list: ", e));
                }
            }
            else
            {

                try
                {
                    contents = Bluevia.Core.Parser.ParseAttachments(message, boundary);
                }
                catch (Exception e)
                {
                    throw new Exception(String.Concat("Error parsing an attachment list: ", e));
                }
            }
        }
    }
}
