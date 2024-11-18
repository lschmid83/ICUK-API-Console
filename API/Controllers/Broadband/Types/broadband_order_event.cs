using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_event</name>
    /// <description>Represents broadband order events.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_order_event {

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Event date.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime date { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of event.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string name { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Description of event.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string description { get; set; }

    }
}