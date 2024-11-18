using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_online_status</name>
    /// <description>Represents the online status of broadband user.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_online_status {

        /// <property>
        ///     <type>String</type>
        ///     <description>Username.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Date and time of last login.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime login_time { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Time online.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string time_online { get; set; }

        /// <property>
        ///     <type>Bool</type>
        ///     <description>Is online.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool is_online { get; set; }

    }
}
