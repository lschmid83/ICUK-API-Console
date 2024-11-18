using API.Core.XmlComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API documentation page details.
    /// </summary>
    public class XmlPageComment : XmlCommentBase, IXmlComment {
        
        /// <summary>
        /// Page heading.
        /// </summary>
        public string Heading { get; set; }
        /// <summary>
        /// Module title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Module description. 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Page version. 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Timestamp of when the documentation was generated.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Validates API documentation page details.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Heading))
                throw new XmlCommentException("The <heading> element is missing or blank.", PropertyInfo);

            if (String.IsNullOrWhiteSpace(Heading))
                throw new XmlCommentException("The <heading> element is missing or blank.", PropertyInfo);

            if (String.IsNullOrWhiteSpace(Version))
                throw new XmlCommentException("The <version> element is missing or blank.", PropertyInfo);
            
            if (String.IsNullOrWhiteSpace(Timestamp))
                throw new XmlCommentException("The <timestamp> element is missing or blank.", PropertyInfo);
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
    ""heading"": """ + Heading + @""",
    ""title"": """ + Title  + @""",
    ""description"": """ + Description + @""",
    ""generator"": { 
        ""version"": """ + Version + @""", 
        ""time"": """ + Timestamp + @"""
    }
}");

            return json.ToString();

        }

    }
}