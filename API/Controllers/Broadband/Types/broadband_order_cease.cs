using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types {

    /// <name>broadband_order_cease</name>
    /// <description>Represents a cease broadband order request.</description>
    /// <group>Type</group>
    [DataContract]    
    public struct broadband_order_cease {
        
        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Cease request date.</description>
        ///     <day>5</day>
        /// </property>
        [DataMember(IsRequired = true)]
        public DateTime request_date { get; set; }

    }
}