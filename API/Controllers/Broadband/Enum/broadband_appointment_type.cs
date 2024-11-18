using System.ComponentModel;

namespace API.Controllers.Broadband.Enum
{
    /// <name>broadband_appointment_type</name>
    /// <description>Represents broadband engineer apointment types.</description>
    /// <group>Enum</group>
    public enum broadband_appointment_type {

        /// <summary>
        /// None.
        /// </summary>
        [Description("None")]
        NONE = 0,

        /// <summary>
        /// Morning.
        /// </summary>
        [Description("Morning")]
        AM = 1,

        /// <summary>
        /// Afternoon.
        /// </summary>
        [Description("Afternoon")]
        PM = 2
    }
}
