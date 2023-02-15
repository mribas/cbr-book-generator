namespace Renamer.Entidades
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.idpf.org/2007/opf")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.idpf.org/2007/opf", IsNullable = false)]
    public partial class package
    {
        private packageMetadata metadataField;

        private packageGuide guideField;

        private string uniqueidentifierField;

        private decimal versionField;

        /// <remarks/>
        public packageMetadata metadata
        {
            get
            {
                return this.metadataField;
            }
            set
            {
                this.metadataField = value;
            }
        }

        /// <remarks/>
        public packageGuide guide
        {
            get
            {
                return this.guideField;
            }
            set
            {
                this.guideField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("unique-identifier")]
        public string uniqueidentifier
        {
            get
            {
                return this.uniqueidentifierField;
            }
            set
            {
                this.uniqueidentifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
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
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.idpf.org/2007/opf")]
    public partial class packageMetadata
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("contributor", typeof(contributor), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("creator", typeof(creator), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("date", typeof(System.DateTime), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("description", typeof(string), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("identifier", typeof(identifier), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("language", typeof(string), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("publisher", typeof(string), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("title", typeof(string), Namespace = "http://purl.org/dc/elements/1.1/")]
        [System.Xml.Serialization.XmlElementAttribute("meta", typeof(packageMetadataMeta))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/dc/elements/1.1/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://purl.org/dc/elements/1.1/", IsNullable = false)]
    public partial class contributor
    {

        private string fileasField;

        private string roleField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("file-as", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.idpf.org/2007/opf")]
        public string fileas
        {
            get
            {
                return this.fileasField;
            }
            set
            {
                this.fileasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.idpf.org/2007/opf")]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
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
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/dc/elements/1.1/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://purl.org/dc/elements/1.1/", IsNullable = false)]
    public partial class creator
    {

        private string fileasField;

        private string roleField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("file-as", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.idpf.org/2007/opf")]
        public string fileas
        {
            get
            {
                return this.fileasField;
            }
            set
            {
                this.fileasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.idpf.org/2007/opf")]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
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
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/dc/elements/1.1/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://purl.org/dc/elements/1.1/", IsNullable = false)]
    public partial class identifier
    {

        private string schemeField;

        private string idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.idpf.org/2007/opf")]
        public string scheme
        {
            get
            {
                return this.schemeField;
            }
            set
            {
                this.schemeField = value;
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
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.idpf.org/2007/opf")]
    public partial class packageMetadataMeta
    {

        private string nameField;

        private string contentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.idpf.org/2007/opf", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:contributor")]
        contributor,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:creator")]
        creator,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:date")]
        date,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:description")]
        description,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:identifier")]
        identifier,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:language")]
        language,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:publisher")]
        publisher,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("http://purl.org/dc/elements/1.1/:title")]
        title,

        /// <remarks/>
        meta,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.idpf.org/2007/opf")]
    public partial class packageGuide
    {

        private packageGuideReference referenceField;

        /// <remarks/>
        public packageGuideReference reference
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.idpf.org/2007/opf")]
    public partial class packageGuideReference
    {

        private string typeField;

        private string titleField;

        private string hrefField;

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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
    }


}
