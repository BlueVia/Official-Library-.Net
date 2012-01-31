using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.MMS.Schemas; //Loading the Bluevia MMS objects

namespace BlueviaExamples
{
    class Example_MMS_MO : Example
    {
        public string getDescription()
        {
            return ("This Example sends a MMS to a shortCode, retrieves the list of the inbox, and then retrieves a full message.\n"+
                "As in sandbox mode, the attachments aren't listed, the code for this option is commented.\n"+
                "NOTE THAT YOU HAVE TO WRITE A VALID PATH TO A .JPG FILE IN THE SOURCE CODE");
        }

        public void call()
        {
            //FIRST: configuring the consumer data:
            Bluevia.Core.Configuration.Client.setConsumer("vw12012654505986");
            Bluevia.Core.Configuration.Client.setConsumerSecret("WpOl66570544");

            //SECOND: creating the bluevia's client
            BlueviaClient client = new BlueviaClient();

            //THIRD: Creating a request over the client:
            IBlueviaClient request = client.CreateRequest();

            //FOURTH: Athenticating the request is not necessary in MMS_MO, but for Message Sending
            Bluevia.Core.Configuration.Client.setTokenPair("ad3f0f598ffbc660fbad9035122eae74", "4340b28da39ec36acb4a205d3955a853");
            //Creating an authenticated request:
            IBlueviaClient authenticatedRequest = request.AuthenticateClient();

            //FIFTH: Now, we are ready to make the petition:

            //Changing the operational mode of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);


            ///////////////////////////////////////////////////////////////////////
            try
            {

                //SENDING AN MMS
                var responseS = authenticatedRequest.MMS.MessageMT.Send(new String[] { "546780" }, "SANDBLUEDEMOS This is a Dummie MMS Subject for MMS_MO"

                    //TYPE THE PATH TO THE jpeg FILE
                    ,new FileAttachment("Your pic path, i.e.:'D:\\pic.jpg'", Bluevia.MMS.Schemas.MMSContentTypes.jpeg)
                    );

                //GETTING THE MESSAGES LIST
                var response = request.MMS.MessageMO.GetMessages("546780", true);

                String messageIdentifier = null;
                String attachmentIdentifier = null;
                String attachmentType = null;
                try
                {
                    Console.WriteLine("The response from Bluevia for the Example_MMS_MO when retrieving the list is:\n");
                    Console.WriteLine("There are: " + response.receivedMessages.Length + " messages");
                    messageIdentifier = response.receivedMessages[0].messageIdentifier;
                    Console.WriteLine("With id: " + messageIdentifier);

                    //THE FOLLOWING CODE WILL BE USED TO RETRIEVE A SINGLE ATTACHMENT:
                    /*try
                    {     
                        attachmentIdentifier = response.receivedMessages[0].attachmentURL[0].href;
                        attachmentType = response.receivedMessages[0].attachmentURL[0].contentType;

                        //Showing Response
                        Console.WriteLine("The message 0: " + messageIdentifier + ", First attachment is:" + attachmentIdentifier + ", " + attachmentType);

               
                        //GETTING AN ATTACHMENT
                        var response2 = request
                             .MMS.MessageMO.GetAttachment("546780", messageIdentifier, attachmentIdentifier);

                        //Showing Response
                        Console.WriteLine("The response from Bluevia for the Example_MMS_MO when retrieving the attachment is:\n");
                        Console.WriteLine(response2.Name + ", " + response2.ContentType);
                    }
                    catch (Exception emm)
                    {
                        Console.WriteLine("The attachment has not be found.\n");
                    }
                    */

                    //IN SANDBOX MODE, THE ATTACHMENT LIST WILL BE EMPTY, SO LETS RETRIVE THE ATTACHMENT BY THE GETMESSAGE WAY
                    Console.WriteLine("Note that in sandbox mode, the attachments wouldn't be listed,\n" +
                    "so, a single attachment could't be retrieve.\n" +
                    "instead of that, the whole message will be retrieved.");

                    //TO RETRIVE A SINGLE MESSAGE:
                    try
                    {
                        //GETTING THE FULL MESSAGE             
                        var response3 = request
                             .MMS.MessageMO.GetMessage("546780", messageIdentifier);

                        /*Showing Response*/
                        Console.WriteLine("\n The response from Bluevia for the Example_MMS_MO when retrieving the full message is:\n");
                        Console.WriteLine("Subject: " + response3.messageInfo.subject);
                        Console.WriteLine("Number of attachments: " + response3.contents.Count);
                        Console.WriteLine("Number of attachments: " + response3.contents[0].Name);

                    }
                    catch (Exception emm)
                    {
                        Console.WriteLine("The message has not be found.\n");
                        throw emm;
                    }
                }
                catch (Exception em)
                {
                    Console.WriteLine("No messages or attachments where found.\n");
                    throw em;
                }

            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_MMS_MO has failed:\n");
                if (e.ClientException != null)
                {
                    Console.WriteLine("The ClientException is:" + e.ClientException.text);
                }
                else
                {
                    Console.WriteLine("The ServerException is:" + e.ServerException.text);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Example_MMS_MO has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
