using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_information</name>
    /// <description>Represents detailed broadband order information.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_order_information {

        /// <property>
        ///     <type>broadband_order_summary</type>
        ///     <description>Order summary.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_summary order_summary { get; set; }

        /// <property>
        ///     <type>broadband_user</type>
        ///     <description>Broadband customer details.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_user broadband_user { get; set; }

        /// <property>
        ///     <type>broadband_order_history</type>
        ///     <description>Order history.</description>
        ///     <optional>true</optional>
        /// </property>
        public broadband_order_history? order_history { get; set; }
    }
}