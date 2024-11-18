using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_hourly</name>
    /// <description>Represents hourly broadband data transfer usage.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_hourly {

        /// <property>
        ///     <type>Long</type>
        ///     <description>Download.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long download { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Upload.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long upload { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Hour number.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int hour { get; set; }

    }
}