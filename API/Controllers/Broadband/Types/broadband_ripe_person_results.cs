using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_ripe_person_results</name>
    /// <description>Represents RIPE person results assigned to a reseller account.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ripe_person_results {
        
        /// <property>
        ///     <type>broadband_ripe_person[]</type>
        ///     <description>Array of broadband_ripe_person structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_ripe_person> ripe_persons { get; set; }

    }
}