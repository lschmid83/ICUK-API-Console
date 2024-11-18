using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Core.Exceptions {
    /// <summary>
    /// Represents errors which occur because accounts are not live.
    /// </summary>
    public class NotLiveException : HttpResponseException {

        /// <summary>
        /// Initializes a new instance of the NotLiveException class.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="status">HTTP status code.</param>
        /// <param name="reason">Short description of the status code.</param>
        public NotLiveException(string message, HttpStatusCode status = HttpStatusCode.BadRequest, string reason = null)
            : base(new ApiExceptionMessage(message, typeof(NotLiveException).Name, status, reason)) {
        }
    }

}