using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace API.Core.Exceptions {

    /// <summary>
    /// Represents invalid parameter errors that occur during application execution.
    /// </summary>
    public class InvalidParameterException : HttpResponseException {

        /// <summary>
        /// Initializes a new instance of the InvalidParameterException class.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="status">HTTP status code.</param>
        /// <param name="reason">Short description of the status code.</param>
        public InvalidParameterException(string message, HttpStatusCode status = HttpStatusCode.BadRequest, string reason = null)
            : base(new ApiExceptionMessage(message, typeof(InvalidParameterException).Name, status, reason)) {
        }
    }
}