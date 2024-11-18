using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_product_user</name>
    /// <description>Represents a broadband product order user details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product_user {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the usr.</description>
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
        ///     <type>broadband_order_address</type>
        ///     <description>Installation address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_address user_address { get; set; }


    }
}