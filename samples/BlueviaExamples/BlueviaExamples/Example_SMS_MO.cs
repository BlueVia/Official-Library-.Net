// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Messagery.SMS.Client; //Loading the Bluevia Api clients
using Bluevia.Messagery.SMS.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_SMS_MO.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> SMS Mobile's originated api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_SMS_MO : IExample
    {
        public string getDescription()
        {
            return ("This Example retrieves the first Message's info of an inbox.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the SMS  clients:
            BV_MTSMS clientMT = new BV_MTSMS(BVMode.SANDBOX, consumer, ckey, token, secret);
            BV_MOSMS clientMO = new BV_MOSMS(BVMode.SANDBOX, consumer, ckey);

            //SECOND: Making the petitions:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            SMSMessage[] inboxMessages = null;
            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SENDING AN SMS
                clientMT.Send(
                    destination: "546780", //MANDATORY
                    text: "SANDBLUEDEMOS This is a Dummie SMS for SMS_MO", //MANDATORY
                    endpoint: null, //Optional
                    correlator: null //Optional
                     );

                //GETTING THE MESSAGES LIST
                inboxMessages = clientMO.GetAllMessages(
                    registrationId: "546780" //MANDATORY
                    );

                try
                {
                    Console.WriteLine("\nThe response from Bluevia for the Example_SMS_MO when retrieving the list is:\n");
                    Console.WriteLine("There are: " + inboxMessages.Length + " messages");
                    Console.WriteLine("The message 0: " + inboxMessages[0].message);
                }
                catch (Exception em)
                {
                    Console.WriteLine("\n No messages where found.\n");
                    Console.WriteLine(em.Message);
                    return;
                }
            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_SMS_MO has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_SMS_MO has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
