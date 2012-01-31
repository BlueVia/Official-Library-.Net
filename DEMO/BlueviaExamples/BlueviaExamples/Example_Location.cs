﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.Location.Schemas; //Loading the Bluevia Location objects

namespace BlueviaExamples
{
    class Example_Location : Example
    {
        public string getDescription()
        {
            return ("This Example retrieves the PhoneNumber Location Info from Bluevia, and prints its coordenates.");
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

            /*Creating a Location params object*/
            TerminalLocationParams tlp = new TerminalLocationParams();

            ///////////////////////////////////////////////////////////////////////
            try
            {
                //REQUESTING LOCATION
                var response = authenticatedRequest.Location.TerminalLocation.GetLocation(tlp);


                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_Location is:\n");
                Console.WriteLine("Latitude: "+response.terminalLocation.ElementAt(0).currentLocation.coordinates.latitude + "\n");
                Console.WriteLine("Longitude: " + response.terminalLocation.ElementAt(0).currentLocation.coordinates.longitude + "\n");

            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_Location has failed:\n");
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
                Console.WriteLine("Example_Location has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
