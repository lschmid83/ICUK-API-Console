using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_session_history_results</name>
    /// <description>Represents broadband session history results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_session_history_results {

        /// <property>
        ///     <type>broadband_session_history[]</type>
        ///     <description>Array of broadband_session_history structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_session_history> session_history { get; set; }

    }
}