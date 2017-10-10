using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCodeTool
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "mapping", Namespace = "", IsNullable = false)]
    public class mappingentity
    {

        private mappingMap[] mapField;

        private mappingFOREACH[] fOREACHField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("map")]
        public mappingMap[] map
        {
            get
            {
                return this.mapField;
            }
            set
            {
                this.mapField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FOREACH")]
        public mappingFOREACH[] FOREACH
        {
            get
            {
                return this.fOREACHField;
            }
            set
            {
                this.fOREACHField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class mappingMap
    {

        private string sourceField;

        private string operateField;

        private string targetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string operate
        {
            get
            {
                return this.operateField;
            }
            set
            {
                this.operateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class mappingFOREACH
    {

        private mappingMap[] mapField;

        private string sourceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("map")]
        public mappingMap[] map
        {
            get
            {
                return this.mapField;
            }
            set
            {
                this.mapField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
    }


}
