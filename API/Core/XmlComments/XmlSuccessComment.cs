using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API method success documentation.
    /// </summary>
    public class XmlSuccessComment : XmlCommentBase, IXmlComment {
       
        /// <summary>
        /// Type of success response.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Name of success field or type.
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Optional flag.
        /// </summary>
        public bool Optional { get; set; }
        /// <summary>
        /// Description of success response.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Validates API method success documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Type))
                throw new XmlCommentException("The <success> -> <type> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Field))
                throw new XmlCommentException("The <success> -> <field> element is missing or blank.", MethodInfo);

             if (String.IsNullOrWhiteSpace(Description))
                 throw new XmlCommentException("The <success> -> <description> element is missing or blank.", MethodInfo);
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
            ""type"": """ + Type.ToString() + @""",
            ""field"": """ + Field + @""",
            ""optional"": " + Optional.ToLower() + @",
            ""description"": """ + Description + @"""
        },");
            
            return json.ToString();

        }

    }
}