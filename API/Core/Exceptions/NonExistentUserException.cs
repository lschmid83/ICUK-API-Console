using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Core.Exceptions {
    /// <summary>
    /// Represents non existent user errors that occur during application execution.
    /// </summary>
    public class NonExistentUserException : HttpResponseException {

        /// <summary>
        /// Initializes a new instance of the NonExistentUserException class.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="status">HTTP status code.</param>
        /// <param name="reason">Short description of the status code.</param>
        public NonExistentUserException(string message, HttpStatusCode status = HttpStatusCode.BadRequest, string reason = null)
            : base(new ApiExceptionMessage(message, typeof(NonExistentUserException).Name, status, reason)) {
        }
    }
}