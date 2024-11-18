using API.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace API.Core {

    /// <summary>
    /// Utility class for handling Web API routes.
    /// </summary>
    public class RouteUtil {

        /// <summary>
        /// Gets the route path defined in WebApiConfig for a API method route.
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <param name="routeName">The name of the route.</param>
        public static string GetRoutePath(HttpRequestMessage request, string routeName) {

            UrlHelper urlHelper = new UrlHelper(request);

            if (request.RequestUri.Port == 801) {
                return urlHelper.Link(routeName, null).Replace(":801", null).Replace("http://", "https://");
            }
            else {
                return urlHelper.Link(routeName, null);
            }
        }

        /// <summary>
        /// Gets the route path for the request URL.
        /// </summary>
        /// <param name="request">HttpRequestMessage.</param>
        /// <returns>Route path for the request URL.</returns>
        public static string GetRoutePath(HttpRequestMessage request) {
                 
            // Get route data for request URL
            IHttpRouteData routeData = request.GetRouteData().Route.GetRouteData(request.RequestUri.AbsolutePath.ToString(), request);
            IDictionary<string, object> values = routeData.Values;

            string routePath = String.Empty;

            // Get the query parameters.
            NameValueCollection queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query);
            
            // Method has parameters in URL e.g. /hosting/domain/map/{domain}/{username}
            if (queryParameters.Count == 0 && !String.IsNullOrWhiteSpace(values.First().Value.ToString())) {

                // Get route path paramaters.
                string routePathParams = String.Empty;
                int count = 0;
                foreach (string obj in values.Keys) {

                    if (count == values.Count-1)
                        break;

                    if (count > 0)
                        routePathParams += "/";
                    routePathParams += "{" + obj + "}";
                    count++;
                }

                // Remove route path parameters from URL.
                Uri uri = request.RequestUri;
                for (int i = 0; i < uri.Segments.Length - (values.Count - 1); i++) {
                    routePath += uri.Segments[i];
                }

                routePath += routePathParams;

            }
            // Method has query string parameters.
            else {

                string queryStringParams = String.Empty;
                int count = 0;
                foreach (string obj in queryParameters.Keys) {
                    if (count > 0)
                        queryStringParams += "&";
                    queryStringParams += obj;
                    count++;
                }

                routePath = request.RequestUri.AbsolutePath;

                if (queryParameters.Keys.Count > 0)
                    routePath += "?";

                routePath += queryStringParams;
            }

            return routePath;
        }
        
        /// <summary>
        /// Removes empty parameters added to URL to satisfy Web API’s [frombody] encoding requirement of 
        /// adding "=" to PUT and POST requests.
        /// </summary>
        /// <param name="requestUri">Request Uri.</param>
        /// <returns>Request Uri with empty parameters removed.</returns>
        public static Uri RemoveEmptyParam(Uri requestUri) {

            string requestUrl = requestUri.ToString();
            string ignoreParam = requestUrl.Substring(requestUrl.Length - 2, 2);
            if (ignoreParam.Equals("?=") || ignoreParam.Equals("&="))
                requestUrl = requestUrl.Replace(ignoreParam, String.Empty);
            return new Uri(requestUrl);
        }
    }
}
