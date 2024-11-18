using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_user_contact</name>
    /// <description>Represents a broaband user account contact details.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_user_contact {

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
        ///     <type>String</type>
        ///     <description>Phone of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string phone { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Email address of the user.</description>
        ///     <optional>true</optional>
        /// </property>
        public string email { get; set; }

    }
}
