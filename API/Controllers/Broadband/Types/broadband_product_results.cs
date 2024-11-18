using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_product_results</name>
    /// <description>Represents broadband product results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product_results {

        /// <property>
        ///     <type>broadband_product_ip[]</type>
        ///     <description>Array of broadband_product_ip structs.</description>
        /// </property>   
        [DataMember(IsRequired = true)] 
        public List<broadband_product_ip> ip { get; set; }

        /// <property>
        ///     <type>broadband_product_routed[]</type>
        ///     <description>Array of broadband_product_routed structs.</description>
        /// </property>   
        [DataMember(IsRequired = true)]
        public List<broadband_product_routed> routed { get; set; }

        /// <property>
        ///     <type>broadband_product_elevated_best_effort[]</type>
        ///     <description>Array of broadband_product_elevated_best_effort structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_product_elevated_best_effort> elevated_best_effort { get; set; }

        /// <property>
        ///     <type>broadband_product_care[]</type>
        ///     <description>Array of broadband_product_care structs.</description>
        /// </property>  
        [DataMember(IsRequired = true)]
        public List<broadband_product_care> care { get; set; }

        /// <property>
        ///     <type>broadband_product_assured_rate[]</type>
        ///     <description>Array of broadband_product_assured_rate structs.</description>
        /// </property>   
        [DataMember(IsRequired = true)]
        public List<broadband_product_assured_rate> assured_rate { get; set; }

        /// <property>
        ///     <type>broadband_product[]</type>
        ///     <description>Array of broadband_product structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_product> broadband_product { get; set; }

        /// <property>
        ///     <type>broadband_product_other[]</type>
        ///     <description>Array of broadband_product_other structs.</description>
        /// </property> 
        [DataMember(IsRequired = true)]
        public List<broadband_product_other> other_products { get; set; }

    }
}