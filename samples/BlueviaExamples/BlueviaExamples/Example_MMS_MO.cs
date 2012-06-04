// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Messagery.MMS;
using Bluevia.Messagery.MMS.Client; //Loading the Bluevia Api clients
using Bluevia.Messagery.MMS.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_MMS_MO.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> MMS Mobile's originated api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_MMS_MO : IExample
    {
        public string getDescription()
        {
            return ("This Example sends a MMS to a shortCode, retrieves the list of the inbox, and then retrieves a full message.\n"+
                "As in sandbox mode, the attachments aren't listed, the code for this option is commented.\n"+
                "NOTE THAT YOU HAVE TO WRITE A VALID PATH TO A .JPG FILE IN THE SOURCE CODE");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the MMS  clients:
            BV_MTMMS clientMT = new BV_MTMMS(BVMode.SANDBOX, consumer, ckey, token, secret);
            BV_MOMMS clientMO = new BV_MOMMS(BVMode.SANDBOX, consumer, ckey);

            //SECOND: Making the petitions:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            MMSMessageInfo[] inboxMessages = null;
            string messageIdentifier = null;
            MMSMessage message = null;
            try
            {

                //SENDING AN MMS
                clientMT.Send(
                    destination: "546780", //MANDATORY
                    subject: "SANDBLUEDEMOS This is a Dummie MMS Subject for MMS_MO", //MANDATORY
                    message: "Optional text attachment", //Optional
                    attachments: new Attachment[] //Optional
                    {
                        //TYPE THE PATH TO THE jpeg FILE
                        new Attachment("D:\\pic.jpg", MIMEType.jpeg)
                    },
                    endpoint: null, //Optional
                    correlator: null //Optional
                    );


                //GETTING THE MESSAGES LIST
                inboxMessages = clientMO.GetAllMessages(
                    registrationId: "546780", //MANDATORY
                    attachUrl: false //Optional
                    );
                try
                {
                    messageIdentifier = inboxMessages[0].messageId;
                }
                catch (Exception em)
                {
                    Console.WriteLine("\n No messages where found.\n");
                    Console.WriteLine(em.Message);
                    return;
                }

                Console.WriteLine("\nThe response from Bluevia for the Example_MMS_MO when retrieving the list is:\n");
                Console.WriteLine("There are: " + inboxMessages.Length + " messages");
                Console.WriteLine("With id: " + messageIdentifier);

                //THE FOLLOWING CODE CAN BE USED TO RETRIEVE A SINGLE ATTACHMENT WHEN attachUrl = True:
                
                /*string attachmentIdentifier = inboxMessages[0].attachmentInfos[0].url;
                string attachmentType = inboxMessages[0].attachmentInfos[0].contentType;

                //Showing Response
                Console.WriteLine("The message 0: " + messageIdentifier + ", First attachment is:" + attachmentIdentifier + ", " + attachmentType);

               
                //GETTING AN ATTACHMENT
                MIMEContent attachment = clientMO.GetAttachment(
                    registrationId: "546780", //MANDATORY
                    messageId: messageIdentifier, //MANDATORY
                    attachmentId: attachmentIdentifier //MANDATORY
                    );
                

                //Showing Response
                Console.WriteLine("The response from Bluevia for the Example_MMS_MO when retrieving the attachment is:\n");
                Console.WriteLine(attachment.name + ", " + attachment.contentType);
                */

                //IN SANDBOX MODE, THE ATTACHMENT LIST WILL BE EMPTY, SO LETS RETRIVE THE ATTACHMENT BY THE GETMESSAGE WAY
                Console.WriteLine("\nNote that in sandbox mode, the attachments wouldn't be listed,\n" +
                "so, a single attachment could't be retrieve.\n" +
                "instead of that, lets retrieve a whole message.");

                //GETTING THE FULL MESSAGE      
                message = clientMO.GetMessage(
                    registrationId: "546780", //MANDATORY
                    messageId: messageIdentifier //MANDATORY
                    );

                /*Showing Response*/
                Console.WriteLine("\n The response from Bluevia for the Example_MMS_MO when retrieving the full message is:\n");
                Console.WriteLine("Subject: " + message.messageInfo.subject);
                Console.WriteLine("Number of attachments: " + message.contents.Count);
                Console.WriteLine("Name of first attachment: " + message.contents[0].name);
                Console.WriteLine("MimeType of first attachment: " + message.contents[0].contentType);
                Console.WriteLine("The first attachment is a text, so lets print it: \n" 
                    + Encoding.UTF8.GetString(message.contents[0].content)+ "\n");

                //Uncomment the following code to save the image into the disk:
                //(Maybe little modifications must be done in the file's extension).
                /*File.WriteAllBytes("D:\\" + message.contents[0].name + "." 
                    + message.contents[1].contentType.Substring(message.contents[1].contentType.IndexOf("/") + 1)
                    , message.contents[1].content);
                */
            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_MMS_MO has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_MMS_MO has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
