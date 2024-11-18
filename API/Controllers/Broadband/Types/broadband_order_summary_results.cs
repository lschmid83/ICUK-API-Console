using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_order_summary_results</name>
    /// <description>Represents broadband order summary results.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_summary_results
    {
        /// <property>
        ///     <type>broadband_order_summary[]</type>
        ///     <description>Array of broadband_order_summary structs.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public List<broadband_order_summary> broadband_orders { get; set; }
    }
}
