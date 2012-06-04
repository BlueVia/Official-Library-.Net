// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Location.Client; //Loading the Bluevia Api clients
using Bluevia.Location.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_Location.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> User's Info Location's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_Location : IExample
    {
        public string getDescription()
        {
            return ("This Example retrieves the PhoneNumber Location Info from Bluevia, and prints its coordenates.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the Location client:
            BV_Location client = new BV_Location(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petition:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            LocationInfo locationInfo = null;
            try
            {
                locationInfo = client.GetLocation(
                    accuracy:500 //Optional
                    );
                Console.WriteLine("\nThe location is:");
                Console.WriteLine("\taccuracy obtained: {0}, lat: {1}, lon: {2}."
                    ,locationInfo.accuracy, locationInfo.coordinatesLatitude, locationInfo.coordinatesLongitude);

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_Location has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_Location has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
