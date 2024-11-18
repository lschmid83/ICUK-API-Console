using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_monthly_details</name>
    /// <description>Represents monthly broadband data transfer usage details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_monthly_details {

        /// <property>
        ///     <type>broadband_data_transfer_monthly_download</type>
        ///     <description>Download usage.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_monthly_download download { get; set; }

        /// <property>
        ///     <type>broadband_data_transfer_monthly_upload</type>
        ///     <description>Upload usage.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_monthly_upload upload { get; set; }

        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Overuse charge (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal overuse_charge { get; set; }

    }

}