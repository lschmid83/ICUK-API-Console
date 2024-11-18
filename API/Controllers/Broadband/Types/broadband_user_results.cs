using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_users_results</name>
    /// <description>Represents broaband user results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_user_results {

        /// <property>
        ///     <type>broadband_user[]</type>
        ///     <description>Array of broadband_user structs.</description>
        /// </property> 
        [DataMember(IsRequired = true)]
        public List<broadband_user> broadband_users { get; set; }
    }
}