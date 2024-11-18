using System.ComponentModel;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_ip</name>
    /// <description>Represents broadband IP allocation types.</description>
    /// <group>Enum</group>
    public enum broadband_ip {

        /// <summary>
        /// Dynamic.
        /// </summary>
        [Description("Dynamic")] 
        DYNAMIC = 0,
        
        /// <summary>
        /// Static.
        /// </summary>
        [Description("Static")] 
        STATIC = 1,

        /// <summary>
        /// Static + Routed.
        /// </summary>
        [Description("Static + Routed")]
        STATIC_ROUTED = 2,
    }
}