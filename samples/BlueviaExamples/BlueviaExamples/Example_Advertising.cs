// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Advertising;
using Bluevia.Advertising.Client; //Loading the Bluevia Api clients
using Bluevia.Advertising.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_Advertising.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> Advertising`s api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_Advertising : IExample
    {

        public string getDescription()
        {
            return ("This Example requets an advertising to Bluevia, retrieves it,\n"+
                "and prints some of the info that contains the advertising, as\n"+
            "the url of the banner.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the Advertising client:
            BV_Advertising client = new BV_Advertising(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petition:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            SimpleAdResponse adResponse = null;
            try
            {
                adResponse = client.GetAdvertising3L(
                    adSpace: "BV15125", //MANDATORY
                    country: null, //Optional
                    adRequestId: null, //Optional
                    adPresentation: TypeId.image, //Optional
                    keywords: new string[] { "Bluevia" }, //Optional
                    protectionPolicy: ProtectionPolicy.low, //Optional
                    userAgent: "none" //Optional
                    );
                Console.WriteLine("\nThe advertising image is:");
                Console.WriteLine(adResponse.AdvertisingList[0].value);
                Console.WriteLine("\nThe interaction for the image is:");
                Console.WriteLine(adResponse.AdvertisingList[0].interaction);
            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_Advertising has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_Advertising has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
