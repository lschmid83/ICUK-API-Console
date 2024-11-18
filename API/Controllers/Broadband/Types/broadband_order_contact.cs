using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_contact</name>
    /// <description>Represents a broadband order customer contact details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_contact {

        /// <property>
        ///     <type>String</type>
        ///     <description>Contact number (CLI).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string contact_number { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Mobile number.</description>
        ///     <optional>true</optional> 
        /// </property>
        public string contact_mobile { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Email address of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string email_address { get; set; }
    }
}