using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    /// <name>broadband_address_results</name>
    /// <description>Represents address search results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_address_results {

        /// <property>
        ///     <type>broadband_address[]</type>
        ///     <description>Array of broadband_address structs.</description>
        /// </property> 
        [DataMember(IsRequired = true)]
        public List<broadband_address> addresses { get; set; }
    }
}