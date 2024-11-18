using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_data_transfer_daily_details</name>
    /// <description>Represents daily broadband data transfer usage details.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_data_transfer_daily_details {

        /// <property>
        ///     <type>Long</type>
        ///     <description>Download.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long download { get; set; }
        /// <property>
        ///     <type>Long</type>
        ///     <description>Upload.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public long upload { get; set; }
    }
}
