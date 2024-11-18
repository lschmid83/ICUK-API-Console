using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_availability</name>
    /// <description>Represents broadband availability.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_availability
    {

        /// <property>
        ///     <type>String</type>
        ///     <description>Name of the product.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string name { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Likely down speed of the product.</description>
        ///     <optional>true</optional>
        /// </property>
        public decimal? likely_down_speed { get; set; }
        /// <property>
        ///     <type>Decimal</type>
        ///     <description>Likely up speed of the product.</description>
        ///     <optional>true</optional>
        /// </property>
        public decimal? likely_up_speed { get; set; }
        /// <property>
        ///     <type>Bool</type>
        ///     <description>Availability of the product.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public bool availability { get; set; }
        /// <property>
        ///     <type>DateTime</type>
        ///     <description>Availability date.</description>
        ///     <optional>true</optional>
        /// </property>
        [DataMember(IsRequired = false)]
        public DateTime? availability_date { get; set; }

    }
}