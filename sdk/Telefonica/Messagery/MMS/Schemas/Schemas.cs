﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.261
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace Bluevia.Messagery.MMS.Schemas {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
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
        
        /// <remarks/>
        public ClientExceptionTypeExceptionCategory exceptionCategory {
            get {
                return this.exceptionCategoryField;
            }
            set {
                this.exceptionCategoryField = value;
            }
        }
        
        /// <remarks/>
        public int exceptionId {
            get {
                return this.exceptionIdField;
            }
            set {
                this.exceptionIdField = value;
            }
        }
        
        /// <remarks/>
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ClientExceptionTypeExceptionCategory {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    [System.Xml.Serialization.XmlRootAttribute("ServerException", Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IsNullable=false)]
    public partial class ServerExceptionType {
        
        private ServerExceptionTypeExceptionCategory exceptionCategoryField;
        
        private int exceptionIdField;
        
        private string textField;
        
        private string[] variablesField;
        
        /// <remarks/>
        public ServerExceptionTypeExceptionCategory exceptionCategory {
            get {
                return this.exceptionCategoryField;
            }
            set {
                this.exceptionCategoryField = value;
            }
        }
        
        /// <remarks/>
        public int exceptionId {
            get {
                return this.exceptionIdField;
            }
            set {
                this.exceptionIdField = value;
            }
        }
        
        /// <remarks/>
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public enum ServerExceptionTypeExceptionCategory {
        
        /// <remarks/>
        SVR,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("message", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class MessageType {
        
        private UserIdType[] addressField;
        
        private SimpleReferenceType receiptRequestField;
        
        private string senderNameField;
        
        private UserIdType originAddressField;
        
        private string subjectField;
        
        private string priorityField;
        
        private LocationInfoType locationAdditionalInfoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("address")]
        public UserIdType[] address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public SimpleReferenceType receiptRequest {
            get {
                return this.receiptRequestField;
            }
            set {
                this.receiptRequestField = value;
            }
        }
        
        /// <remarks/>
        public string senderName {
            get {
                return this.senderNameField;
            }
            set {
                this.senderNameField = value;
            }
        }
        
        /// <remarks/>
        public UserIdType originAddress {
            get {
                return this.originAddressField;
            }
            set {
                this.originAddressField = value;
            }
        }
        
        /// <remarks/>
        public string subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
            }
        }
        
        /// <remarks/>
        public string priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public LocationInfoType locationAdditionalInfo {
            get {
                return this.locationAdditionalInfoField;
            }
            set {
                this.locationAdditionalInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class UserIdType {
        
        private object itemField;
        
        private ItemChoiceType1 itemElementNameField;
        
        /// <remarks/>
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
        
        /// <remarks/>
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class IpAddressType {
        
        private string itemField;
        
        private ItemChoiceType itemElementNameField;
        
        /// <remarks/>
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
        
        /// <remarks/>
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema=false)]
    public enum ItemChoiceType {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class OtherIdType {
        
        private string typeField;
        
        private string valueField;
        
        /// <remarks/>
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1", IncludeInSchema=false)]
    public enum ItemChoiceType1 {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/common/v1")]
    public partial class SimpleReferenceType {
        
        private string endpointField;
        
        private string correlatorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string endpoint {
            get {
                return this.endpointField;
            }
            set {
                this.endpointField = value;
            }
        }
        
        /// <remarks/>
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class LocationInfoType {
        
        private RetrievalStatusType reportStatusField;
        
        private CoordinatesType coordinatesField;
        
        private float altitudeField;
        
        private bool altitudeFieldSpecified;
        
        private int accuracyField;
        
        private bool accuracyFieldSpecified;
        
        private System.DateTime timestampField;
        
        /// <remarks/>
        public RetrievalStatusType reportStatus {
            get {
                return this.reportStatusField;
            }
            set {
                this.reportStatusField = value;
            }
        }
        
        /// <remarks/>
        public CoordinatesType coordinates {
            get {
                return this.coordinatesField;
            }
            set {
                this.coordinatesField = value;
            }
        }
        
        /// <remarks/>
        public float altitude {
            get {
                return this.altitudeField;
            }
            set {
                this.altitudeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool altitudeSpecified {
            get {
                return this.altitudeFieldSpecified;
            }
            set {
                this.altitudeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int accuracy {
            get {
                return this.accuracyField;
            }
            set {
                this.accuracyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool accuracySpecified {
            get {
                return this.accuracyFieldSpecified;
            }
            set {
                this.accuracyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public enum RetrievalStatusType {
        
        /// <remarks/>
        Retrieved,
        
        /// <remarks/>
        NonAuthorized,
        
        /// <remarks/>
        NonRegistered,
        
        /// <remarks/>
        LocationNonAvailable,
        
        /// <remarks/>
        Error,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class CoordinatesType {
        
        private float latitudeField;
        
        private float longitudeField;
        
        /// <remarks/>
        public float latitude {
            get {
                return this.latitudeField;
            }
            set {
                this.latitudeField = value;
            }
        }
        
        /// <remarks/>
        public float longitude {
            get {
                return this.longitudeField;
            }
            set {
                this.longitudeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("messageDeliveryStatus", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class MessageDeliveryStatusType {
        
        private DeliveryInformationType[] messageDeliveryStatusField;
        
        /// <remarks/>
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class DeliveryInformationType {
        
        private UserIdType addressField;
        
        private string deliveryStatusField;
        
        private string descriptionField;
        
        /// <remarks/>
        public UserIdType address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string deliveryStatus {
            get {
                return this.deliveryStatusField;
            }
            set {
                this.deliveryStatusField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedMessages", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class ReceivedMessagesType {
        
        private MessageReferenceType[] receivedMessagesField;
        
        /// <remarks/>
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
    
    /// <remarks/>
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
        
        private string priorityField;
        
        private string messageField;
        
        private System.DateTime dateTimeField;
        
        private bool dateTimeFieldSpecified;
        
        private MessageURIType[] attachmentURLField;
        
        private LocationInfoType locationAdditionalInfoField;
        
        /// <remarks/>
        public string messageIdentifier {
            get {
                return this.messageIdentifierField;
            }
            set {
                this.messageIdentifierField = value;
            }
        }
        
        /// <remarks/>
        public UserIdType destinationAddress {
            get {
                return this.destinationAddressField;
            }
            set {
                this.destinationAddressField = value;
            }
        }
        
        /// <remarks/>
        public UserIdType originAddress {
            get {
                return this.originAddressField;
            }
            set {
                this.originAddressField = value;
            }
        }
        
        /// <remarks/>
        public string subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
            }
        }
        
        /// <remarks/>
        public string priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime dateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateTimeSpecified {
            get {
                return this.dateTimeFieldSpecified;
            }
            set {
                this.dateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attachmentURL")]
        public MessageURIType[] attachmentURL {
            get {
                return this.attachmentURLField;
            }
            set {
                this.attachmentURLField = value;
            }
        }
        
        /// <remarks/>
        public LocationInfoType locationAdditionalInfo {
            get {
                return this.locationAdditionalInfoField;
            }
            set {
                this.locationAdditionalInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    public partial class MessageURIType {
        
        private string hrefField;
        
        private string contentTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string href {
            get {
                return this.hrefField;
            }
            set {
                this.hrefField = value;
            }
        }
        
        /// <remarks/>
        public string contentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("deliveryStatusUpdate", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class DeliveryStatusUpdateType {
        
        private string correlatorField;
        
        private DeliveryInformationType deliveryStatusField;
        
        /// <remarks/>
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
        
        /// <remarks/>
        public DeliveryInformationType deliveryStatus {
            get {
                return this.deliveryStatusField;
            }
            set {
                this.deliveryStatusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("deliveryReceiptNotification", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class DeliveryReceiptNotificationType {
        
        private SimpleReferenceType referenceField;
        
        private UserIdType[] originAddressField;
        
        private string filterCriteriaField;
        
        /// <remarks/>
        public SimpleReferenceType reference {
            get {
                return this.referenceField;
            }
            set {
                this.referenceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("originAddress")]
        public UserIdType[] originAddress {
            get {
                return this.originAddressField;
            }
            set {
                this.originAddressField = value;
            }
        }
        
        /// <remarks/>
        public string filterCriteria {
            get {
                return this.filterCriteriaField;
            }
            set {
                this.filterCriteriaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("receivedMessageAsync", Namespace="http://www.telefonica.com/schemas/UNICA/REST/mms/v1/", IsNullable=false)]
    public partial class ReceivedMessageAsyncType {
        
        private string correlatorField;
        
        private MessageReferenceType messageField;
        
        /// <remarks/>
        public string correlator {
            get {
                return this.correlatorField;
            }
            set {
                this.correlatorField = value;
            }
        }
        
        /// <remarks/>
        public MessageReferenceType message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
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
        
        private bool useAttachmentURLsField;
        
        private bool useAttachmentURLsFieldSpecified;
        
        /// <remarks/>
        public SimpleReferenceType reference {
            get {
                return this.referenceField;
            }
            set {
                this.referenceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("destinationAddress")]
        public UserIdType[] destinationAddress {
            get {
                return this.destinationAddressField;
            }
            set {
                this.destinationAddressField = value;
            }
        }
        
        /// <remarks/>
        public string criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
        
        /// <remarks/>
        public bool useAttachmentURLs {
            get {
                return this.useAttachmentURLsField;
            }
            set {
                this.useAttachmentURLsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool useAttachmentURLsSpecified {
            get {
                return this.useAttachmentURLsFieldSpecified;
            }
            set {
                this.useAttachmentURLsFieldSpecified = value;
            }
        }
    }
}