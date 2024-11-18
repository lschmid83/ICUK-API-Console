using API.Controllers.Broadband.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_summary</name>
    /// <description>Represents a summary of broadband orders.</description>
    /// <group>Type</group>
    [DataContract]     
    public struct broadband_order_summary {

        /// <property>
        ///     <type>Integer</type>
        ///     <description>Order ID.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int order_id { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Client reference.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string reference { get; set; }
        
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Product ID.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int product_id { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>Technology.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string technology { get; set; }
        
        /// <property>
        ///     <type>String</type>
        ///     <description>Calling line identity.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string cli { get; set; }

        /// <property>
        ///     <type>String</type>
        ///     <description>MAC Code.</description>
        ///     <optional>true</optional>
        /// </property>
        public string mac_code { get; set; }
        
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the user.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string username { get; set; }
        
        /// <property>
        ///     <type>broadband_order_type</type>
        ///     <description>Order type.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_type? order_type { get; set; }

        /// <property>
        ///     <type>broadband_order_subtype</type>
        ///     <description>Order subtype.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_subtype? order_subtype { get; set; }
  
        /// <property>
        ///     <type>String</type>
        ///     <description>Order status.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_order_status? order_status { get; set; }
        
        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Order date.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime order_date { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Required date.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime required_date { get; set; }

        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Last update.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime last_update { get; set; }

    }
}