// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Messagery.SMS.Client; //Loading the Bluevia Api clients

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_SMS_Notifications.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> SMS Notification's api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_SMS_Notifications : IExample
    {
        public string getDescription()
        {
            return ("This example subscribes you to receive SMS Notifications, and then unsubscribes.\n"+
                "YOU HAVE TO CONSIDER THAT THE NOTIFICATION OBJECT MUST BE FILLED WITH VALID DATA");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            string youPhoneNumber = null;
            string yourCorrelator = null;
            string yourEndpoint = null;
            string yourCriteria = null;

            //FIRST: creating the MMS MO client:
            BV_MOSMS client = new BV_MOSMS(BVMode.SANDBOX, consumer, ckey);

            //SECOND: Making the petitions:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            try
            {
                //SUBSCRIBING TO RECEIVE SMS
                string subscribe = client.StartNotification(
                    phoneNumber: youPhoneNumber, //MANDATORY
                    endpoint: yourEndpoint, //MANDATORY
                    criteria: yourCriteria, //MANDATORY
                    correlator: yourCorrelator //MANDATORY
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_SMS_Notifications when subscribing is:\n");
                Console.WriteLine(subscribe);

                Console.WriteLine("Press any key to continue.");
                var enter = Console.ReadKey();

                //UNSUBSCRIBING
                bool unsusbscribe = client.StopNotification(
                    correlator: yourCorrelator //MANDATORY
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_SMS_Notifications when unsubscribing is:\n");
                Console.WriteLine(unsusbscribe);
            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_SMS_Notifications has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_SMS_Notifications has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
