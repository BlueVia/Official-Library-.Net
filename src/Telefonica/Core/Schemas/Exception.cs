// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Schemas
{
    public class ClientValidationException : BlueviaException
    {
        public ClientValidationException() : base() { }
        public ClientValidationException(string message) : base(message) { }
    }

    public class BlueviaException : ApplicationException
    {
        public BlueviaException() : base() { }
        public BlueviaException(string message) : base(message) { }
        public BlueviaException(string message, Exception ex) : base (message, ex) { }
    }


    public class RestClientException : BlueviaException
    {
        public ClientExceptionType ClientException { get; private set; }
        public ServerExceptionType ServerException { get; private set; }

        public RestClientException(ClientExceptionType clientException) { ClientException = clientException; }
        public RestClientException(ServerExceptionType serverException) { ServerException = serverException; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    [System.Xml.Serialization.XmlRootAttribute("ClientException", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1", IsNullable = false)]
    public partial class ClientExceptionType
    {

        private ClientExceptionTypeExceptionCategory exceptionCategoryField;

        private int exceptionIdField;

        private string textField;

        private string[] variablesField;

        /// <remarks/>
        public ClientExceptionTypeExceptionCategory exceptionCategory
        {
            get
            {
                return this.exceptionCategoryField;
            }
            set
            {
                this.exceptionCategoryField = value;
            }
        }

        /// <remarks/>
        public int exceptionId
        {
            get
            {
                return this.exceptionIdField;
            }
            set
            {
                this.exceptionIdField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("variables")]
        public string[] variables
        {
            get
            {
                return this.variablesField;
            }
            set
            {
                this.variablesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ClientExceptionTypeExceptionCategory
    {

        /// <remarks/>
        SVC,

        /// <remarks/>
        POL,

        /// <remarks/>
        SEC,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    [System.Xml.Serialization.XmlRootAttribute("ServerException", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1", IsNullable = false)]
    public partial class ServerExceptionType
    {

        private ServerExceptionTypeExceptionCategory exceptionCategoryField;

        private int exceptionIdField;

        private string textField;

        private string[] variablesField;

        /// <remarks/>
        public ServerExceptionTypeExceptionCategory exceptionCategory
        {
            get
            {
                return this.exceptionCategoryField;
            }
            set
            {
                this.exceptionCategoryField = value;
            }
        }

        /// <remarks/>
        public int exceptionId
        {
            get
            {
                return this.exceptionIdField;
            }
            set
            {
                this.exceptionIdField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("variables")]
        public string[] variables
        {
            get
            {
                return this.variablesField;
            }
            set
            {
                this.variablesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ServerExceptionTypeExceptionCategory
    {

        /// <remarks/>
        SVR,
    }
}
