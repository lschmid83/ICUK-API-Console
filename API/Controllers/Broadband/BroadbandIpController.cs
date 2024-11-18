using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.</description>
    public class BroadbandIpController : IcukApiController {

        #region API Methods

        /// <name>Gets broadband IP information</name> 
        /// <description>Retrieves the static, routed and Ipv6 information of a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/ip/{user@realm}</url>
        /// <group>Broadband IP</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_ip_results</type>
        ///     <field>ip_results</field>
        ///     <description>broadband_ip_results struct.</description>
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
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "ip": %ipv4%,
        ///     "allocation": %ip_allocation_type%,
        ///     "routed": [
        ///         {
        ///             "ip": %ipv4%,
        ///             "network": %ipv4_network%,
        ///             "netmask": %ipv4_netmask%,
        ///             "usable": [
        ///                 %ipv4%
        ///             ],
        ///             "broadcast": %ipv4_broadcast%
        ///         }
        ///     ],
        ///     "ipv6": {
        ///         "ip": %ipv6%,
        ///         "network": %ipv6_network%,
        ///         "netmask": %ipv6_netmask%,
        ///         "range": %ip_range%,
        ///         "broadcast": %ipv6_broadcast% 
        ///     }
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_ip_results Get(string username) {
            return GetIpAllocations(username);
        }

        /// <name>Assigns a static IPv4 address</name>
        /// <description>Assigns a static IPv4 address to a broadband user.</description>
        /// <type>Post</type>
        /// <url>/broadband/ip/static/{user@realm}</url>
        /// <group>Broadband IP</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
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
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/ip/static/{user@realm}
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/ip/{user@realm}
        ///     </content>
        /// </example>
        [HttpPost]
        [ActionName("Static")]
        public HttpResponseMessage Post(string username) {
            return CreateStaticIp(username);
        }

        /// <name>Assigns a routed IPv4 address</name>
        /// <description>Assigns a routed IPv4 address of the supplied size to a broadband user and updates the RIPE database with the supplied RIPE NIC handle. If the current allocation is dynamic a static IP will also be created.</description>
        /// <type>Post</type>
        /// <url>/broadband/ip/routed/{user@realm}</url>
        /// <group>Broadband IP</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>broadband_ip_allocation</type>
        ///     <field>ip_allocation</field>
        ///     <optional>false</optional>
        ///     <description>broadband_ip_allocation struct.</description>
        /// </parameter> 
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
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/ip/routed/{user@realm}
        /// {
        ///     "prefix": "",
        ///     "ripe_admin_nic_handle": "",
        ///     "ripe_tech_nic_handle": "",
        ///     "justification": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/ip/{user@realm}
        ///     </content>
        /// </example>
        [HttpPost]
        [ActionName("Routed")]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_ip_allocation))]
        public HttpResponseMessage Post(string username, [FromBody]broadband_ip_allocation value) {
            return CreateRoutedIp(username, value);
        }

        /// <name>Removes a static IP address</name>
        /// <description>Removes a static IP address and all routed subnets from a broadband user.</description>
        /// <type>Delete</type>
        /// <url>/broadband/ip/static/{user@realm}</url>
        /// <group>Broadband IP</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
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
        /// <error>
        ///     <type>DeleteResourceException</type>   
        /// </error>
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        ///     </content>
        /// </example>
        [HttpDelete]
        [ActionName("Static")]
        public HttpResponseMessage Delete(string username) {
            return DeleteStaticIp(username);
        }

        /// <name>Removes a routed subnet</name>
        /// <description>Removes a routed subnet from a broadband user.</description>
        /// <type>Delete</type>
        /// <url>/broadband/ip/routed/{user@realm}</url>
        /// <group>Broadband IP</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>broadband_ip_deallocation</type>
        ///     <field>ip_deallocation</field>
        ///     <optional>false</optional>
        ///     <description>broadband_ip_deallocation struct.</description>
        /// </parameter> 
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
        /// <error>
        ///     <type>DeleteResourceException</type>   
        /// </error>
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// DELETE /broadband/ip/routed/{user@realm}
        /// {
        ///     "prefix": 0,
        ///     "ip": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        ///     </content>
        /// </example>
        [HttpDelete]
        [ActionName("Routed")]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_ip_deallocation))]
        public HttpResponseMessage Delete(string username, [FromBody]broadband_ip_deallocation value) {
            return DeleteRoutedIp(username, value);
        }
        
        /// <summary>
        /// Validates a broadband_ip_deallocation struct.
        /// </summary>
        /// <param name="ipDeallocation">broadband_ip_deallocation</param>
        private void ValidateRoutedIpDeallocation(broadband_ip_deallocation ipDeallocation) {

            if (ipDeallocation.prefix == null)
                throw new InvalidParameterException("IP prefix cannot be blank.");
            
            // Check the IP prefix is within the allowed range
            if (ipDeallocation.prefix < 27 || ipDeallocation.prefix > 30)
                throw new InvalidParameterException("IP prefix must be between 27 and 30.");

            if (!Validation.ValidIpAddress(ipDeallocation.ip))
                throw new InvalidParameterException("IP address is not valid.");
        }
        
        /// <summary>
        /// Validates a broadband_ip_allocation struct.
        /// </summary>
        /// <param name="ipAllocation">broadband_ip_allocation</param>
        /// <param name="parentId">Parent account ID.</param>
        private void ValidateRoutedIpAllocation(broadband_ip_allocation ipAllocation, int parentId) {

            if(ipAllocation.prefix == null)
                throw new InvalidParameterException("IP prefix cannot be blank.");

            // Check the IP prefix is within the allowed range
            if (ipAllocation.prefix < 27 || ipAllocation.prefix > 30)
                throw new InvalidParameterException("IP prefix must be between 27 and 30.");
        }
 
        /// <summary>
        /// Assigns a routed IP address to a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="routedIpAssignment">IP assignment details.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CreateRoutedIp(string fullUsername, broadband_ip_allocation routedIpAssignment) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);

            ValidateRoutedIpAllocation(routedIpAssignment, 0);

            // Set the location header and include an entity that describes the result
            HttpResponseMessage response = Request.CreateResponse<broadband_ip_allocation>(HttpStatusCode.Created, routedIpAssignment);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_BroadbandIp_View"));
            return response;
        }

        /// <summary>
        /// Assigns a static IP address to a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CreateStaticIp(string fullUsername) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);

            // Set the location header
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_BroadbandIp_View"));
            return response;
        }

        #endregion
        
        /// <summary>
        /// Retrieves the static, routed and Ipv6 information for a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_ip_results</returns>
        private broadband_ip_results GetIpAllocations(string fullUsername) {
            broadband_ip_results results = GetResults<broadband_ip_results>("Broadband/broadband_ip_allocation_user.json");
            return results;

        }

        /// <summary>
        /// Calculates properties of an IP address.
        /// </summary>
        /// <returns>broaband_ipv4</returns>
        private broadband_ipv4 GetIpv4Properties(string ipAddress) {
            // Initialize broadband_ipv4 object
            broadband_ipv4 broadbandIpv4 = new broadband_ipv4();
            return broadbandIpv4;

        }

        /// <summary>
        /// Remove a routed subnet from a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="broadbandIpDeallocation">broadband_ip_deallocation</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage DeleteRoutedIp(string fullUsername, broadband_ip_deallocation broadbandIpDeallocation) {               
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
                
        /// <summary>
        /// Remove a static IP address from a user and all routed subnets.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage DeleteStaticIp(string fullUsername) {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}