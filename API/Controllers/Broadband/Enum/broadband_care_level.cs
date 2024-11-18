using System.ComponentModel;

namespace API.Controllers.Broadband.Enum
{
    /// <name>broadband_care_level</name>
    /// <description>Represents broadband ADSL product care level.</description>
    /// <group>Enum</group>
    public enum broadband_care_level {

        /// <summary>
        /// Standard.
        /// </summary>
        [Description("Standard")] 
        STANDARD = 1,
        
        /// <summary>
        /// Enhanced.
        /// </summary>
        [Description("Enhanced")] 
        ENHANCED = 2,
    }
}
