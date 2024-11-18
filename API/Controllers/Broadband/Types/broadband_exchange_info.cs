using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_exchange_info</name>
    /// <description>Represents broadband exchange information.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_exchange_info {
        
        /// <property>
        ///     <type>String</type>
        ///     <description>Status of the exchange.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string status { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Exchange message.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string message { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Exchange code.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string exchange_code { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the exchange.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string exchange_name { get; set; }
        
    }
}