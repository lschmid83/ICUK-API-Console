using API.Controllers.Broadband.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_ip</name>
    /// <description>Represents a broadband order IP allocation details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_ip {

        /// <property>
        ///     <type>broadband_ip</type>
        ///     <description>Type of allocation.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_ip allocation { get; set; }
        
        /// <property>
        ///     <type>Integer</type>
        ///     <description>IP prefix.</description>
        ///     <optional>true</optional>  
        /// </property>
        public int? prefix { get; set; }

        /// <property>
        ///     <type>Bool</type>
        ///     <description>Allocate IPv6 address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool ipv6 { get; set; }
    }
}