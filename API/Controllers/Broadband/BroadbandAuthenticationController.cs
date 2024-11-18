using API.Controllers.Broadband.Types;
using API.Core;
using System.Web.Http;

namespace API.Controllers.Broadband {

    /// <description> Methods for retrieving the authentication logs of broadband users.</description>
    public class BroadbandAuthenticationController : IcukApiController {

        /// <name>Gets broadband authentication attempts</name>
        /// <description>Retrieves the past 50 authentication attempts for a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/authentication_logs/{user@realm}</url>
        /// <group>Broadband Authentication</group>
        ///  <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_authentication_log[]</type>
        ///     <field>authentication_logs</field>
        ///     <description>Array of broadband_authentication_log structs.</description>
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
        ///     "authentication_logs": [
        ///         {
        ///             "username": %username%,
        ///             "reply": true,
        ///             "additional_details": "Accept",
        ///             "time": %timestamp%
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        public broadband_authentication_log_results Get(string username) {
            return GetAuthenticationHistory(username);
        }

        /// <summary>
        /// Returns the past 50 authentication history for a specific broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>Array of authentication history.</returns>
        private broadband_authentication_log_results GetAuthenticationHistory(string fullUsername) {
            
            broadband_authentication_log_results results = GetResults<broadband_authentication_log_results>("Broadband/broadband_authentication_log.json");
            return results;

        }

    }
}