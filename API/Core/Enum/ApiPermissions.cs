using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Core.Enum {
    /// <summary>
    /// API permissions.
    /// </summary>
    [Flags]
    public enum ApiPermissions {

        /// <summary>
        /// All.
        /// </summary>
        ALL_NONE = 0,

        /// <summary>
        /// Broadband none.
        /// </summary>
        BROADBAND_NONE = 1,

        /// <summary>
        /// Broadband read.
        /// </summary>
        BROADBAND_READ = 2,

        /// <summary>
        /// Broadband read / write.
        /// </summary>
        BROADBAND_READ_WRITE = 4,

        /// <summary>
        /// Hosting none.
        /// </summary>
        HOSTING_NONE = 8,

        /// <summary>
        /// Hosting read.
        /// </summary>
        HOSTING_READ = 16,

        /// <summary>
        /// Hosting read / write.
        /// </summary>
        HOSTING_READ_WRITE = 32,

        /// <summary>
        /// Telecoms none.
        /// </summary>
        TELECOMS_NONE = 64,

        /// <summary>
        /// Telecoms read.
        /// </summary>
        TELECOMS_READ = 128,

        /// <summary>
        /// Telecoms read / write.
        /// </summary>
        TELECOMS_READ_WRITE = 256,

        /// <summary>
        /// SMS none.
        /// </summary>
        SMS_NONE = 512,

        /// <summary>
        /// SMS read.
        /// </summary>
        SMS_READ = 1024,

        /// <summary>
        /// SMS read / write.
        /// </summary>
        SMS_READ_WRITE = 2048,

        /// <summary>
        /// Servers none.
        /// </summary>
        SERVERS_NONE = 4096,

        /// <summary>
        /// Servers read.
        /// </summary>
        SERVERS_READ = 8192,

        /// <summary>
        /// Servers read / write.
        /// </summary>
        SERVER_READ_WRITE = 16384,

        /// <summary>
        /// Domain none.
        /// </summary>
        DOMAIN_NONE = 32768,

        /// <summary>
        /// Domain read.
        /// </summary>
        DOMAIN_READ = 65536,

        /// <summary>
        /// Domain read / write.
        /// </summary>
        DOMAIN_READ_WRITE = 131072
    }
}