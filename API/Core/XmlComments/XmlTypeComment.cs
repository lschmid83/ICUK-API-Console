using API.Controllers;
using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API return type documentation.
    /// </summary>
    public class XmlTypeComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Name of the type.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the type.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Controller the method belongs to.
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Specifies which API user types are allowed to access the type.
        /// </summary>
        public ApiUserTypes UserType { get; set; }
        /// <summary>
        /// List of type properties.
        /// </summary>
        public List<XmlPropertyComment> Properties { get; set; }

        /// <summary>
        /// Validates API return type documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Name))
                throw new XmlCommentException("The <name> element is missing or blank.", PropertyInfo);

            if (String.IsNullOrWhiteSpace(Group))
                throw new XmlCommentException("The <group> element is missing or blank.", PropertyInfo);

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The <description> element is missing or blank.", PropertyInfo);

            if(Properties == null || Properties.Count == 0)
                throw new XmlCommentException("There are property comments missing.", PropertyInfo);

            ValidateFields<XmlPropertyComment>(Properties);
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
    ""name"": """ + Name + @""",
    ""group"": """ + Group + @""",
    ""user_type"": " + (uint)UserType + @",
    ""description"": """ + Description + @""",");
            
            if (Properties != null && Properties.Count > 0) {

                json.Append(@"
    ""property"": {
        ""fields"": [");

                foreach (XmlPropertyComment field in Properties)
                    json.Append(field.ToJson());

                json.Remove(json.Length - 1, 1);

                json.Append(@"
        ]
    }");

            }

            json.Append(@"
},");


            return json.ToString();

        }
  
     }
}