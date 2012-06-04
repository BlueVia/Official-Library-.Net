// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Directory.Client; //Loading the Bluevia Api clients
using Bluevia.Directory.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_Directory_Access.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> Access User's Info directory's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_Directory_Access : IExample
    {
        public string getDescription()
        {
            return ("This Example retrieves all Directory Access Info fields from Bluevia,\n"+
                "and prints all of them.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the Directory client:
            BV_Directory client = new BV_Directory(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petition:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            AccessInfo accessInfo = null;
            try
            {
                accessInfo = client.GetAccessInfo(
                fields: null //Optional
                    );
                Console.WriteLine("\nThe Directory AccessInfo fields are:");
                Console.WriteLine("\taccessType: {0}, apn: {1}, roaming: {2}.", accessInfo.accessType, accessInfo.apn, accessInfo.roaming);

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_Directory_Access has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_Directory_Access has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
