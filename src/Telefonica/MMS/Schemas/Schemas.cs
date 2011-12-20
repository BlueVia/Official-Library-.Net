﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Este código fuente fue generado automáticamente por xsd, Versión=4.0.30319.1.
// 
namespace Bluevia.MMS.Schemas {
    using System.Xml.Serialization;
    
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    [System.Xml.Serialization.XmlRootAttribute("ClientException", Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IsNullable=false)]
    public partial class ClientExceptionType {
        
        private ClientExceptionTypeExceptionCategory exceptionCategoryField;
        
        private int exceptionIdField;
        
        private string textField;
        
        private string[] variablesField;
        
        
        public ClientExceptionTypeExceptionCategory exceptionCategory {
            get {
                return this.exceptionCategoryField;
            }
            set {
                this.exceptionCategoryField = value;
            }
        }
        
        
        public int exceptionId {
            get {
                return this.exceptionIdField;
            }
            set {
                this.exceptionIdField = value;
            }
        }
        
        
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlElementAttribute("variables")]
        public string[] variables {
            get {
                return this.variablesField;
            }
            set {
                this.variablesField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ClientExceptionTypeExceptionCategory {
        
        
        SVC,
        
        
        POL,
        
        
        SEC,
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    [System.Xml.Serialization.XmlRootAttribute("ServerException", Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IsNullable=false)]
    public partial class ServerExceptionType {
        
        private ServerExceptionTypeExceptionCategory exceptionCategoryField;
        
        private int exceptionIdField;
        
        private string textField;
        
        private string[] variablesField;
        
        
        public ServerExceptionTypeExceptionCategory exceptionCategory {
            get {
                return this.exceptionCategoryField;
            }
            set {
                this.exceptionCategoryField = value;
            }
        }
        
        
        public int exceptionId {
            get {
                return this.exceptionIdField;
            }
            set {
                this.exceptionIdField = value;
            }
        }
        
        
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlElementAttribute("variables")]
        public string[] variables {
            get {
                return this.variablesField;
            }
            set {
                this.variablesField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ServerExceptionTypeExceptionCategory {
        
        
        SVR,
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("message", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
        public partial class MessageType {
        
        private UserIdType[] addressField;
        
        private SimpleReferenceType receiptRequestField;
        
        private UserIdType originAddressField;
        
        private string subjectField;
        
        
        [System.Xml.Serialization.XmlElementAttribute("address")]
        public UserIdType[] address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        
        public SimpleReferenceType receiptRequest {
            get {
                return this.receiptRequestField;
            }
            set {
                this.receiptRequestField = value;
            }
        }

        
        public UserIdType originAddress {
            get {
                return this.originAddressField;
            }
            set {
                this.originAddressField = value;
            }
        }
        
        
        public string subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class UserIdType {
        
        private object itemField;
        
        private ItemChoiceType1 itemElementNameField;
        
        
        [System.Xml.Serialization.XmlElementAttribute("alias", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("anyUri", typeof(string), DataType="anyURI")]
        [System.Xml.Serialization.XmlElementAttribute("ipAddress", typeof(IpAddressType))]
        [System.Xml.Serialization.XmlElementAttribute("otherId", typeof(OtherIdType))]
        [System.Xml.Serialization.XmlElementAttribute("phoneNumber", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class IpAddressType {
        
        private string itemField;
        
        private ItemChoiceType itemElementNameField;
        
        
        [System.Xml.Serialization.XmlElementAttribute("ipv4", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ipv6", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema=false)]
    public enum ItemChoiceType {
        
        
        ipv4,
        
        
        ipv6,
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class OtherIdType {
        
        private string typeField;
        
        private string valueField;
        
        
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema=false)]
    public enum ItemChoiceType1 {
        
        
        alias,
        
        
        anyUri,
        
        
        ipAddress,
        
        
        otherId,
        
        
        phoneNumber,
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class SimpleReferenceType {
        
        private string endpointField;
        
        private string correlatorField;
        
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string endpoint {
            get {
                return this.endpointField;
            }
            set {
                this.endpointField = value;
            }
        }
        
        
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("messageDeliveryStatus", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class MessageDeliveryStatusType {
        
        private DeliveryInformationType[] messageDeliveryStatusField;
        
        
        [System.Xml.Serialization.XmlElementAttribute("messageDeliveryStatus")]
        public DeliveryInformationType[] messageDeliveryStatus {
            get {
                return this.messageDeliveryStatusField;
            }
            set {
                this.messageDeliveryStatusField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class DeliveryInformationType {
        
        private UserIdType addressField;
        
        private string deliveryStatusField;
        
        private string descriptionField;
        
        
        public UserIdType address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        
        public string deliveryStatus {
            get {
                return this.deliveryStatusField;
            }
            set {
                this.deliveryStatusField = value;
            }
        }
        
        
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("deliveryStatusUpdate", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class DeliveryStatusUpdateType {
        
        private string correlatorField;
        
        private DeliveryInformationType deliveryStatusField;
        
        
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
        
        
        public DeliveryInformationType deliveryStatus {
            get {
                return this.deliveryStatusField;
            }
            set {
                this.deliveryStatusField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedMessages", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class ReceivedMessagesType {
        
        private MessageReferenceType[] receivedMessagesField;
        
        
        [System.Xml.Serialization.XmlElementAttribute("receivedMessages")]
        public MessageReferenceType[] receivedMessages {
            get {
                return this.receivedMessagesField;
            }
            set {
                this.receivedMessagesField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class MessageReferenceType {
        
        private string messageIdentifierField;
        
        private UserIdType destinationAddressField;
        
        private UserIdType originAddressField;
        
        private string subjectField;
        
        private string messageField;
        
        private System.DateTime dateTimeField;
        
        private bool dateTimeFieldSpecified;
        
        
        public string messageIdentifier {
            get {
                return this.messageIdentifierField;
            }
            set {
                this.messageIdentifierField = value;
            }
        }
        
        
        public UserIdType destinationAddress {
            get {
                return this.destinationAddressField;
            }
            set {
                this.destinationAddressField = value;
            }
        }
        
        
        public UserIdType originAddress {
            get {
                return this.originAddressField;
            }
            set {
                this.originAddressField = value;
            }
        }
        
        
        public string subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
            }
        }

        
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        
        public System.DateTime dateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateTimeSpecified {
            get {
                return this.dateTimeFieldSpecified;
            }
            set {
                this.dateTimeFieldSpecified = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedMessageAsync", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class ReceivedMessageAsyncType {
        
        private string correlatorField;
        
        private MessageReferenceType messageField;
        
        
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
        
        
        public MessageReferenceType message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("messageNotification", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class MessageNotificationType {
        
        private SimpleReferenceType referenceField;
        
        private UserIdType[] destinationAddressField;
        
        private string criteriaField;
        
        
        public SimpleReferenceType reference {
            get {
                return this.referenceField;
            }
            set {
                this.referenceField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlElementAttribute("destinationAddress")]
        public UserIdType[] destinationAddress {
            get {
                return this.destinationAddressField;
            }
            set {
                this.destinationAddressField = value;
            }
        }
        
        
        public string criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
}
