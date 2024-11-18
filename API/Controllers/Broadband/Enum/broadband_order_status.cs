using System.ComponentModel;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_order_status</name>
    /// <description>Represents the order status of a broadband order.</description>
    /// <group>Enum</group> 
    public enum broadband_order_status {

        /// <summary>
        /// Received.
        /// </summary>
        [Description("Received")]
        RECEIVED = 1,       // 1

        /// <summary>
        /// Processing.
        /// </summary>
        [Description("Processing")]
        PROCESSING = 2,     // 2

        /// <summary>
        /// Committed.
        /// </summary>
        [Description("Committed")]
        COMMITTED = 3,      // 3

        /// <summary>
        /// Delayed.
        /// </summary>
        [Description("Delayed")]
        DELAYED = 4,        // 4

        /// <summary>
        /// Complete.
        /// </summary>
        [Description("Complete")]
        COMPLETE = 5,       // 5

        /// <summary>
        /// Rejected.
        /// </summary>
        [Description("Rejected")]
        REJECTED = 6,       // 6

        /// <summary>
        /// Cancelled.
        /// </summary>
        [Description("Cancelled")]
        CANCELLED = 7,      // 7
        
        /// <summary>
        /// All.
        /// </summary>
        [Description("All")]
        ALL = 100      // 100

    }
}