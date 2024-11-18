using API.Controllers.Broadband.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_details</name>
    /// <description>Represents broadband order details.</description>
    /// <group>Type</group>
    [DataContract] 
    public struct broadband_order_details {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Password of the user.</description>
        ///     <optional>true</optional>
        /// </property>
        public string password { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Simultaneous provide.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool simultaneous_provide { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>BT order reference.</description>
        ///     <optional>true</optional>
        /// </property>
        public string bt_order_reference { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>ID of the product.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int product_id { get; set; }
        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Activation date.</description>
        ///     <day>5</day>  
        ///     <optional>true</optional>
        /// </property>
        public DateTime activation_date { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>MAC Code.</description>
        ///     <optional>true</optional>
        /// </property>
        public string mac_code { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Losing ISP.</description>
        ///     <optional>true</optional>  
        /// </property>
        public string losing_isp { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Fast track order.</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public bool fast_track { get; set; }
        /// <property>
        ///     <type>broadband_care_level</type>
        ///     <description>Care level.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_care_level care_level { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Send completion email.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool send_completion_email { get; set; }
        /// <property>
        ///     <type>broadband_order_ip</type>
        ///     <description>IP allocation details.</description>
        ///    <optional>true</optional>
        /// </property>
        public broadband_order_ip ip { get; set; }
        /// <property>
        ///     <type>broadband_order_ripe</type>
        ///     <description>RIPE contact details.</description>
        ///    <optional>true</optional>
        /// </property>
        public broadband_order_ripe ripe { get; set; }
        /// <property>
        ///     <type>broadband_order_installation_options</type>
        ///     <description>Installation options.</description>
        ///     <optional>true</optional>
        /// </property>
        public broadband_order_installation_options installation_options { get; set; }

    }
}