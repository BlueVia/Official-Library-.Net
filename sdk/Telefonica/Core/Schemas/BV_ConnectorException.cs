// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_ConnectorException.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Exception class with the neccesary data fields for Bluevia Http errors.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_ConnectorException : BlueviaException
    {
        /// <value>Object to contain the info of a responsed Bluevia's service error.</value>
        private AdditionalResponseData addData = new AdditionalResponseData();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_ConnectorException"/>. Void constructor.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_ConnectorException() : base() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_ConnectorException"/>. Full constructor.</summary>
        /// <param name="message">A message acording to Bluevia using. Either the service or sdk exception.</param>
        /// <param name="code">The Bluevia service Exception code.</param>
        /// <param name="ex">Optional (for cases that another exception has been catched):The internal exception.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_ConnectorException(string message, string code = "", Exception ex=null) : base(message, code, ex) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to set the Bluevia Api service exception info, received in a BV_Response.</summary>
        /// <param name="addData">The body and the headders of the service exception.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetConnectorExceptionAdditionalData(AdditionalResponseData addData){
            this.addData = addData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to get the Bluevia Api service exception info, received.</summary>
        /// <returns>The body and the headders of the service exception.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public AdditionalResponseData GetConnectorExceptionAdditionalData()
        {
            return addData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to get the Bluevia Api service exception info, received.</summary>
        /// <returns>The body of the service exception.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetConnectorExceptionBody()
        {
            return Encoding.Default.GetString(addData.GetBody());
        }
    }
}
