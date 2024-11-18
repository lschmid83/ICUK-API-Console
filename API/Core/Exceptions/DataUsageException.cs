using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Core.Exceptions {
    /// <summary>
    /// Represents data usage errors that occur during application execution.
    /// </summary>
    public class DataUsageException : HttpResponseException {

        /// <summary>
        /// Initializes a new instance of the DataUsageException class.
        /// </summary>
        /// <param name="message">Description of the exception.</param>
        /// <param name="status">HTTP status code.</param>
        /// <param name="reason">Short description of the status code.</param>
        public DataUsageException(string message, HttpStatusCode status = HttpStatusCode.BadRequest, string reason = null)
            : base(new ApiExceptionMessage(message, typeof(DataUsageException).Name, status, reason)) {
        }

    }

}