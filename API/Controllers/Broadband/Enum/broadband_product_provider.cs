using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_product_provider</name>
    /// <description>Represents broadband ADSL product provider.</description>
    /// <group>Enum</group>
    public enum broadband_product_provider {

        /// <summary>
        /// WBC 21CN.
        /// </summary>
        [Description("WBC 21CN")]
		WBC_21CN = 1,

        /// <summary>
        /// WBC 20CN.
        /// </summary>
		[Description("WBC 20CN")] 
		WBC_20CN = 3,

        /// <summary>
        /// Cable &amp; Wireless.
        /// </summary>
        [Description("Cable & Wireless")] 
        CABLE_AND_WIRELESS = 4,
    }
}