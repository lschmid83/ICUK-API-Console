using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_ripe_person</name>
    /// <description>Represents RIPE person contact details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_ripe_person
    {
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the contact.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Unique identifier that references RIPE Database objects containing contact details for a specific person or role.</description>
        ///     <readonly>true</readonly>
        /// </property>
        public string nic_handle { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Identifier of the maintainer that is authorised to perform updates on an object.</description>
        ///     <readonly>true</readonly>
        /// </property>
        public string mnt_by { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>First line of address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string address_line_1 { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Second line of address.</description>
        ///     <optional>true</optional>
        /// </property>
        public string address_line_2 { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of town.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string town { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of county.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string county { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Postcode of the address.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string postcode { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Phone number of contact.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string phone_number { get; set; }

    }
}
