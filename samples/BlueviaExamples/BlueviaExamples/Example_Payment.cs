// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Payment.Client; //Loading the Bluevia Api clients
using Bluevia.Payment.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_Payment.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> Payments's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_Payment : IExample
    {
        public string getDescription()
        {
            return ("This example, as the oauth one, will need aditional info gived from you, to complete "+
                "the \"Payment's OAuth Process\".\n"+
                "After that, a \"payment request\", a \"getting payment status request\", and a \"cancel tokens request\" " +
                "will be done.\n"+
                "Note that you must set your developers data (consumer key, and secret) \n" +
                "in the soruce code of \"Example_Payment.cs\", before launching it.\n"+
                "Also you will be requested to type the aditional info gived during the oauth process.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            string yourConsumerKey = "";
            string yourConsumerSecret = "";
            uint yourAmount = 1;
            String yourCurrency = "EUR";
            String yourName = "Bluevia";
            String yourServiceID = "342342423";

            //FIRST: creating the Payment client:
            BV_Payment client = new BV_Payment(BVMode.SANDBOX, yourConsumerKey, yourConsumerSecret);

            //SECOND: Making the OAuth Process, and the Payments:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            RequestToken requestToken = null;
            Token accessToken = null;
            PaymentResult paymentResult = null;
            PaymentStatus paymentStatus = null;
            try
            {
                //REQUESTING "RequestTokens"
                requestToken = client.GetPaymentRequestToken(
                    amount: yourAmount, //MANDATORY
                    currency: yourCurrency, //MANDATORY
                    name: yourName, //MANDATORY
                    serviceID: yourServiceID, //MANDATORY
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
                accessToken = client.GetPaymentAccessToken(
                    oauthVerifier: verification, //MANDATORY
                    requestToken: null, //Optional 
                    requestSecret: null //Optional
                    );

                Console.WriteLine("\nNow we have the Access tokens, and we are ready to make payment petitions:\n");
                Console.WriteLine("Token: " + accessToken.key + "\n");
                Console.WriteLine("Token secret: " + accessToken.secret + "\n");

                //MAKING THE PAYMENT
                paymentResult = client.Payment(
                    amount: yourAmount, //MANDATORY
                    currency: yourCurrency, //MANDATORY
                    endpoint: null, //Optional
                    correlator: null //Optional
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_Payment when Paying is:\n");
                Console.WriteLine("The Id of the payment is: " + paymentResult.transactionId);
                Console.WriteLine("The Status description of the payment is: " + paymentResult.transactionStatusDescription);

                //RETRIEVING THE STATUS
                paymentStatus = client.GetPaymentStatus(
                    transactionId: paymentResult.transactionId
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_Payment when retrieving status is:\n");
                Console.WriteLine("The Status of the payment is: " + paymentStatus.transactionStatus);


                //CANCEL AUTHORIZATION
                var cancelResult = client.CancelAuthorization();
                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_Payment when Cancelling authorization is:\n");
                Console.WriteLine(cancelResult);

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_Payment has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_Payment has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
