using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_online_status_results</name>
    /// <description>Represents broaband online status results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_online_status_results {

        /// <property>
        ///     <type>broadband_online_status[]</type>
        ///     <description>Array of broadband_online_status structs.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public List<broadband_online_status> online_statuses { get; set; }
    }

}