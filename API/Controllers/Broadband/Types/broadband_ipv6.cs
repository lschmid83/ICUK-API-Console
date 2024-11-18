using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_ipv6</name>
    /// <description>Represents a broadband IPv6 address.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ipv6 {

        /// <property>
        ///     <type>String</type>
        ///     <description>IP address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ip { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Network address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string network { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Netmask.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string netmask { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Number of IP addresses in subnet.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public BigInteger range { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Broadcast address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string broadcast { get; set; }

    }
}