using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_ip</name>
    /// <description>Represents a broadband order RIPE contact details.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_order_ripe {

        /// <property>
        ///     <type>String</type>
        ///     <description>RIPE admin nic-handle.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string ripe_admin_nic_handle { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>RIPE tech nic-handle. (Admin nic-handle will be used if left blank)</description>
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