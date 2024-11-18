using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_address</name>
    /// <description>Represents a broadband order customer installation address.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_address {
        /// <property>
        ///     <type>String</type>
        ///     <description>House name.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string house_name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Street name.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string street_name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Town.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public string town { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>County.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string county { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Postcode.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string postcode { get; set; }
  
    }
}