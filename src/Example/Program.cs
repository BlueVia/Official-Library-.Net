using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Bluevia.Core;
using Bluevia.OAuth;
using Bluevia.SMS.Schemas;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            String consumer;
            String consumerSecret;
            Bluevia.Core.Schemas.OAuthToken RequestToken; //Object that contains a pair of tokens.
            SMSDeliveryStatusType status; //Object that contains a SMS status object.
            String accessToken;
            String tokenSecret;
            BlueviaClient client; //The BlueVia Client.

            Console.WriteLine("This is a Console application using Bluevia:\n");
            Console.WriteLine("First of all, sign into: https://connect.bluevia.com/en/user \n");
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();

            /*
             * Setting your data:
             */
            Console.WriteLine("Type your consumer key.\n");
            consumer = Console.ReadLine();


            Console.WriteLine("Type your consumer Secret.\n");
            consumerSecret = Console.ReadLine();



            Bluevia.Core.Configuration.Client.setConsumer(consumer);
            Bluevia.Core.Configuration.Client.setConsumerSecret(consumerSecret);
            //Changing mode to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment("_Sandbox");

            /*
             * Creating the BlueVia Client:
             */
            Console.WriteLine("A BlueviaClient is going to be instancied.\n");
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();

            client = new BlueviaClient();

            /*
             * Begining with the oauth process to register a new application:
             */

            //Step 1: Obtaining a pair of RequestTokens to register the application:
            Console.WriteLine("New pair of RequestTokens are going to be requested witha a CallBack parameter: http://localhost/ .\n");
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            try
            {
                var oauthResponse1 = client
                    .CreateRequest()
                    .OAuth.RequestToken.Get(callbackUrl : "http://localhost/");

                RequestToken = oauthResponse1;
                accessToken = RequestToken.Token;
                tokenSecret = RequestToken.TokenSecret;

                /*Storing the Request pair of tokens for the Acces authentication*/
                Bluevia.Core.Configuration.Client.setTokenPair(accessToken, tokenSecret);

                //Setp 2: Obtaining a verification code to request the AccessTokens:
                Console.WriteLine("Now we have the request tokens:\n");
                Console.WriteLine("Token: " + accessToken + "\n");
                Console.WriteLine("Token secret: " + tokenSecret + "\n");
                Console.WriteLine("Please type in your navigator: https://connect.bluevia.com/authorise?oauth_token=" + oauthResponse1.Token + "\n");
                Console.WriteLine("Accept conditions and type the pin or verification code you have been gived on the redirection\n");
                Console.WriteLine("Verification code:\n");
                var verification = Console.ReadLine();

                //Setp 3: Obtaining the AccessTokens:
                Console.WriteLine("Now we can request the AccessTokens for the SMS API.\n");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();

                var oauthResponse2 = client
                    .CreateRequest()
                    .AuthenticateClient()
                    .OAuth.AccessToken.Get(oauthResponse1, verification);

                RequestToken = oauthResponse2;
                accessToken = RequestToken.Token;
                tokenSecret = RequestToken.TokenSecret;

                /*Storing the New pair of tokens for our application*/
                Bluevia.Core.Configuration.Client.setTokenPair(accessToken, tokenSecret);

                /*
                 * Making a new petition to the servers, this time, we are going to send a SMS:
                 */
                Console.WriteLine("The AccessTokens are stored, now we are going to send a SMS.\n");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();

                var smsResponse = client
                    .CreateRequest()
                    .AuthenticateClient()
                    .SMS.MessageMT.Send(
                        new string[] { "DestinationNumber" },//Type a destination number here
                        "NEW MESSAGE");

                /*
                 * Retrieving the delivery status of the sms:
                 */
                Console.WriteLine("The SMS is sended, lets get the delivery status.\n");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();

                var statusResponse = client
                    .CreateRequest()
                    .AuthenticateClient()
                    .SMS.MessageMT.GetStatus(smsResponse);

                status = statusResponse;

                Console.WriteLine("The Status is:\n");
                Console.WriteLine(status.smsDeliveryStatus + "\n");
                Console.WriteLine("Press any key to finish.\n");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e + "\n");
                Console.WriteLine("Press any key to finish.\n");
                Console.ReadKey();
            }
        }
    }
}
