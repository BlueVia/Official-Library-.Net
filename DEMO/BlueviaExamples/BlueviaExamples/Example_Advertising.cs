using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.SGAP.Schemas; //Loading the Bluevia Directory objects


/*
 * This is the Bluevia's Example launcher
 */
namespace BlueviaExamples
{
    class Example_Advertising : Example
    {

        public string getDescription()
        {
            return ("This Example requets an advertising to Bluevia, retrieves it,\n"+
                "and prints some of the info that contains the advertising, as\n"+
            "the url of the banner.");
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

            //Changing the operational mode of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);

            /*Creating an advertising request object*/
            SimpleAdRequest requestAdvertisingData = new SimpleAdRequest();
            requestAdvertisingData.user_agent = "MyExplorer";
            requestAdvertisingData.ad_space = "BV15125";


            ///////////////////////////////////////////////////////////////////////
            try
            {
                //REQUESTING AN ADVERTISING
                var response = authenticatedRequest.SGAP.AdRequest.Send(requestAdvertisingData);


                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_Advertising is:\n");
                Console.WriteLine("Response object"+response.GetType());
                Console.WriteLine("The advertising banner url: "+response.CreativeElements[0].value);
                Console.WriteLine("The advertising type name: " + response.CreativeElements[0].type_name);

            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_Advertising has failed:\n");
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
                Console.WriteLine("Example_Advertising has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
