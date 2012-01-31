using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.OAuth.Schemas; //Loading the Bluevia OAuth objects

namespace BlueviaExamples
{
    class Example_OAuth : Example
    {
        public string getDescription()
        {
            return ("This example makes a simple authorization process. \n"+
                "Note that this example guides you trough the process,\n"+
                "and you must set your developers data (consumer key, and secret) \n" +
                "in the soruce code of \"Eample_OAuth.cs\", before launching it.\n"+
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

            //FOURTH: Athenticating the request. When Getting Tokens, the first step is done without token authentication.

            //Changing the operational mode of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);
            try
            {
                //REQUESTING "RequestTokens"
                var response = request
                    .OAuth.RequestToken.Get();

                Console.WriteLine("Now we have the Request tokens:\n");
                Console.WriteLine("Token: " + response.Token + "\n");
                Console.WriteLine("Token secret: " + response.TokenSecret + "\n");

                //Storing the Request Tokens for the OAuth process
                Bluevia.Core.Configuration.Client.setTokenPair(response.Token, response.TokenSecret);

                Console.WriteLine("Please type in your navigator: " + response.AuthoriseUrl + "\n");
                Console.WriteLine("Accept conditions and type the pin or verification code you have been gived during the process\n");
                Console.WriteLine("Verification code:\n");
                var verification = Console.ReadLine();

                Console.WriteLine("Now we can request the AccessTokens.\n");
                Console.WriteLine("Press any key to continue.\n");
                var key = Console.ReadKey();

                //REQUESTING "AccessTokens"
                var response2 = request
                    .AuthenticateClient()
                    .OAuth.AccessToken.Get(response, verification);

                Console.WriteLine("Now we have the Access tokens:\n");
                Console.WriteLine("Token: " + response.Token + "\n");
                Console.WriteLine("Token secret: " + response.TokenSecret + "\n");

                //Storing the Access Tokens for the OAuth Process
                Bluevia.Core.Configuration.Client.setTokenPair(response2.Token, response2.TokenSecret);
            }           
            catch (RestClientException e)
            {

                Console.WriteLine("Example_OAuth has failed:\n");
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
                Console.WriteLine("Example_OAuth has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }

            //FIFTH: Now, we are ready to make an API petition:
            //OAuth Api, isn't a service itself. It provides functionallity to the other APIs
        }
    }
}
