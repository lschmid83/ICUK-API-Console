using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API enum member documentation.
    /// </summary>
    public class XmlMemberComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Field.
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Value.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Validates API return type property documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The [Description] attribute is missing or blank.", MemberInfo);

            if (String.IsNullOrWhiteSpace(Summary))
                throw new XmlCommentException("The <summary> element is missing or blank.", MemberInfo);
        }

        /// <summary>
        /// Constructs a JSON string from the properties.
        /// </summary>
        /// <returns>JSON string.</returns>
        public string ToJson() {

            StringBuilder json = new StringBuilder();

            json.Append(@"
        {");

            json.Append(@"
            ""field"": """ + Field + @""",
            ""value"": " + Value + @",
            ""description"": """ + Description + @""",
            ""summary"": """ + Summary + @"""
        },");

            return json.ToString();

        }


    }
}