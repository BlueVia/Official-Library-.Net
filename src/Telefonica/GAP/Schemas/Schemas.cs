// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.SGAP.Schemas {

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("adRequest", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/", IsNullable = false)]
    public partial class SimpleAdRequestType
    {

        private string ad_request_idField;

        private string ad_presentationField;

        private string ad_spaceField;

        private string user_agentField;

        private string keywordsField;

        private string protecion_policyField;

        private string countryField;

        private string target_user_idField;

        /// <remarks/>
        public string ad_request_id
        {
            get
            {
                return this.ad_request_idField;
            }
            set
            {
                this.ad_request_idField = value;
            }
        }

        /// <remarks/>
        public string ad_presentation
        {
            get
            {
                return this.ad_presentationField;
            }
            set
            {
                this.ad_presentationField = value;
            }
        }

        /// <remarks/>
        public string ad_space
        {
            get
            {
                return this.ad_spaceField;
            }
            set
            {
                this.ad_spaceField = value;
            }
        }

        /// <remarks/>
        public string user_agent
        {
            get
            {
                return this.user_agentField;
            }
            set
            {
                this.user_agentField = value;
            }
        }

        /// <remarks/>
        public string keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
            }
        }

        /// <remarks/>
        public string protecion_policy
        {
            get
            {
                return this.protecion_policyField;
            }
            set
            {
                this.protecion_policyField = value;
            }
        }

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string target_user_id
        {
            get
            {
                return this.target_user_idField;
            }
            set
            {
                this.target_user_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    [System.Xml.Serialization.XmlRootAttribute("adResponse", Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/", IsNullable = false)]
    public partial class SimpleAdResponseType
    {

        private AdType adField;

        private string idField;

        private string versionField;

        /// <remarks/>
        public AdType ad
        {
            get
            {
                return this.adField;
            }
            set
            {
                this.adField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    public partial class AdType
    {

        private ResourceType resourceField;

        private string idField;

        private string campaignField;

        private string flightField;

        private string ad_placementField;

        /// <remarks/>
        public ResourceType resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campaign
        {
            get
            {
                return this.campaignField;
            }
            set
            {
                this.campaignField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string flight
        {
            get
            {
                return this.flightField;
            }
            set
            {
                this.flightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ad_placement
        {
            get
            {
                return this.ad_placementField;
            }
            set
            {
                this.ad_placementField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    public partial class ResourceType
    {

        private CreativeElementType[] creative_elementField;

        private string ad_presentationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("creative_element")]
        public CreativeElementType[] creative_element
        {
            get
            {
                return this.creative_elementField;
            }
            set
            {
                this.creative_elementField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ad_presentation
        {
            get
            {
                return this.ad_presentationField;
            }
            set
            {
                this.ad_presentationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    public partial class CreativeElementType
    {

        private AttributeType[] attributeField;

        private InteractionType[] interactionField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public AttributeType[] attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("interaction")]
        public InteractionType[] interaction
        {
            get
            {
                return this.interactionField;
            }
            set
            {
                this.interactionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    public partial class AttributeType
    {

        private string typeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telefonica.com/schemas/UNICA/REST/sgap/v1/")]
    public partial class InteractionType
    {

        private AttributeType[] attributeField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public AttributeType[] attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    }
}
