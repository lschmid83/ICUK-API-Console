using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_address</name>
    /// <description>Represents an address.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_address {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the subpremises.</description>
        ///     <optional>true</optional>
        /// </property>
        public string sub_premises { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the premises.</description>
        ///     <optional>true</optional>
        /// </property>
        public string premises_name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Number of the thouroughfare.</description>
        ///     <optional>true</optional>
        /// </property>
        public string thoroughfare_number { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the thoroughfare.</description>
        ///     <optional>true</optional>    
        /// </property>
        public string thoroughfare_name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Locality of the address.</description>
        ///     <optional>true</optional>
        /// </property>
        public string locality { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the post town.</description>
        ///     <optional>true</optional>   
        /// </property>
        public string post_town { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Postcode of the address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string postcode { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>ID of the district.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string district_id { get; set; }
    }
}