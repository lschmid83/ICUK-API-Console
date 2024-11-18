using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_data_transfer_daily_result</name>
    /// <description>Represents daily broadband data transfer usage results for a month.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_daily_result {

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
        ///     <type>broadband_data_transfer_daily</type>
        ///     <description>Array of broadband_data_transfer_daily structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_data_transfer_daily> days { get; set; }

    }
}
