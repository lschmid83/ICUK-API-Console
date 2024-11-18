using API.Controllers.Broadband.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Core {

    /// <summary>
    /// API constants.
    /// </summary>
    public class ApiConstants {

        /// <summary>
        /// Username.
        /// </summary>
        public const string USERNAME = "user@realm.co.uk";

        /// <summary>
        /// Start time.
        /// </summary>
        public static DateTime START_TIME = new DateTime(2014, 1, 1, 8, 0, 0);

        /// <summary>
        /// End time.
        /// </summary>
        public static DateTime END_TIME = new DateTime(2014, 1, 1, 19, 59, 59);
        
        /// <summary>
        /// IP prefix.
        /// </summary>
        public const string IP_PREFIX = "32";

        /// <summary>
        /// IPv4
        /// </summary>
        public const string IPV4 = "48.34.135.1";

        /// <summary>
        /// IP allocation type.
        /// </summary>
        public const string IP_ALLOCATION_TYPE = "static";

        /// <summary>
        /// IPv6.
        /// </summary>
        public const string IPV6 = "2005:0db9:85a3:0046:1000:8a4e:0370:7334";

      
    }
}