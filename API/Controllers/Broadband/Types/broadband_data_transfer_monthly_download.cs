using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_monthly_download</name>
    /// <description>Represents monthly broadband data transfer download usage for a user.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_data_transfer_monthly_download {

        /// <property>
        ///     <type>Long</type>
        ///     <description>Quota.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long quota { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Usage.</description>
        /// </property>    
        [DataMember(IsRequired = true)]
        public long usage { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Overuse.</description>
        /// </property>    
        [DataMember(IsRequired = true)]
        public long overuse { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Projected.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public long projected { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Projected overuse.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public long projected_overuse { get; set; }

    }
}