using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_customer</name>
    /// <description>Represents a broadband order customer details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_customer {

        /// <property>
        ///     <type>String</type>
        ///     <description>Forename of the customer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string forename { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Surname of the customer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string surname { get; set; }
        /// <property>
        ///     <type>broadband_order_address</type>
        ///     <description>Customer address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_address address { get; set; }
        /// <property>
        ///     <type>broadband_order_contact</type>
        ///     <description>Customer contact details.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_contact contact { get; set; }


    }
}