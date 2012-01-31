// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.SMS.Schemas
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("smsText", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class SMSTextType
    {

        private UserIdType[] addressField;

        private string messageField;

        private SimpleReferenceType receiptRequestField;

        private UserIdType originAddressField;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("address")]
        public UserIdType[] address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public SimpleReferenceType receiptRequest
        {
            get
            {
                return this.receiptRequestField;
            }
            set
            {
                this.receiptRequestField = value;
            }
        }

        /// <remarks/>
        public UserIdType originAddress
        {
            get
            {
                return this.originAddressField;
            }
            set
            {
                this.originAddressField = value;
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class SimpleReferenceType
    {

        private string endpointField;

        private string correlatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string endpoint
        {
            get
            {
                return this.endpointField;
            }
            set
            {
                this.endpointField = value;
            }
        }

        /// <remarks/>
        public string correlator
        {
            get
            {
                return this.correlatorField;
            }
            set
            {
                this.correlatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("smsDeliveryStatus", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class SMSDeliveryStatusType
    {

        private DeliveryInformationType[] smsDeliveryStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("smsDeliveryStatus")]
        public DeliveryInformationType[] smsDeliveryStatus
        {
            get
            {
                return this.smsDeliveryStatusField;
            }
            set
            {
                this.smsDeliveryStatusField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    public partial class DeliveryInformationType
    {

        private UserIdType addressField;

        private string deliveryStatusField;

        private string descriptionField;

        /// <remarks/>
        public UserIdType address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public string deliveryStatus
        {
            get
            {
                return this.deliveryStatusField;
            }
            set
            {
                this.deliveryStatusField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("smsDeliveryStatusUpdate", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class SMSDeliveryStatusUpdateType
    {

        private string correlatorField;

        private DeliveryInformationType deliveryStatusField;

        /// <remarks/>
        public string correlator
        {
            get
            {
                return this.correlatorField;
            }
            set
            {
                this.correlatorField = value;
            }
        }

        /// <remarks/>
        public DeliveryInformationType deliveryStatus
        {
            get
            {
                return this.deliveryStatusField;
            }
            set
            {
                this.deliveryStatusField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedSMS", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class ReceivedSMSType
    {

        private SMSMessageType[] receivedSMSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("receivedSMS")]
        public SMSMessageType[] receivedSMS
        {
            get
            {
                return this.receivedSMSField;
            }
            set
            {
                this.receivedSMSField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    public partial class SMSMessageType
    {

        private string messageField;

        private UserIdType originAddressField;

        private UserIdType destinationAddressField;

        private System.DateTime dateTimeField;

        private bool dateTimeFieldSpecified;

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public UserIdType originAddress
        {
            get
            {
                return this.originAddressField;
            }
            set
            {
                this.originAddressField = value;
            }
        }

        /// <remarks/>
        public UserIdType destinationAddress
        {
            get
            {
                return this.destinationAddressField;
            }
            set
            {
                this.destinationAddressField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateTimeSpecified
        {
            get
            {
                return this.dateTimeFieldSpecified;
            }
            set
            {
                this.dateTimeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedSMSAsync", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class ReceivedSMSAsyncType
    {

        private string correlatorField;

        private SMSMessageType messageField;

        /// <remarks/>
        public string correlator
        {
            get
            {
                return this.correlatorField;
            }
            set
            {
                this.correlatorField = value;
            }
        }

        /// <remarks/>
        public SMSMessageType message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("smsNotification", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/", IsNullable = false)]
    public partial class SMSNotificationType
    {

        private SimpleReferenceType referenceField;

        private UserIdType[] destinationAddressField;

        private string criteriaField;

        /// <remarks/>
        public SimpleReferenceType reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("destinationAddress")]
        public UserIdType[] destinationAddress
        {
            get
            {
                return this.destinationAddressField;
            }
            set
            {
                this.destinationAddressField = value;
            }
        }

        /// <remarks/>
        public string criteria
        {
            get
            {
                return this.criteriaField;
            }
            set
            {
                this.criteriaField = value;
            }
        }
    }
}
