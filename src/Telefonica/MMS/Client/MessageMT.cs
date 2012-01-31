// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Linq;
using Bluevia.Core;
using CoreSchemas = Bluevia.Core.Schemas;
using Bluevia.Core.Configuration;
using System.Collections.Generic;

namespace Bluevia.MMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     Operations applied to this resource implement about sending of MMSs (MMS-MT) and polling
    ///     for Delivery Status. 
    /// </summary>
    /// <remarks>   03/05/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class MessageMT : BaseClient, Bluevia.MMS.Client.IMessageMT 
    {
        public MessageMT (IServiceBuilder builder) : base(builder) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     control information about who must receive the message plus the actual message
        ///     information must be conveyed in the request. 
        /// </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="message">      it contains information about the MMS to be sent plus the
        ///                             different, optional multimedia (MIME) contents which will be
        ///                             delivered to end users according to the MMS root fields. </param>
        /// <param name="filePaths">    A variable-length parameters list containing file paths and mime-Types. </param>
        /// <returns>   
        ///     Identifier of the message request. It is a unique value which may be used for future
        ///     queries on delivery status for the different destination addresses.. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(Schemas.MessageType message, params Core.Schemas.FileAttachment[] filePaths)
        {
            Uri resource = null;
            callBuilder
                .SetBaseUri(UriManager.MMS_MessageMT_Send)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetMethod(CoreSchemas.WebMethod.Post)
                .AddAcceptableStatus(201)
                .SetRequestContentAsType<Schemas.MessageType>(message)
                .SetCallback(resp => { resource = resp.HeadersLocation(); });

            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    callBuilder.AddFile(filePath.Path(), filePath.Mime());
                }
            }
            
            callBuilder.Call();
            return resource.Segments.BeforeLast().TrimEnd('/');
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     control information about who must receive the message plus the actual message
        ///     information must be conveyed in the request. 
        /// </summary>
        /// <param name="message">      it contains information about the MMS to be sent plus the
        ///                             different, optional multimedia (MIME) contents which will be
        ///                             delivered to end users according to the MMS root fields. </param>
        /// <param name="streamAttachments">    A variable-length parameters list containing file paths. </param>
        /// <returns>   
        ///     Identifier of the message request. It is a unique value which may be used for future
        ///     queries on delivery status for the different destination addresses.. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Send(Schemas.MessageType message, Bluevia.Core.Schemas.StreamAttachment[] streamAttachments)
        {
            Uri resource = null;
            callBuilder
                .SetBaseUri(UriManager.MMS_MessageMT_Send)
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .SetMethod(CoreSchemas.WebMethod.Post)
                .AddAcceptableStatus(201)
                .SetRequestContentAsType<Schemas.MessageType>(message)
                .SetCallback(resp => { resource = resp.HeadersLocation(); });

            foreach (var streamAttachment in streamAttachments)
            {
                callBuilder.AddFile(streamAttachment);
            }

            callBuilder.Call();

            return resource.Segments.BeforeLast().TrimEnd('/');
        }


        public string Send(string[] destinationAddress, string mmsSubject, params Core.Schemas.FileAttachment[] filePaths)
        {
            Bluevia.MMS.Schemas.MessageType mms = new Bluevia.MMS.Schemas.MessageType(destinationAddress, mmsSubject);
            return Send(mms, filePaths);

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     It makes an explicit request over the transient delivery status, based on returned
        ///     message identifier. 
        /// </summary>
        /// <remarks>   10/05/2010. </remarks>
        /// <param name="messageId">    Identifier related to the delivery status request. </param>
        /// <returns>   
        ///     The delivery status of every one of the sent messages, along with the destination address
        ///     for every instance. 
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.MessageDeliveryStatusType GetStatus(string messageId)
        {
            Schemas.MessageDeliveryStatusType deliveryStatus = null;

            callBuilder
                .SetMethod(CoreSchemas.WebMethod.Get)
                .SetBaseUri(UriManager.MMS_MessageMT_Get.FormatWithInvariantCulture(messageId))
                .AddQueryString(CoreSchemas.QueryString.currentVersion)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { deliveryStatus = resp.ParseXml<Schemas.MessageDeliveryStatusType>(); })
                .Call();

            return deliveryStatus;
        }


        public Schemas.MessageDeliveryStatusType GetStatus(string messageId, out string status)
        {
            var returned = GetStatus(messageId);
            status = returned.messageDeliveryStatus.FirstOrDefault().deliveryStatus;
            return returned;
        }


    }
}
