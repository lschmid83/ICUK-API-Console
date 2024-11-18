using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_ip_results</name>
    /// <description>Represents IP address assignements for a broadband connection.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ip_results {

        /// <property>
        ///     <type>String</type>
        ///     <description>IP address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ip { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Type of allocation.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string allocation { get; set; }
        /// <property>
        ///     <type>broadband_ipv4[]</type>
        ///     <description>Array of broadband_ipv4 structs.</description>
        /// </property>   
        [DataMember(IsRequired = true)]
        public List<broadband_ipv4> routed { get; set; }
        /// <property>
        ///     <type>broadband_ipv6</type>
        ///     <description>broadband_ipv6 struct.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public broadband_ipv6? ipv6 { get; set; }
    }
}