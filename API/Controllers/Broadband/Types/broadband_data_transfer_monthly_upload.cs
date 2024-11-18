using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    
    /// <name>broadband_data_transfer_monthly_upload</name>
    /// <description>Represents monthly broadband data transfer upload usage for a user.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_monthly_upload {

        /// <property>
        ///     <type>Long</type>
        ///     <description>Usage.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public long usage { get; set; }

        /// <property>
        ///     <type>Long</type>
        ///     <description>Projected.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public long projected { get; set; }

    }
}