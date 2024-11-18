using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;

namespace API.Core {

    /// <summary>
    /// Handler for determining whether the connecting host has access to the API.
    /// </summary>
    public class HostHandler : DelegatingHandler {

        /// <summary>
        /// Asynchronous task for checking the host.
        /// </summary>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            return base.SendAsync(request, cancellationToken);
        }


        /// <summary>
        /// Get host address.
        /// </summary>
        /// <returns>Local or production API host address.</returns>
        public static string GetHostAddress() {

            return "";
        }
    }

}
