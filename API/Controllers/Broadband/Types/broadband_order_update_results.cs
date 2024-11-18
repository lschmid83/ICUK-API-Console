using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    
    /// <name>broadband_order_update_results</name>
    /// <description>Represents broaband orders which have been updated within a date range.</description>
    /// <group>Type</group>
    [DataContract]   
    public struct broadband_order_update_results {

        /// <property>
        ///     <type>broadband_order_information[]</type>
        ///     <description>Array of broadband_order_information structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_order_information> order_updates { get; set; }

    }
}