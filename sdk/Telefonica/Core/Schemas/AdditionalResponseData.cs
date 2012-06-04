// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AdditionalResponseData.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the info of a response body.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class AdditionalResponseData
    {
        /// <value>The body of the received response.</value>
        private byte[] body;
        /// <value>The body headers of the received response.</value>
        private Dictionary<string, string> headers;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="AdditionalResponseData"/>.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
            public AdditionalResponseData()
            {
                body = null;
                headers = new Dictionary<string, string>();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Sets the body value.</summary>
            /// <param name="body">The received response body.</param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public void SetBody(byte[] body = null)
            {
                this.body = body;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Gets the body value.</summary>
            /// <returns>The received response body (data or service exception).</returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public byte[] GetBody()
            {
                return body;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Sets the body headers value.</summary>
            /// <param name="headers">The received response body headers.</param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public void SetHeaders(Dictionary<string, string> headers)
            {
                if (headers == null)
                {
                    BlueviaException ex = new BlueviaException("Null Headers parameter when setting headers in additionalResponseData.");
                    ex.code = ExceptionCode.InvalidArgumentException;
                    throw ex;
                }
                else
                {
                    this.headers = headers;
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Gets the body headers value.</summary>
            /// <returns>The received response body headers.</returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public Dictionary<string, string> GetHeaders()
            {
                return headers;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Function to add a single header.</summary>
            /// <param name="key">The label of the header.</param>
            /// <param name="value">The content of the header.</param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public void AddHeader(string key, string value)
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    BlueviaException ex = new BlueviaException("Null or empty key||value parameters when adding a header in additionalResponseData.");
                    ex.code = ExceptionCode.InvalidArgumentException;
                    throw ex;
                }
                else
                {
                    headers.Add(key, value);
                }
            }

        
    }
}
