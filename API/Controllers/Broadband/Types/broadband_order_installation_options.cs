using API.Controllers.Broadband.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers.Broadband.Types
{
    /// <name>broadband_order_installation_options</name>
    /// <description>Represents broadband order installation options for FTTC and FTTP connections.</description>
    /// <group>Type</group>
    [DataContract]
    public struct broadband_order_installation_options
    {
        /// <property>
        ///     <type>broadband_appointment_type</type>
        ///     <description>Appointment time either morning or evening.</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public broadband_appointment_type engineer_appointment { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Site visit note (Maximum 75 characters).</description>
        /// </property>
        [DataMember(IsRequired = true)] 
        public string site_visit_note { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Special arrangement note (Maximum 40 characters).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string special_arrangement_note { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Hazard note (Maximum 40 characters).</description>
        /// </property>
        [DataMember(IsRequired = true)]
        public string hazard_note { get; set; }
        /// <property>
        ///     <type>String</type>
        ///     <description>Appointment password (Maximum 20 characters).</description>
        /// </property> 
        [DataMember(IsRequired = true)]
        public string password { get; set; }
    }
}
