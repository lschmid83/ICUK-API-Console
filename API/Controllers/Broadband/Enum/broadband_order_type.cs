using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_order_type</name>
    /// <description>Represents the different types of broadband order.</description>
    /// <group>Enum</group>
    public enum broadband_order_type {

        /// <summary>
        /// Provide.
        /// </summary>
        [Description("Provide")] // 1
        PROVIDE = 1,

        /// <summary>
        /// Migrate.
        /// </summary>
        [Description("Migrate")] // 2
        MIGRATE = 2,

        /// <summary>
        /// Modify.
        /// </summary>
        [Description("Modify")] // 3
        MODIFY = 3,

        /// <summary>
        /// Cease.
        /// </summary>
        [Description("Cease")] // 4
        CEASE = 4,

        /// <summary>
        /// All.
        /// </summary>
        [Description("All")]
        ALL = 100      // 100

    }
}