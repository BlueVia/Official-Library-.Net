using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.SMS.Schemas; //Loading the Bluevia SMS objects

namespace BlueviaExamples
{
    class Example_SMS_MO : Example
    {
        public string getDescription()
        {
            return ("This Example retrieves the first Message's info of an inbox.");
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

            //FOURTH: Athenticating the request is not necessary in SMS_MO, but for Message Sending
            Bluevia.Core.Configuration.Client.setTokenPair("ad3f0f598ffbc660fbad9035122eae74", "4340b28da39ec36acb4a205d3955a853");
            //Creating an authenticated request:
            IBlueviaClient authenticatedRequest = request.AuthenticateClient();

            //FIFTH: Now, we are ready to make the petition:

            //Changing the operational mode of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);


            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SENDING AN SMS
                var responseS = authenticatedRequest.SMS.MessageMT.Send(new String[] { "546780" }, "SANDBLUEDEMOS This is a Dummie SMS for SMS_MO");

                // GETTING THE MESSAGE LIST
                var response = request.SMS.MessageMO.GetMessages("546780");
                try
                {
                    Console.WriteLine("The response from Bluevia for the Example_SMS_MO when retrieving the list is:\n");
                    Console.WriteLine("There are: " + response.receivedSMS.Length + " messages");
                    Console.WriteLine("The message 0: " + response.receivedSMS[0].message);
                }
                catch (Exception em)
                {
                    Console.WriteLine("No messages where found.\n");
                    return;
                }


            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_SMS_MO has failed:\n");
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
                Console.WriteLine("Example_SMS_MO has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
