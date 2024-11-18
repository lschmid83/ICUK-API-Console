using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_data_transfer_hourly_result</name>
    /// <description>Represents hourly broadband data transfer usage results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_hourly_result {

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
        ///     <type>Integer</type>
        ///     <description>Day.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public int day { get; set; }
        /// <property>
        ///     <type>broadband_data_transfer_hourly[]</type>
        ///     <description>Array of broadband_data_transfer_hourly structs.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public List<broadband_data_transfer_hourly> hours { get; set; }

    }
}