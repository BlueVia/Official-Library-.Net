// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Response.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The Bluevia Response object.</summary>
    /// <remarks>   2012/02/09. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Response
    {
        /// <value>The Http resulting code.</value>
        private string code;

        /// <value>The description of the Http resulting code.</value>
        private string message;

        /// <value>The body and headers of the service response.</value>
        private AdditionalResponseData additionalData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Response"/>.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Response()
        {
            code = string.Empty;
            message = string.Empty;
            additionalData = new AdditionalResponseData();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to set the response Http resulting code.</summary>
        /// <param name="status">The code.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetResponseStatus(string status){
            if (string.IsNullOrEmpty(status))
            {
                BlueviaException ex = new BlueviaException("Null ResponseStatus parameter when setting status in Bluevia_Response.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }
            else
            {
                code = status;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to set the Bluevia Api service response description.</summary>
        /// <param name="data">The description.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetResponseData(string data){
            if (string.IsNullOrEmpty(data))
            {
                BlueviaException ex = new BlueviaException("Null Data parameter when setting data in Bluevia_Response.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }
            else
            {
                message = data;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to set the Bluevia Api service response info. Hedares and body.</summary>
        /// <param name="addData">The headers and body of the response.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetResponseAdditionalData(AdditionalResponseData addData)
        {
            if (addData==null)
            {
                BlueviaException ex = new BlueviaException("Null AdditionalData parameter when setting AdditionalData in Bluevia_Response.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }
            else
            {
                this.additionalData = addData;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the service's response body.</summary>
        /// <returns>The response body.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] GetResponseBody()
        {
            return additionalData.GetBody();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the service's response headers.</summary>
        /// <returns>The headers.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Dictionary<string, string> GetResponseHeaders()
        {
            return additionalData.GetHeaders();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Adds a single header (header + content) to the additionalData object.</summary>
        /// <param name="key">The label of the header.</param>
        /// <param name="value">The header content.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddResponseHeader(string key, string value)
        {
            additionalData.AddHeader(key, value);
        }
        
    }

}
