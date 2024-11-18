using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    
    /// <name>broadband_data_transfer_daily</name>
    /// <description>Represents daily broadband data transfer usage.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_data_transfer_daily {

        /// <property>
        ///     <type>broadband_data_transfer_daily_details</type>
        ///     <description>Off peak data transfer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_daily_details off_peak { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_daily_details</type>
        ///     <description>Peak data transfer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_daily_details peak { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Day.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int day { get; set; }
    }
}