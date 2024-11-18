using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_session_history</name>
    /// <description>Represents the session history of the broadband user.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_session_history {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }
        
        /// <property>
        ///     <type>String</type>
        ///     <description>Framed IP.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string framed_ip { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Time the session started.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime start_time { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Time the session ended.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime? stop_time { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Duration of the session.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string time_online { get; set; }

        /// <property>
        ///     <type>Long</type>
        ///     <description>Amount of data that the user sent during the session.</description>
        /// </property>
        public long data_in { get; set; }

        /// <property>
        ///     <type>Long</type>
        ///     <description>Amount of data that the user received during the session.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long data_out { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Cause of the session termination.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string termination_cause { get; set; }
    
    }
}
