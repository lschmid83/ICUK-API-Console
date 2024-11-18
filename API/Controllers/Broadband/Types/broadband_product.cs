
using API.Controllers.Broadband.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_product</name>
    /// <description>Represents ADSL broadband product details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product {

        /// <property>
        ///     <type>Integer</type>
        ///     <description>ID of the product.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int id { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the product.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string name { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Category.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string category { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Price (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal price { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Activation fee (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal activation_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>ADSL Migration fee (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal adsl_migration_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>ADSL LLU Migration fee (£).</description>
        /// </property>
        public decimal adsl_llu_migration_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>FTTC Migration fee (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal fttc_migration_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>FTTC LLU Migration fee (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal fttc_llu_migration_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>FTTC Reverse Migration fee (£).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal fttc_reverse_migration_fee { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Fast-track price (£).</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public decimal fast_track_price { get; set; }
        /// <property>
        ///     <type>broadband_product_provider</type>
        ///     <description>Provider.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_product_provider provider { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Technology.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string technology { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Down speed (kbps).</description>
        /// </property>
        public int down_speed { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Up speed (kbps).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int up_speed { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Peak cap (GB).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int peak_cap { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Off peak cap (GB).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int off_peak_cap { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Contention.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int contention { get; set; }
        /// <property>
        ///     <type>broadband_product_class</type>
        ///     <description>Product class.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_product_class product_class { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Provide lead time (days).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int provide_lead_time { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Migration lead time (days).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int migration_lead_time { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Peak start (hh:mm:ss).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string peak_start { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Peak end (hh:mm:ss).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string peak_end { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Contract length (months).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int contract_length { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Cease lead time (days).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int cease_lead_time { get; set; }
        /// <property>
        ///     <type>DateTime</type>
        ///     <description>First acceptable cease date.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime cease_first_date { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Requires out line rental.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool requires_our_line_rental { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Unlimited cap.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool unlimited_cap { get; set; }

    }
}