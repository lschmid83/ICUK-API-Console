using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_monthly_results</name>
    /// <description>Represents monthly summary of broadband data transfer usage results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_monthly_result {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Year.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int year { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Month.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int month { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_peak_hours</type>
        ///     <description>Peak hours.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_peak_hours peak_hours { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_monthly_details</type>
        ///     <description>Off peak data transfer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_monthly_details off_peak { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_monthly_details</type>
        ///     <description>Peak data transfer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_monthly_details peak { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_monthly_details</type>
        ///     <description>Total data transfer.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_data_transfer_monthly_details total { get; set; }

    }
}