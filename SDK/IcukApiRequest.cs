using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SDK {

    /// <summary>
    /// Creates a request.
    /// </summary>
    public class IcukApiRequest {

        /// <summary>
        /// Method URL.
        /// </summary>
        private string url;

        /// <summary>
        /// HTTP request method.
        /// </summary>
        private string method = "GET";

        /// <summary>
        /// Request body.
        /// </summary>
        private string body;

        /// <summary>
        /// Adds a dynamic object to the request body.
        /// </summary>
        /// <param name="value">Dynamic object.</param>
        public void AddBodyObject(dynamic obj) {
            body = JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Sets a URL parameter.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value of parameter.</param>
        public void AddUrlParameter(string name, string value) {

            Uri uri = new Uri(url);
            string query = uri.Query;
            if (query.StartsWith("?")) {
                query += "&" + name + "=" + value;
            }
            else {
                query += "?" + name + "=" + value;
            }
            url = uri.GetLeftPart(UriPartial.Path) + query;
        }

        /// <summary>
        /// Method URL.
        /// </summary>
        public string Url {

            get {
                return url;
            }
            set {
                Uri uri = new Uri(value);
                url = uri.ToString();
            }
        }

        /// <summary>
        /// Message body.
        /// </summary>
        public string Body {

            get {
                return body;
            }
            set {
                if (value != null) {
                    try {
                        JObject.Parse(value);
                        body = value;
                    }
                    catch (Exception e) {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Http Method.
        /// </summary>
        public string Method {

            get {
                return method;
            }
            set {
                method = value;
            }
        }
    }
}
