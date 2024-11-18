using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_ip_allocation</name>
    /// <description>Represents a broadband IP allocation.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ip_allocation {

        /// <property>
        ///     <type>Integer</type>
        ///     <description>IP prefix.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int? prefix { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>RIPE admin nic-handle.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ripe_admin_nic_handle { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>RIPE tech nic-handle. (Admin NIC handle will be used if left blank)</description>
        ///     <optional>true</optional>
        /// </property>
        public string ripe_tech_nic_handle { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>RIPE justification.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ripe_justification { get; set; }
    }
}