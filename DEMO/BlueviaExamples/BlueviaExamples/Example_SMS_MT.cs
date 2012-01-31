﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.SMS.Schemas; //Loading the Bluevia SMS objects

namespace BlueviaExamples
{
    class Example_SMS_MT : Example
    {
        public string getDescription()
        {
            return ("This Example sends a MMS to a fake phone, and then retrieves it's Status.");
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

            //FOURTH: Athenticating the request (This step is only necessary for oauth 3legged petitions):
            Bluevia.Core.Configuration.Client.setTokenPair("ad3f0f598ffbc660fbad9035122eae74", "4340b28da39ec36acb4a205d3955a853");
            //Creating an authenticated request:
            IBlueviaClient authenticatedRequest = request.AuthenticateClient();

            //FIFTH: Now, we are ready to make the petition:

            //Changing the operational MTde of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);


            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SENDING AN SMS
                var response = authenticatedRequest.SMS.MessageMT.Send(new String[] { "54123456789" }, "This is a Dummie Message");

                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_SMS_MT when sending an SMS is:\n");
                Console.WriteLine(response + "\n");

                Console.WriteLine("Press any key to continue.");
                var enter = Console.ReadKey();

                //RETRIEVING THE SMS STATUS
                var response2 = authenticatedRequest.SMS.MessageMT.GetStatus(response);

                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_SMS_MT when retrieving the status is:\n");
                Console.WriteLine(response2.smsDeliveryStatus[0].deliveryStatus + "\n");

            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_SMS_MT has failed:\n");
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
                Console.WriteLine("Example_SMS_MT has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
