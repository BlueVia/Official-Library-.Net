using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.Payment.Schemas; //Loading the Bluevia Payment objects

namespace BlueviaExamples
{
    class Example_Payment : Example
    {
        public string getDescription()
        {
            return ("This example, as the oauth one, will need aditional info gived from you, to complete "+
                "the \"Payment's OAuth Process\".\n"+
                "After that, a \"payment request\", a \"getting payment status request\", and a \"cancel tokens request\" " +
                "will be done.\n"+
                "Note that you must set your developers data (consumer key, and secret) \n" +
                "in the soruce code of \"Eample_Payment.cs\", before launching it.\n"+
                "Also you will be requested to type the aditional info gived during the oauth process.");
        }

        public void call()
        {
            //FIRST: configuring the consumer data:
            //***********************
            Bluevia.Core.Configuration.Client.setConsumer("Your consumer Key");
            Bluevia.Core.Configuration.Client.setConsumerSecret("Your consumer Secret");

            //SECOND: creating the bluevia's client
            BlueviaClient client = new BlueviaClient();

            //THIRD: Creating a request over the client:
            IBlueviaClient request = client.CreateRequest();

            //FOURTH: Athenticating the request. Payment has a special authentication process, so 
            // before making the call, special Payment Tokens must be requested.
            // We recommend you to try the OAuth example first

            //Changing the operational mode of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);

                uint Amount = 1;
                String Currency = "EUR";
                String Name = "bluevia";
                String ServiceID = "A Service ID";

                //REQUESTING "RequestTokens"
                var response = request
                    .OAuth.RequestToken.Get(Amount,Currency,Name,ServiceID);

                Console.WriteLine("Now we have the Payment Request tokens:\n");
                Console.WriteLine("Token: " + response.Token + "\n");
                Console.WriteLine("Token secret: " + response.TokenSecret + "\n");

                //Storing the Request Tokens for the OAuth process
                Bluevia.Core.Configuration.Client.setTokenPair(response.Token, response.TokenSecret);

                Console.WriteLine("Please type in your navigator: " + response.AuthoriseUrl + "\n");
                Console.WriteLine("Accept conditions and type the pin or verification code you have been gived during the process\n");
                Console.WriteLine("Verification code:\n");
                var verification = Console.ReadLine();

                Console.WriteLine("Now we can request the AccessTokens for the Payment.\n");
                Console.WriteLine("Press any key to continue.\n");
                var key = Console.ReadKey();

                //REQUESTING "AccessTokens"
                var response2 = request
                    .AuthenticateClient()
                    .OAuth.AccessToken.Get(response, verification);

                Console.WriteLine("Now we have the Payment Access tokens:\n");
                Console.WriteLine("Token: " + response.Token + "\n");
                Console.WriteLine("Token secret: " + response.TokenSecret + "\n");

                //Storing the Access Tokens for the Payment Process
                Bluevia.Core.Configuration.Client.setTokenPair(response2.Token, response2.TokenSecret);
                
                //Creating an authenticated request:
                IBlueviaClient authenticatedRequest = request.AuthenticateClient();

            //FIFTH: Now, we are ready to make the petition:

            ///////////////////////////////////////////////////////////////////////
            try
            {
                //MAKING THE PAYMENT
                var response3 = authenticatedRequest.Payment.AmountCharging.Payment(Amount, Currency);

                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_Payment when Paying is:\n");
                Console.WriteLine("The Id of the payment is: " + response3.transactionId);

                //RETRIEVING THE STATUS
                var response4 = authenticatedRequest.Payment.AmountCharging.GetPaymentStatus(response3.transactionId);

                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_Payment when retrieving status is:\n");
                Console.WriteLine("The Status of the payment is: " +response4.transactionStatus);


                //CANCEL AUTHORIZATION
                authenticatedRequest.Payment.AmountCharging.CancelAuthorization();
            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_Payment has failed:\n");
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
                Console.WriteLine("Example_Payment has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
