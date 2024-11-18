using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_peak_hours</name>
    /// <description>Represents broadband data transfer peak hours.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_peak_hours {

        /// <property>
        ///     <type>String</type>
        ///     <description>Start time.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string start { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>End time.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string end { get; set; }
    }
}