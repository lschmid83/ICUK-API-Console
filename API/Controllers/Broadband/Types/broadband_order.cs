using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order</name>
    /// <description>Represents a broadband order.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order {

        /// <property>
        ///     <type>broadband_order_details</type>
        ///     <description>Broadband order details.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_details order { get; set; }

        /// <property>
        ///     <type>broadband_order_customer</type>
        ///     <description>Broadband customer details.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public broadband_order_customer customer { get; set; }
    }
}