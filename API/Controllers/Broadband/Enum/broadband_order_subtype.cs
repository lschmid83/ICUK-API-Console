using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace API.Controllers.Broadband.Enum {

    /// <name>broadband_order_subtype</name>
    /// <description>Represents the different subtypes of broadband order.</description>
    /// <group>Enum</group>
    public enum broadband_order_subtype {
        
        /// <summary>
        /// Provide directory number.
        /// </summary>
        [Description("Provide directory number")] // 1
        PROVIDE_DIRECTORY_NUMBER = 1,

        /// <summary>
        /// Provide address.
        /// </summary>
        [Description("Provide address")] // 2
        PROVIDE_ADDRESS = 2,

        /// <summary>
        /// Migrate directory number.
        /// </summary>
        [Description("Migrate directory number")] // 3
        MIGRATE_DIRECTORY_NUMBER = 3,

        /// <summary>
        /// Migrate address.
        /// </summary>
        [Description("Migrate address")] // 4
        MIGRATE_ADDRESS = 4,

        /// <summary>
        /// Migrate family.
        /// </summary>
        [Description("Migrate family")] // 5
        MIGRATE_FAMILY = 5,
        
        /// <summary>
        /// Copper to fibre.
        /// </summary>
        [Description("Copper to fibre")] // 6
        COPPER_TO_FIBRE = 6,

        /// <summary>
        /// Fibre to copper.
        /// </summary>
        [Description("Fibre to copper")] // 7
        FIBRE_TO_COPPER = 7,

        /// <summary>
        /// Sim provide.
        /// </summary>
        [Description("Sim provide")] // 8
        SIM_PROVIDE = 8,

        /// <summary>
        /// Home move.
        /// </summary>
        [Description("Home move")] // 9
        HOME_MOVE = 9,

        /// <summary>
        /// Modify traffic weighting.
        /// </summary>
        [Description("Modify traffic weighting")] // 10
        MODIFY_TRAFFIC_WEIGHTING = 10,

        /// <summary>
        /// Modify advanced services.
        /// </summary>
        [Description("Modify advanced services")] // 11
        MODIFY_ADVANCED_SERVICES = 11,

        /// <summary>
        /// Modify speed.
        /// </summary>
        [Description("Modify speed")] // 12
        MODIFY_SPEED = 12,

        /// <summary>
        /// Modify care.
        /// </summary>
        [Description("Modify care")] // 13
        MODIFY_CARE = 13,

        /// <summary>
        /// Modify stability.
        /// </summary>
        [Description("Modify stability")] // 14
        MODIFY_STABILITY = 14,

        /// <summary>
        /// Modify modified fault threshold.
        /// </summary>
        [Description("Modify modified fault threshold")] // 15
        MODIFY_MODIFIED_FAULT_THRESHOLD = 15,

        /// <summary>
        /// Modify interleaving.
        /// </summary>
        [Description("Modify interleaving")] // 16
        MODIFY_INTERLEAVING = 16,

        /// <summary>
        /// Cease.
        /// </summary>
        [Description("Cease")] // 17
        CEASE = 17,

        /// <summary>
        /// Migrate away.
        /// </summary>
        [Description("Migrate away")] // 18
        MIGRATE_AWAY = 18,
        
        /// <summary>
        /// Unknown.
        /// </summary>
        [Description("Unknown")] // 19
        OTHER = 19



    }
}