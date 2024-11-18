using API.Controllers.Broadband.Types;
using API.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Xml.Serialization;
using API.Core.Broadband;

namespace API.Controllers.Broadband {
    /// <description>Methods for retrieving the session history of broadband users.</description>
    public class BroadbandSessionController : IcukApiController {

        #region API Methods

        /// <name>Gets broadband session history</name>
        /// <description>Retrieves the past 50 session history of a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/session_history/{user@realm}</url>
        /// <group>Broadband Session</group>
        ///  <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_session_history[]</type>
        ///     <field>session_history</field>
        ///     <description>Array of broadband_session_history structs.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "session_history": [
        ///         {
        ///             "username": %username%,
        ///             "framed_ip": %ipv4%,
        ///             "start_time": %start_time%,
        ///             "stop_time": %end_time%,
        ///             "time_online": %time_span%,
        ///             "data_in": 0,
        ///             "data_out": 0,
        ///             "termination_cause": ""
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        public broadband_session_history_results Get(string username) {
            return GetSessionHistory(username);
        }
        #endregion

        /// <summary>
        /// Returns the past 50 session history of a specific broadband user
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>Array of session history</returns>
        private broadband_session_history_results GetSessionHistory(string fullUsername) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);
            broadband_session_history_results results = GetResults<broadband_session_history_results>("Broadband/broadband_session_history.json");
            return results;
        }

    }
}
