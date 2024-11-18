using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API method error documentation.
    /// </summary>
    public class XmlErrorComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Name of the error. 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Description of the error.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Validates API method error documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Type))
                throw new XmlCommentException("The <error> -> <type> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The <error> -> <description> element is missing or blank.", MethodInfo);

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
            ""field"": """ + Type + @""",
            ""description"": """ + Description + @"""
        },");
            
            return json.ToString();

        }

    }
}