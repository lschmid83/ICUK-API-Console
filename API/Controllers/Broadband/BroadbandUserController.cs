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
using System.Web.Http;

namespace API.Controllers.Broadband {

    /// <description>Methods for retrieving, creating, updating and deleting broadband users.</description>
    public class BroadbandUserController : IcukApiController {
                
        /// <name>Gets all broadand users</name>
        /// <description>Retrieves all the broadband users belonging to the API user.</description>
        /// <type>Get</type>
        /// <url>/broadband/user</url>
        /// <group>Broadband User</group>
        /// <success>
        ///     <type>broadband_user[]</type>
        ///     <field>broadband_users</field>
        ///     <description>Array of broadband_user structs.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "broadband_users": [
        ///         {
        ///             "username": %username%,
        ///             "password": "",
        ///             "cli": "",
        ///             "product": "",
        ///             "forename": "",
        ///             "surname": "",
        ///             "installation_address": {
        ///                 "house_name": "",
        ///                 "street_name": "",
        ///                 "town": "",
        ///                 "county": "",
        ///                 "postcode": ""
        ///             },
        ///             "is_online": true
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        public broadband_user_results Get() {
            return GetBroadbandUsers();
        }

        /// <name>Gets a broadband user</name> 
        /// <description>Retrieves a broadband user belonging to the API user.</description>
        /// <type>Get</type>
        /// <url>/broadband/user/{user@realm}</url>
        /// <group>Broadband User</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_user</type>
        ///     <field>broadband_user</field>
        ///     <description>broadband_user struct.</description>
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
        ///     "password": "",
        ///     "cli": "",
        ///     "product": "",
        ///     "forename": "",
        ///     "surname": "",
        ///     "installation_address": {
        ///         "house_name": "",
        ///         "street_name": "",
        ///         "town": "",
        ///         "county": "",
        ///         "postcode": ""
        ///     },
        ///     "is_online": true
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_user Get(string username) {
            return GetBroadbandUsers(username).broadband_users.FirstOrDefault<broadband_user>();
        }

        /// <name>Deletes a broadband user</name>
        /// <description>Deletes a broadband user belonging to the API user.</description>
        /// <type>Delete</type>
        /// <url>/broadband/user/{user@realm}</url>
        /// <group>Broadband User</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <optional>false</optional>
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
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        ///     </content>
        /// </example>
        [HttpDelete] 
        public HttpResponseMessage Delete(string username) {
            return DeleteBroadbandUser(username);
        }

        /// <summary>
        /// Deletes a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage DeleteBroadbandUser(string fullUsername) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0);

            // Check the account can be closed.
            if (!broadbandUser.IsClosed) {
                throw new DeleteResourceException("This account cannot be deleted.");
            }
 
            return new HttpResponseMessage(HttpStatusCode.NoContent);

        }
        
        /// <summary>
        /// Retrieves broadband user information.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_user_results</returns>
        private broadband_user_results GetBroadbandUsers(string fullUsername = null) {

            broadband_user_results broadbandUsers = new broadband_user_results();
            broadbandUsers.broadband_users = new List<broadband_user>();
 
            // Create the user.
            broadband_user user = new broadband_user {
            };

            // Create the user installation address.
            broadband_order_address address = new broadband_order_address() {
            };
            user.installation_address = address;
                        
            // Add to the list.
            broadbandUsers.broadband_users.Add(user);


            return broadbandUsers;
       }
    }
}
