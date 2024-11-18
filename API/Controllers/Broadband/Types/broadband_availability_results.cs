using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_availability_results</name>
    /// <description>Represents broadband availability results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_availability_results {
        /// <property>
        ///     <type>broadband_exchange_info</type>
        ///     <description>Broadband exchange information.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_exchange_info exchange { get; set; }
        /// <property>
        ///     <type>broadband_availability[]</type>
        ///     <description>Array of broadband_availability structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_availability> products { get; set; }
    }
}
