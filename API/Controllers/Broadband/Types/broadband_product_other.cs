using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_product_other</name>
    /// <description>Represents broadband other products details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_product_other {
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
