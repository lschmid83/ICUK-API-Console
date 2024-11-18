using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Utils.IP;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for creating, retrieving, updating and deleting IPv6 addresses for a broadband user.</description>
    public class BroadbandIpv6Controller : IcukApiController {

        /// <name>Assigns a IPv6 address</name>
        /// <description>Assigns a IPv6 address to a broadband user</description>
        /// <type>Post</type>
        /// <url>/broadband/ipv6/{user@realm}</url>
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
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/ipv6/{user@realm}
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
        public HttpResponseMessage Post(string username) {
            return CreateIpv6(username);
        }
        
        /// <name>Removes a IPv6 address</name>
        /// <description>Removes a IPv6 address from a broadband user.</description>
        /// <type>Delete</type>
        /// <url>/broadband/ipv6/{user@realm}</url>
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
        ///     <type>DeleteResourceException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>  
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        ///     </content>
        /// </example>
        [HttpDelete]
        public HttpResponseMessage Delete(string username) {
            return DeleteIpv6(username);
        }
        
        /// <summary>
        /// Removes a IPv6 address from a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage DeleteIpv6(string fullUsername) {
            return new HttpResponseMessage(HttpStatusCode.NoContent);

        }

        /// <summary>
        /// Assigns a IPv6 address to a user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CreateIpv6(string fullUsername) {
            // Set the location header
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_BroadbandIp_View"));
            return response;

        }

        /// <summary>
        /// Validates a broadband_ip_deallocation struct.
        /// </summary>
        /// <param name="ipDeallocation">broadband_ip_deallocation</param>
        private void ValidateIpv6Deallocation(ref broadband_ip_deallocation ipDeallocation) {

            if (ipDeallocation.prefix == null) {
                ipDeallocation.prefix = 48;
            }

            if (ipDeallocation.prefix != 48) {
                throw new InternalApiException("IPv6 prefix must be 48.");
            }

            ipDeallocation.ip = IPv6Converter.ConvertFromIpV6Shorthand(ipDeallocation.ip);

            if (!Validation.ValidIp6Address(ipDeallocation.ip))
                throw new InvalidParameterException("IPv6 address is not valid.");

        }
    }
}