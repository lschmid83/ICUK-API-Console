using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {
    /// <name>broadband_product_assured_rate</name>
    /// <description>Represents broadband assured rate product details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product_assured_rate {
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
    }
}