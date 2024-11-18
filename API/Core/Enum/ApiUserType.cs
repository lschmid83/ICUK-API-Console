using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Core.Enum
{
    /// <summary>
    /// ApiUserTypes.
    /// </summary>
    [Flags]
    public enum ApiUserTypes {

        /// <summary>
        /// ICUK administrator.
        /// </summary>
        ICUK_ADMINISTRATOR = 1,

        /// <summary>
        /// ICUK reseller.
        /// </summary>
        ICUK_RESELLER = 2,

        /// <summary>
        /// ICUK customer.
        /// </summary>
        ICUK_CUSTOMER = 4,

    }

}
