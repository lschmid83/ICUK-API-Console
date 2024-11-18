using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_authentication_logs_results</name>
    /// <description>Represents broadband authentication log results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_authentication_log_results {

        /// <property>
        ///     <type>broadband_authentication_log[]</type>
        ///     <description>Array of broadband_authentication_log structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_authentication_log> authentication_logs { get; set; }

    }
}