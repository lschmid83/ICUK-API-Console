using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace API.Controllers.Broadband
{
    /// <description>Methods for retrieving the online statuses of broadband users.</description>
    public class BroadbandStatusController : IcukApiController
    {
        #region API Methods

        /// <name>Gets broadband online statuses for all users</name>
        /// <description>Retrieves the online statuses for all broadband users.</description>
        /// <type>Get</type>
        /// <url>/broadband/online_status</url>
        /// <group>Broadband Status</group>
        /// <success>
        ///     <type>broadband_online_status_results</type>
        ///     <field>online_statuses</field>
        ///     <description>broadband_online_status_results struct.</description>
        /// </success>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example> 
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "online_statuses": [
        ///         {
        ///             "username": %username%,
        ///             "login_time": %start_time%,
        ///             "time_online": %time_span%,
        ///             "is_online": true
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        public broadband_online_status_results Get() {
            return GetBroadbandOnlineStatusForAllUsers();
        }

        /// <name>Get broadband online status</name> 
        /// <description>Retrieves the online status of a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/online_status/{user@realm}</url>
        /// <group>Broadband Status</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_online_status</type>
        ///     <field>onlinestatus</field>
        ///     <description>broadband_online_status struct.</description>
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
        ///     "username": %username%,
        ///     "login_time": %start_time%,
        ///     "time_online": %time_span%,
        ///     "is_online": true
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_online_status Get(string username) {
            return GetBroadbandOnlineStatusForUser(username);
        }

        /// <name>Deletes the session of an online broadband user</name>
        /// <description>Terminates a user's session if they are online.</description>
        /// <type>Delete</type>
        /// <url>/broadband/online_status/{user@realm}</url>
        /// <group>Broadband Status</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_online_status_termination</type>
        ///     <field>online_status</field>
        ///     <description>broadband_online_status_termination struct.</description>
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
        ///     "message": "",
        ///     "is_success_response": true   
        /// }
        ///     </content>
        /// </example>
        [HttpDelete]
        public broadband_online_status_termination Delete(string username) {
            return TerminateBroadbandUserSession(username);
        }

        #endregion

        /// <summary>
        /// Returns the online statuses of all broadband users.
        /// </summary>
        /// <returns>Online status of all users.</returns>
        private broadband_online_status_results GetBroadbandOnlineStatusForAllUsers() {
            
            broadband_online_status_results results = GetResults<broadband_online_status_results>("Broadband/broadband_online_status.json");
            return results;
        }
      
        /// <summary>
        /// Returns the online status of a specific broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_online_status</returns>
        private broadband_online_status GetBroadbandOnlineStatusForUser(string fullUsername) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);
            broadband_online_status result = GetResults<broadband_online_status_results>("Broadband/broadband_online_status.json").online_statuses.First();
            return result;

        }
             
        /// <summary>
        /// Terminates the online status of a specific broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>terminated online status of the broadband user</returns>
        private broadband_online_status_termination TerminateBroadbandUserSession(string fullUsername) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);

            // Initialize the broadband_online_status object.
            broadband_online_status_termination broadbandStatus = new broadband_online_status_termination() {
                is_success_response = true,
                message = "Success"
            };

            return broadbandStatus;
        }

    }
}
