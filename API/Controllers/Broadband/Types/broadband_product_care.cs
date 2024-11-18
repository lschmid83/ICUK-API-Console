using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    /// <name>broadband_product_care</name>
    /// <description>Represents broadband care product details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product_care {
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
        ///     <description>Price.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public decimal price { get; set; }
        /// <property>
        ///     <type>Integer</type>
        ///     <description>Care level.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public int care_level { get; set; }

    }
}