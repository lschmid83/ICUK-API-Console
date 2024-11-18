using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_ip_deallocation</name>
    /// <description>Represents a broadband IP dealloaction.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ip_deallocation {

        /// <property>
        ///     <type>Integer</type>
        ///     <description>IP prefix.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int? prefix { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>IP address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ip { get; set; }
    }
}