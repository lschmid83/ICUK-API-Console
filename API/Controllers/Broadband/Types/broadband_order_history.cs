using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_history</name>
    /// <description>Represents events which occured in the broadband order history.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_order_history {

        /// <property>
        ///     <type>broadband_order_event[]</type>
        ///     <description>Array of broadband_order_event structs.</description>
        /// </property>
        public List<broadband_order_event> order_events { get; set; }
    }
}