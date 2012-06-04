// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.OAuth.Client; //Loading the Bluevia Api clients

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_OAuth.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> OAuth's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_OAuth : IExample
    {
        public string getDescription()
        {
            return ("This example makes a simple authorization process. \n"+
                "Note that this example guides you trough the process,\n"+
                "and you must set your developers data (consumer key, and secret) \n" +
                "in the source code of \"Eample_OAuth.cs\", before launching it.\n"+
                "Also you will be requested to type the aditional info gived during the oauth process.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            string yourConsumerKey = "";
            string yourConsumerSecret = "";

            //FIRST: creating the OAuth client:
            BV_OAuth client = new BV_OAuth(BVMode.SANDBOX, yourConsumerKey, yourConsumerSecret);

            //SECOND: Making the OAuth Process:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            RequestToken requestToken = null;
            Token accessToken = null;
            try
            {
                //REQUESTING "RequestTokens"
                requestToken = client.GetRequestToken(
                    callback: "oob" //Optional
                    );
                Console.WriteLine("\nNow we have the Request tokens:\n");
                Console.WriteLine("Token: " + requestToken.key + "\n");
                Console.WriteLine("Token secret: " + requestToken.secret + "\n");


                Console.WriteLine("\nPlease type in your navigator: " + requestToken.authUrl + "\n");
                Console.WriteLine("Accept conditions and type the pin or verification code you have been gived during the process\n");
                Console.WriteLine("Verification code:\n");
                var verification = Console.ReadLine();

                //REQUESTING "AccessTokens"
                Console.WriteLine("\nThe requesTokens musn't be provided during this step,\n" +
                "because they have been stored at the end of the GetRequestToken operation\n");
                accessToken = client.GetAccessToken(
                    oauthVerifier:verification, //MANDATORY
                    requestToken:null, //Optional 
                    requestSecret:null //Optional
                    );

                Console.WriteLine("\nNow we have the Access tokens, and we are ready to make petitions with other apis:\n");
                Console.WriteLine("Token: " + accessToken.key + "\n");
                Console.WriteLine("Token secret: " + accessToken.secret + "\n");

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_OAuth has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_OAuth has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
            
        }
    }
}
