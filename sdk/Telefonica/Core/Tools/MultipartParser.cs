// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Bluevia.Messagery.MMS.Schemas;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="MultipartParser.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to parse a Multipart message string(in byte arrayformat), into a MMSMessage object.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MultipartParser : IParser
    {
        MessageType messageInfo;
        List<Bluevia.Messagery.MMS.Schemas.MIMEContent> contents;
        string boundary;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to parse a MIME Multipart string, to a full object from the Bluevia Schemas</summary>
        /// <remarks>   2012/03/27. </remarks>
        /// <param name="stream">An serialized MIME Multipart into a byte array.</param>
        /// <typeparam name="T">MMSMessage.</typeparam>
        /// <returns>A full MMSMessage.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public T Parse<T>(byte[] stream)
        {
            if (stream == null)
            {
                return (T)(object)stream;
            }
            string str = Encoding.Default.GetString(stream);

            int pointer = 0;
            str = str.Substring(2);//deleting first \r\n
            pointer = str.IndexOf("\r\n");
            string boundary = str.Substring(0, pointer);
            str = str.Substring(pointer+2);//deleting first boundary and \r\n
            parseMessageReferenceType(str);
            MMSMessage receivedMMS = new MMSMessage();
            receivedMMS.messageInfo = messageInfo;
            receivedMMS.contents = contents;
            object sol = receivedMMS;
            return (T)sol;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Builds the Received MMS</summary>
        /// <remarks>19/05/2011. 
        /// 27/03/2012 class saved from old sdk</remarks>
        /// <param name="message"> the body of the response. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void parseMessageReferenceType(string message)
        {
            string head;
            string body;
            int firstOfHead = message.IndexOf("<NS1:");
            int lastOfHead = message.IndexOf("</NS1:message>");

            head = message.Substring(firstOfHead, (lastOfHead - firstOfHead));
            head = string.Concat(head, "</NS1:message>");
            body = message.Substring(firstOfHead + head.Length);

            //Creating a MessageType from the rootFiles MIME
            XMLParser xmlParser = new XMLParser();
            messageInfo = xmlParser.Parse<MessageType>(Encoding.UTF8.GetBytes(head)); 
            //Parsing the rest of MIMES
            parseMMSMIMEContent(body);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fills the list of attachments whith the attachments of the received MMS. </summary>
        /// <remarks>   20/05/2011. 
        /// 27/03/2012 class saved from old sdk</remarks>
        /// <param name="message"> the Multipart message. </param>
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
            }

            contents = ParseAttachments(message, boundary);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a Bluevia.Core.Schemas.MIMEContent from an attachment text. </summary>
        /// <remarks>   20/05/2011. 
        /// 27/03/2012 class saved from old sdk</remarks>
        /// <param name="text"> the text with the attachment data. </param>
        /// <param name="bound"> the boundary string. </param>
        /// <returns>   A MIMEContent object. </returns>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<Bluevia.Messagery.MMS.Schemas.MIMEContent> ParseAttachments(string text, string bound)
        {
            List<Bluevia.Messagery.MMS.Schemas.MIMEContent> list = new List<Bluevia.Messagery.MMS.Schemas.MIMEContent>();
            Bluevia.Messagery.MMS.Schemas.MIMEContent mime;
            string boundary = string.Format("\r\n--{0}", bound);
			
			//Splitting the attachment group into single attachments, the first and the last ones will be invalid
            string[] attachments = text.Split(new string[] { boundary }, StringSplitOptions.RemoveEmptyEntries);

			
			string headersBlock = null;
			string[] headers = null;
			string bodyBlock = null;
			int jump = 0;			
			int pointer = 0;
            string contentType;
			
			for(int i= 1; i<attachments.Length-1;i++)
			{
				mime = new Bluevia.Messagery.MMS.Schemas.MIMEContent();				
                jump = attachments[i].IndexOf("\r\n\r\n");
				
				//Extracting the attachment body (+4 = "\r\n\r\n"):
				bodyBlock = attachments[i].Substring(jump+4,attachments[i].Length-(jump+4));	

				mime.content = Encoding.Default.GetBytes(bodyBlock);
				
				//Now we have the full body, lets read the headers (2 = "\r\n"):
				headersBlock = attachments[i].Substring(2,jump);
				headers = headersBlock.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);
				
				for (int j = 0; j < headers.Length; j++)
				{
					pointer = 0;
                    if (headers[j].StartsWith("content-type", StringComparison.CurrentCultureIgnoreCase))
						{
                            if (headers[j].Contains(";"))//case more options in the same line
							{
                                string CTLine = headers[j].Substring(headers[j].IndexOf(':') + 1).Trim();
								pointer = CTLine.IndexOf(";");
								contentType = CTLine.Substring(0, pointer).Trim();
								pointer = CTLine.IndexOf("name=");
								if (pointer != -1)
								{
									mime.name = CTLine.Substring(pointer + 5);
								}
							}
							else//case contentype is alone
							{
                                contentType = headers[j].Substring(headers[j].IndexOf(':') + 1).Trim();
							}
							mime.contentType = contentType;
						}
                    else if (headers[j].StartsWith("content-transfer-encoding", StringComparison.CurrentCultureIgnoreCase))
						{
                            mime.encoding = headers[j].Substring(headers[j].IndexOf(':') + 1).Trim();
						}

						if (string.IsNullOrEmpty(mime.name))//If name didn't appeared in the content-type line:
						{
							mime.name = string.Concat("file", i);
						}
				}//Attachment headers readed
				
				list.Add(mime);
			}//Attachment saved into list
			
            return list;

        }

    }
}
