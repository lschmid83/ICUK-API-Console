using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SDK {

    /// <summary>
    /// API response.
    /// </summary>
    public class IcukApiResponse {

        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Error type.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// Status code.
        /// </summary>
        public int StatusCode { get; set; }
        
        /// <summary>
        /// Response JSON.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Location header.
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Indicates if the request was succesful.
        /// </summary>
        public bool Success { get; set; }

    }

}
