using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace API.Core.Exceptions {

    /// <summary>
    /// Represents an API exception message.
    /// </summary>
    public class ApiExceptionMessage : HttpResponseMessage {

        /// <summary>
        /// Constructs an API exception message.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="type">Type of exception.</param>
        /// <param name="status">HTTT status code.</param>
        /// <param name="reasonPhrase">Short description of the status code.</param>
        public ApiExceptionMessage(string message, string type, HttpStatusCode status, string reasonPhrase = null) {
            base.Content = GetExceptionMessage(message, type, status);
            if (reasonPhrase != null)
                base.ReasonPhrase = reasonPhrase;
            else
                base.ReasonPhrase = message;
            base.StatusCode = status;
        }
        
        /// <summary>
        /// Gets a JSON string containing the exception message.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="type">Type of exception.</param>
        /// <param name="status">Status code.</param>
        /// <returns>JSON string contaning the exception message.</returns>
        public StringContent GetExceptionMessage(string message, string type, HttpStatusCode status) {

            JObject json = new JObject();
            json.Add("exception_message", message);
            json.Add("exception_type", type);
            return new StringContent(json.ToString());

        }
    }
}