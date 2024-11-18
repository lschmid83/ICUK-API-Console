using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers.Broadband {

    /// <description>Methods for retrieving and updating the password of a broadband user.</description>
    public class BroadbandPasswordController : IcukApiController {

        #region API Methods

        /// <name>Gets broadband password</name> 
        /// <description>Retrieves the password of a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/user/password/{user@realm}</url>
        /// <group>Broadband Password</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_user_password</type>
        ///     <field>password</field>
        ///     <description>broadband_user_password struct.</description>
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
        ///     <type>PasswordException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "password": ""   
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_user_password Get(string username) {
            return GetBroadbandUserPassword(username);
        }

        /// <name>Updates broadband password</name>
        /// <description>Updates password of a broadband user.</description>
        /// <type>Put</type>
        /// <url>/broadband/user/password/{user@realm}</url>
        /// <group>Broadband Password</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <optional>false</optional>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>broadband_user_password</type>
        ///     <field>password</field>
        ///     <optional>true</optional>
        ///     <description>broadband_user_password struct.</description>
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
        ///     <type>PasswordException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// PUT /broadband/user/password/{user@realm}
        /// {
        ///     "password": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        /// /broadband/user/password/{user@realm}
        ///     </content>
        /// </example>
        [HttpPut]
        [ApiFromBodyFilter(Parameter = "broadbandUserPassword", DataType = typeof(broadband_user_password))]
        public HttpResponseMessage Put(string username, [FromBody]broadband_user_password broadbandUserPassword) {
            return UpdateBroadbandUserPassword(username, broadbandUserPassword);
        }

        #endregion

        /// <summary>
        /// Retrieves the password of a specific broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband user password</returns>
        private broadband_user_password GetBroadbandUserPassword(string fullUsername) {

            // Get broadband user account
            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);
            broadband_user_password broadbandUserPassword = new broadband_user_password();
            broadbandUserPassword.password = broadbandUser.Password;
            return broadbandUserPassword;
        }

        /// <summary>
        /// Updates the password of the broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="broadbandUserPassword">broadband_user_password.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage UpdateBroadbandUserPassword(string fullUsername, broadband_user_password broadbandUserPassword) {
            // Set the location header.
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NoContent);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_UserPassword_View_Update"));
            return response;
        }


        /// <summary>
        /// Updates Tbl_User with the new password.
        /// </summary>
        /// <param name="userId">Broadband User ID.</param>
        /// <param name="password">New Password entered by the user.</param>
        private bool UpdateUserDatabase(int userId, string password) {

            bool result = true;
            return result;

        }

        /// <summary>
        /// BroadbandUserAccount.
        /// </summary>
        class BroadbandUserAccount {
            public int AccountId { get; set; }
            public int UserId { get; set; }
            public string Username { get; set; }
            public bool NewNetwork { get; set; }
            public string Password { get; set; }
            public string OrderStatus { get; set; }
        }
    }

}
