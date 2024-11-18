using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API method parameter documentation.
    /// </summary>
    public class XmlParameterComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Type of parameter.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Optional flag.
        /// </summary>
        public bool Optional { get; set; }
        /// <summary>
        /// Description of the parameter.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Is the parameter part of the body of the request.
        /// </summary>
        public bool FromBody { get; set; }
        /// <summary>
        /// Is this a URL parameter.
        /// </summary>
        public bool IsUrlParam { get; set; }
        /// <summary>
        /// Adds or subtracts a working number of days to the current date.
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// Display date picker with date option.
        /// </summary>
        public bool Date { get; set; }
        /// <summary>
        /// Display date picker with time option.
        /// </summary>
        public bool Time { get; set; }
        /// <summary>
        /// Validates API method parameter documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Type))
                throw new XmlCommentException("The <parameter> -> <type> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Field))
                throw new XmlCommentException("The <parameter> -> <field> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The <parameter> -> <description> element is missing or blank.", MethodInfo);

            if (!Date && !Time)
                throw new XmlCommentException("The <parameter> -> <date> or <time> must be true.", MethodInfo);
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
            ""type"": """ + Type + @""",
            ""field"": """ + Field + @""",
            ""optional"": " + Optional.ToLower() + @",
            ""frombody"": " + FromBody.ToLower() + @",
            ""day"": " + Day + @",
            ""time"": " + Time.ToLower() + @",
            ""date"": " + Date.ToLower() + @",
            ""description"": """ + Description + @"""
        },");

            return json.ToString();

        }
    }
    
}