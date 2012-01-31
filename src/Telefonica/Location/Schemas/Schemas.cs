// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Location.Schemas
{
    using System.Xml.Serialization;


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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("terminalLocation", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/", IsNullable = false)]
    public partial class TerminalLocationListType
    {

        private LocationDataType[] terminalLocationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("terminalLocation")]
        public LocationDataType[] terminalLocation
        {
            get
            {
                return this.terminalLocationField;
            }
            set
            {
                this.terminalLocationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("terminalLocation", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/", IsNullable = false)]
    public partial class LocationDataType
    {

        private UserIdType locatedPartyField;

        private RetrievalStatusType reportStatusField;

        private LocationInfoType currentLocationField;

        private ServiceErrorType errorInformationField;

        /// <remarks/>
        public UserIdType locatedParty
        {
            get
            {
                return this.locatedPartyField;
            }
            set
            {
                this.locatedPartyField = value;
            }
        }

        /// <remarks/>
        public RetrievalStatusType reportStatus
        {
            get
            {
                return this.reportStatusField;
            }
            set
            {
                this.reportStatusField = value;
            }
        }

        /// <remarks/>
        public LocationInfoType currentLocation
        {
            get
            {
                return this.currentLocationField;
            }
            set
            {
                this.currentLocationField = value;
            }
        }

        /// <remarks/>
        public ServiceErrorType errorInformation
        {
            get
            {
                return this.errorInformationField;
            }
            set
            {
                this.errorInformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class UserIdType
    {

        private object itemField;

        private ItemChoiceType1 itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("alias", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("anyUri", typeof(string), DataType = "anyURI")]
        [System.Xml.Serialization.XmlElementAttribute("ipAddress", typeof(IpAddressType))]
        [System.Xml.Serialization.XmlElementAttribute("otherId", typeof(OtherIdType))]
        [System.Xml.Serialization.XmlElementAttribute("phoneNumber", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class IpAddressType
    {

        private string itemField;

        private ItemChoiceType itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ipv4", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ipv6", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        ipv4,

        /// <remarks/>
        ipv6,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class OtherIdType
    {

        private string typeField;

        private string valueField;

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        alias,

        /// <remarks/>
        anyUri,

        /// <remarks/>
        ipAddress,

        /// <remarks/>
        otherId,

        /// <remarks/>
        phoneNumber,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    public enum RetrievalStatusType
    {

        /// <remarks/>
        Retrieved,

        /// <remarks/>
        NotRetrieved,

        /// <remarks/>
        Error,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    public partial class LocationInfoType
    {

        private CoordinatesType coordinatesField;

        private float altitudeField;

        private bool altitudeFieldSpecified;

        private int accuracyField;

        private System.DateTime timestampField;

        /// <remarks/>
        public CoordinatesType coordinates
        {
            get
            {
                return this.coordinatesField;
            }
            set
            {
                this.coordinatesField = value;
            }
        }

        /// <remarks/>
        public float altitude
        {
            get
            {
                return this.altitudeField;
            }
            set
            {
                this.altitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool altitudeSpecified
        {
            get
            {
                return this.altitudeFieldSpecified;
            }
            set
            {
                this.altitudeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int accuracy
        {
            get
            {
                return this.accuracyField;
            }
            set
            {
                this.accuracyField = value;
            }
        }

        /// <remarks/>
        public System.DateTime timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    public partial class CoordinatesType
    {

        private float latitudeField;

        private float longitudeField;

        /// <remarks/>
        public float latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public float longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/location/v1/")]
    public partial class ServiceErrorType
    {

        private string messageIdField;

        private string textField;

        private string[] variablesField;

        /// <remarks/>
        public string messageId
        {
            get
            {
                return this.messageIdField;
            }
            set
            {
                this.messageIdField = value;
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
}
