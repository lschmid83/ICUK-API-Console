using API.Core.Exceptions;
using System;
using System.Net;
using System.Web.Http.Filters;

namespace API.Controllers {

    /// <summary>
    /// Custom attribute which hides control panel method exception details.
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute {

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="context">HttpActionExecutedContext.</param>
        public override void OnException(HttpActionExecutedContext context) {
            if (context.Exception is Exception && context.Exception.GetType().ToString() != "API.Core.Exceptions.InvalidParameterException") {
                throw new InternalApiException("Internal API exception occured", HttpStatusCode.BadRequest);
            }
        }
    }
}