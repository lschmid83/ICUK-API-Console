using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace API.Core {

    /// <summary>
    /// Constants for the types of broadband order statuses
    /// </summary>
    public enum OrderStatus {

        /// <summary>
        /// None.
        /// </summary>
        [Description("Unknown")]
        NONE,

        /// <summary>
        /// Received.
        /// </summary>
        [Description("Received")]
        RECEIVED,

        /// <summary>
        /// Sent.
        /// </summary>
        [Description("Sent")]
        SENT,

        /// <summary>
        /// Processing. 
        /// </summary>
        [Description("Processing")]
        PROCESSING,

        /// <summary>
        /// Committed.
        /// </summary>
        [Description("Committed")]
        COMMITTED,

        /// <summary>
        /// Delayed.
        /// </summary>
        [Description("Delayed")]
        DELAYED,

        /// <summary>
        /// Complete.
        /// </summary>
        [Description("Complete")]
        COMPLETE,

        /// <summary>
        /// Rejected.
        /// </summary>
        [Description("Rejected")]
        REJECTED, 

        /// <summary>
        /// Cancelled.
        /// </summary>
        [Description("Cancelled")]
        CANCELLED,

        /// <summary>
        /// Ceased.
        /// </summary>
        [Description("Ceased")]
        CEASED,

        /// <summary>
        /// Migrated away.
        /// </summary>
        [Description("Migrated away")]
        MIGRATED_AWAY

    }

}
