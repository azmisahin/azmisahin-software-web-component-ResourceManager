namespace @as.Localization.Models
{
    /// <summary>
    /// Resource Model
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Root
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class root
        {
            private LocaleStringResource[] dataField;

            /// <summary>
            /// data
            /// </summary>
            [System.Xml.Serialization.XmlElementAttribute("data")]
            public LocaleStringResource[] data
            { get { return this.dataField; } set { this.dataField = value; } }
        }

        /// <summary>
        /// Data
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class LocaleStringResource
        {
            private string valueField;
            private string commentField;
            private byte languageIdField;
            private string nameField;

            /// <summary>
            /// Value
            /// </summary>
            public string value
            {
                get { return this.valueField; }
                set { this.valueField = value; }
            }

            /// <summary>
            /// Comment
            /// </summary>
            public string comment
            {
                get { return this.commentField; }
                set { this.commentField = value; }
            }

            /// <summary>
            /// Language Id
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte languageId
            {
                get { return this.languageIdField; }
                set { this.languageIdField = value; }
            }

            /// <summary>
            /// name
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get { return this.nameField; }
                set { this.nameField = value; }
            }
        }
    }
}
