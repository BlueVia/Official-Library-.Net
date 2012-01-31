using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia; //Loading Bluevia
using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects
using Bluevia.MMS.Schemas; //Loading the Bluevia MMS objects

namespace BlueviaExamples
{
    class Example_MMS_Notifications : Example
    {
        public string getDescription()
        {
            return ("This example subscribes you to receive MMS Notifications, and then unsubscribes.\n" +
                "YOU HAVE TO CONSIDER THAT THE NOTIFICATION OBJECT MUST BE FILLED WITH VALID DATA");
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

            //FOURTH: Athenticating the request is not necessary in MMS_Notifications

            //FIFTH: Now, we are ready to make the petition:

            //Changing the operational Notificationsde of the library to Sandbox
            Bluevia.Core.Configuration.Client.setEnvironment(Bluevia.Core.Configuration.ENVIRONMENT.SANDBOX);

            //Creating a Notification Object:
            MessageNotificationType notificationObject = new MessageNotificationType() {
                reference = new SimpleReferenceType() { correlator = "Correlator", endpoint = "A secure Endpoint" },
                destinationAddress = new UserIdType[] { new UserIdType() { Item = "A phone Number", ItemElementName = ItemChoiceType1.phoneNumber } },
                criteria = "Criteria"
            };
            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SUBSCRIBING TO RECEIVE MMS
                var response = request.MMS.NotificationManager.Subscribe(notificationObject);

                /*Showing Response*/
                Console.WriteLine("The response from Bluevia for the Example_MMS_Notifications when subscribing is:\n");
                Console.WriteLine(response);

                //UNSUBSCRIBING
                request
                     .MMS.NotificationManager.UnSubscribeNotification(response);

            }
            ///////////////////////////////////////////////////////////////////////
            catch (RestClientException e)
            {

                Console.WriteLine("Example_MMS_Notifications has failed:\n");
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
                Console.WriteLine("Example_MMS_Notifications has failed:\n");
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
