using API.Core;
using API.Core.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Controllers {

    /// <summary>
    /// Custom attribute which deserializes message body parameters.
    /// </summary>
    public class ApiFromBodyFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute {

        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Parameter type.
        /// </summary>
        public Type DataType { get; set; }

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="actionContext">HttpActionContext</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext) {

            // Get the request body stream.
            System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Request.InputStream);

            // Web Api's formatters will consume the stream and will not try to rewind it back.
            stream.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            // Read JSON string from the content stream.
            string inputContent = stream.ReadToEnd();
            inputContent = inputContent.TrimStart('=');

            List<string> errors = new List<string>();

            // Deserialize JSON into the parameter type
            // Note: Properties marked with [DataMember(IsRequired = true)] will throw a JsonSerializationException 
            // when a missing member is encountered during deserialization.
            var result = JsonConvert.DeserializeObject(inputContent, DataType,
                            new JsonSerializerSettings {
                                Error = delegate(object sender, ErrorEventArgs args) {
                                    errors.Add(args.ErrorContext.Error.Message);
                                    args.ErrorContext.Handled = true;
                                },
                                MissingMemberHandling = MissingMemberHandling.Error,
                                ContractResolver = new JsonSerializerContract()
                            });

            // Throw InvalidParameterException if there were errors deserializing the parameter type.
            if (errors.Count > 0) {

                StringBuilder message = new StringBuilder();
                foreach (string error in errors) {
                    message.AppendLine(error);
                }
                throw new InvalidParameterException(message.ToString(), System.Net.HttpStatusCode.BadRequest, "Invalid request body parameter.");
            }

            actionContext.ActionArguments[Parameter] = result;
            base.OnActionExecuting(actionContext);
        }
    }
}