using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_user</name>
    /// <description>Represents a broadband user.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_user
    {
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Password of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string password { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Calling line identity.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string cli { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Broadband product the user subscribes to.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string product { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Forename of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string forename { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Surname of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string surname { get; set; }
        /// <property>
        ///     <type>broadband_order_address</type>
        ///     <description>Installation address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_address installation_address { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Online status.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool is_online { get; set; }
    }
}