using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_user_password</name>
    /// <description>Represents a broaband user password.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_user_password {

        /// <property>
        ///     <type>String</type>
        ///     <description>Password of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string password { get; set; }

    }
}
