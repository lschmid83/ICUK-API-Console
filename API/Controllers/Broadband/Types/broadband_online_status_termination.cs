using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_online_status_termination</name>
    /// <description>Represents the session termination response.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_online_status_termination {

        /// <property>
        ///     <type>String</type>
        ///     <description>Response Message.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string message { get; set; }

        /// <property>
        ///     <type>Bool</type>
        ///     <description>Determines whether the session termination was successful or not.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool is_success_response { get; set; }

    }

}
