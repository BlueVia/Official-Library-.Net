// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Core; //Loading the Bluevia core functionallity
using Bluevia.Core.Schemas; //Loading the Bluevia core objects

using Bluevia.Messagery.Schemas;
using Bluevia.Messagery.MMS;
using Bluevia.Messagery.MMS.Client; //Loading the Bluevia Api clients
using Bluevia.Messagery.MMS.Schemas; //Loading the Bluevia Api objects

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_MMS_MT.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> MMS Mobile's terminated api example.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Example_MMS_MT : IExample
    {
        public string getDescription()
        {
            return ("This Example sends a MMS to a fake phone, and then retrieves it's Status. "+
                "Note that you have to write the path of a jpeg image (including the extension) from your disk,"+
                " to serve as attachment.");
        }

        public void call(String consumer, String ckey, String token, String secret)
        {
            //FIRST: creating the MMS MT client:
            BV_MTMMS client = new BV_MTMMS(BVMode.SANDBOX, consumer, ckey, token, secret);

            //SECOND: Making the petitions:
            //Note that every possible parameter is here displayed in the service call,
            //but only the mandatory ones are necessary.
            DeliveryInfo[] deliveryInfos = null;
            ///////////////////////////////////////////////////////////////////////
            try
            {
                //SENDING AN MMS
                string statusId = client.Send(
                    destination: "54666112233", //MANDATORY
                    subject: "SANDBLUEDEMOS This is a Dummie MMS Subject for MMS_MO", //MANDATORY
                    message: "Optional text attachment", //Optional
                    attachments: new Attachment[] //Optional
                    {
                        //TYPE THE PATH TO THE jpeg FILE
                        new Attachment("D:\\pic.jpg", MIMEType.jpeg)
                    },
                    endpoint: null, //Optional
                    correlator: null //Optional
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_MMS_MT when sending an MMS is:\n");
                Console.WriteLine(statusId + "\n");

                Console.WriteLine("\nPress any key to continue.");
                var enter = Console.ReadKey();

                //RETRIEVING THE SMS STATUS
                deliveryInfos = client.GetDeliveryStatus(
                    messageId: statusId //MANDATORY
                    );

                /*Showing Response*/
                Console.WriteLine("\nThe response from Bluevia for the Example_MMS_MT when retrieving the status is:\n");
                Console.WriteLine(deliveryInfos[0].statusDescription + "\n");

            }
            catch (BlueviaException e)
            {

                Console.WriteLine("\nExample_MMS_MT has failed:\n");
                Console.WriteLine("The Exception is:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExample_MMS_MT has failed:\n");
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
