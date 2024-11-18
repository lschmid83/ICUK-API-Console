using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API return type property documentation.
    /// </summary>
    public class XmlPropertyComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Type of property.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Property name.
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Optional flag.
        /// </summary>
        public bool Optional { get; set; }
        /// <summary>
        /// Readonly flag.
        /// </summary>
        public bool ReadOnly { get; set; }
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
        /// Description of the property.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Validates API return type property documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Type))
                throw new XmlCommentException("The <property> -> <type> element is missing or blank.", PropertyInfo);
            
            if (String.IsNullOrWhiteSpace(Field))
                throw new XmlCommentException("The <property> -> <field> element is missing or blank.", PropertyInfo);

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The <property> -> <description> element is missing or blank.", PropertyInfo);

            if (!Date && !Time)
                throw new XmlCommentException("The <property> -> <date> or <time> must be true.", PropertyInfo);
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
            ""day"": " + Day + @",
            ""time"": " + Time.ToLower() + @",
            ""date"": " + Date.ToLower() + @",
            ""read_only"": " + ReadOnly.ToLower() + @",
            ""description"": """ + Description + @"""
        },");

            return json.ToString();

        }

    }
}