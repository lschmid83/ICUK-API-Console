using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_product_class</name>
    /// <description>Represents broadband ADSL product class.</description>
    /// <group>Enum</group>
    public enum broadband_product_class {

        /// <summary>
        /// Home.
        /// </summary>
        [Description("Home")] 
		HOME = 1,

        /// <summary>
        /// Business.
        /// </summary>
		[Description("Business")]
		BUSINESS = 2,

        /// <summary>
        /// Enterprise.
        /// </summary>
		[Description("Enterprise")]
		ENTERPRISE = 3
    }
}