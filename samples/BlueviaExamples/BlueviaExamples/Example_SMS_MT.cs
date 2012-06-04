// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Messagery.Schemas;
using Bluevia.Messagery.SMS.Client; //Loading the Bluevia Api clients

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_SMS_MT.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> SMS Mobile's terminated api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_SMS_MT : IExample
    {
        public string getDescription()
        {
            return ("This Example sends a SMS to a fake phone, and then retrieves it's Status.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the SMS MT client:
            BV_MTSMS client = new BV_MTSMS(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petitions:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            DeliveryInfo[] deliveryInfos = null;
            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SENDING AN SMS
                string statusId = client.Send(
                    destination: "54666112233", //MANDATORY
                    text: "SANDBLUEDEMOS This is a Dummie SMS for SMS_MT", //MANDATORY
                    endpoint: null, //Optional
                    correlator: null //Optional
                     );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_SMS_MT when sending an SMS is:\n");
                Console.WriteLine(statusId + "\n");

                Console.WriteLine("\nPress any key to continue.");
                var enter = Console.ReadKey();

                //RETRIEVING THE SMS STATUS
                deliveryInfos = client.GetDeliveryStatus(
                    messageId: statusId //MANDATORY
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_SMS_MT when retrieving the status is:\n");
                Console.WriteLine(deliveryInfos[0].statusDescription + "\n");

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_SMS_MT has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_SMS_MT has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
