using API.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace API.Core {

    /// <summary>
    /// Handler for logging API requests.
    /// </summary>
    public class LoggingHandler : DelegatingHandler {

        /// <summary>
        /// Asynchronous task for logging the API request.
        /// </summary>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            // Call the inner handler.
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            request.RequestUri = RouteUtil.RemoveEmptyParam(request.RequestUri);
            return response;
        }
    }
}