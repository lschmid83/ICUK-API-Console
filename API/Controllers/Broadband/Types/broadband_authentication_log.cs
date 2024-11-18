using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_authentication_logs</name>
    /// <description>Represents the authentication logs of the broadband user.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_authentication_log {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public String username { get; set; }

        /// <property>
        ///     <type>Bool</type>
        ///     <description>Represents whether the user was authenticated or not.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool reply { get; set; }
        
        /// <property>
        ///     <type>String</type>
        ///     <description>Additional details. E.g. Login was from another line.</description>
        ///     <optional>true</optional>
        /// </property>
        public string additional_details { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Date and time of the authentication attempt.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public DateTime time { get; set; }

    }
}
