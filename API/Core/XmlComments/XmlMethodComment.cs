using API.Controllers;
using API.Core.Enum;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API method documentation.
    /// </summary>
    public class XmlMethodComment : XmlCommentBase, IXmlComment {

        /// <summary>
        /// Name of the method.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of Http request.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Description of method.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Flag to indicate a parameter is included as part of the URL.
        /// </summary>
        public bool UrlParam { get; set; }
        /// <summary>
        /// Specifies which API user types are allowed to access the method.
        /// </summary>
        public ApiUserTypes UserType { get; set; }
        /// <summary>
        /// Controller name.
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// Description of controller.
        /// </summary>
        public string ControllerDescription { get; set; }
        /// <summary>
        /// Url of method.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Method group.
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// List of parameters.
        /// </summary>
        public List<XmlParameterComment> Parameters { get; set; }
        /// <summary>
        /// List of success fields.
        /// </summary>
        public List<XmlSuccessComment> Success { get; set; }
        /// <summary>
        /// List of error responses.
        /// </summary>
        public List<XmlErrorComment> Error { get; set; }
        /// <summary>
        /// List of example responses.
        /// </summary>
        public List<XmlExampleComment> Example { get; set; }
        /// <summary>
        /// API module information.
        /// </summary>
        public ApiModule ApiModule { get; set; }

        /// <summary>
        /// XmlMethodComment.
        /// </summary>
        public XmlMethodComment() {

            Parameters = new List<XmlParameterComment>();
            Success = new List<XmlSuccessComment>();
            Error = new List<XmlErrorComment>();
            Example = new List<XmlExampleComment>();
        }

        /// <summary>
        /// Validates API method documentation.
        /// </summary>
        public void Validate() {

            // Check for duplicate fields
            if (Success != null && Success.Count > 1) {
                throw new XmlCommentException("There are duplicate <success> elements.", MethodInfo);
            }

            if (Parameters != null) {
                var dupeParameterField = Parameters.GroupBy(i => new { i.Field }).Where(g => g.Count() > 1).Select(g => g.Key);
                if (dupeParameterField.Count() > 0)
                    throw new XmlCommentException("There are duplicate <parameter> elements.", MethodInfo);
            }

            if (Error != null) {
                var dupeErrorField = Error.GroupBy(i => new { Field = i.Type }).Where(g => g.Count() > 1).Select(g => g.Key);
                if (dupeErrorField.Count() > 0)
                    throw new XmlCommentException("There are duplicate <error> elements.", MethodInfo);
            }

            if (Example != null) {

                if(Example.Count == 0)
                    throw new XmlCommentException("The <example> element is missing or blank.", MethodInfo);

                var dupeExampleField = Example.GroupBy(i => new { i.Title }).Where(g => g.Count() > 1).Select(g => g.Key);
                if (dupeExampleField.Count() > 0)
                    throw new XmlCommentException("There are duplicate <example> elements.", MethodInfo);
            }


            if (String.IsNullOrWhiteSpace(Name))
                throw new XmlCommentException("The <name> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Description))
                throw new XmlCommentException("The <description> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(ControllerDescription))
                throw new XmlCommentException("The controller module <description> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Type))
                throw new XmlCommentException("The <type> element is missing or blank.", MethodInfo);

            if(!IsValidHttpMethod(Type.ToUpper()))
                throw new XmlCommentException("The <type> element must be GET, PUT, POST or DELETE.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Url))
                throw new XmlCommentException("The <url> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Group))
                throw new XmlCommentException("The <group> element is missing or blank.", MethodInfo);
            
            ValidateFields<XmlSuccessComment>(Success);
            ValidateFields<XmlParameterComment>(Parameters);
            ValidateFields<XmlErrorComment>(Error);
            ValidateFields<XmlExampleComment>(Example);

        }

        /// <summary>
        /// Validates HTTP method fields.
        /// </summary>
        /// <param name="method">Mehtod name.</param>
        /// <returns>True if valid HTTP method; otherwise false.</returns>
        public bool IsValidHttpMethod(string method) {

            if (method.Equals("GET") || method.Equals("PUT") || method.Equals("POST") || method.Equals("DELETE"))
                return true;
            else
                return false;
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
    ""type"": """ + Type.ToUpper() + @""",
    ""url"": """ + Url + @""",
    ""url_param"": " + UrlParam.ToLower() + @",
    ""user_type"": " + (uint)UserType + @",
    ""group"": """ + Group + @""",
    ""controller_name"": """ + ControllerName + @""",
    ""controller"": """ + ControllerDescription + @""",
    ""description"": """ + Description + @""",");

            // Request parameters
            if (Parameters != null && Parameters.Count > 0) {

                json.Append(@"
    ""parameter"": {
        ""fields"": [");

                foreach(XmlParameterComment parameters in Parameters)
                    json.Append(parameters.ToJson());

                json.Remove(json.Length - 1, 1);

                json.Append(@"
        ]
    },");

            }

            // Success response
            if (Success != null && Success.Count > 0) {

                json.Append(@"
    ""success"": {
        ""fields"": [");

                foreach (XmlSuccessComment success in Success)
                    json.Append(success.ToJson());

                json.Remove(json.Length - 1, 1);

                json.Append(@"
        ]
    },");

            }

            // Error responses
            json.Append(@"
    ""error"": {");

            json.Append(@"
        ""fields"": [");

            // Error fields
            if (Error != null && Error.Count > 0) {
                foreach (XmlErrorComment error in Error)
                    json.Append(error.ToJson());

                json.Remove(json.Length - 1, 1);
            }

            json.Append(@"
        ],");

            json.Append(@"
        ""examples"": [");

            // Example fields
            if (Example != null && Example.Count > 0) {
                foreach (XmlExampleComment example in Example)
                    json.Append(example.ToJson());

                json.Remove(json.Length - 1, 1);
            }

            json.Append(@"
        ]");

            json.Append(@"
    }");

            json.Append(@"
},");

            return json.ToString();
        }

    }
}