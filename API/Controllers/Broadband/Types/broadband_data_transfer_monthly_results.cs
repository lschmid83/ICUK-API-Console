using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_monthly_results</name>
    /// <description>Represents monthly broadband data transfer usage results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_monthly_results {

        /// <property>
        ///     <type>broadband_data_transfer_monthly_result[]</type>
        ///     <description>Array of broadband_data_transfer_monthly_result structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_data_transfer_monthly_result> data_transfers { get; set; }
    }
}