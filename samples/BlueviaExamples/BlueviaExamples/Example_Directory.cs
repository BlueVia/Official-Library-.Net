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
    /// <copyright file="Example_Directory.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> All User's Info directory's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_Directory : IExample
    {
        public string getDescription()
        {
            return ("This Example retrieves all available Directory Info from Bluevia,\n" +
                "and prints some fields of the response.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the Directory client:
            BV_Directory client = new BV_Directory(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petition:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            UserInfo userInfo = null;
            try
            {
                userInfo = client.GetUserInfo(
                dataSet: null //Optional
                );

                Console.WriteLine("\nAll the Directory info has been retrieved, lets print some fields:");
                Console.WriteLine("\nThe Directory AccessInfo apn field  is:");
                Console.WriteLine("\tapn: {0}.", userInfo.accessInfo.apn);
                Console.WriteLine("\nThe Directory PersonalInfo gender field is:");
                Console.WriteLine("\tgender: {0}.", userInfo.personalInfo.gender);
                Console.WriteLine("\nThe Directory ProfileInfo operatorId field is:");
                Console.WriteLine("\toperatorId: {0}.", userInfo.profileInfo.operatorId);
                Console.WriteLine("\nThe Directory TerminalInfo brand and model fields are:");
                Console.WriteLine("\tbrand: {0}, model: {1}.", userInfo.terminalInfo.brand, userInfo.terminalInfo.model);
            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_Directory has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_Directory has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }

    }
}
