using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utils.Text;

namespace API.Controllers.Broadband {
    
    /// <description>Methods for provisionally checking your ability to receive Broadband services from ICUK.</description>
    public class BroadbandContactController : IcukApiController {

        /// <name>Gets broadband contact details</name> 
        /// <description>Retrieves the contact details for a broadband user.</description>
        /// <type>Get</type>
        /// <url>/broadband/user/contact/{user@realm}</url>
        /// <group>Broadband Contact</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_user_contact</type>
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
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "forename": "",
        ///     "surname": "",
        ///     "phone": "",
        ///     "email": ""
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_user_contact Get(string username) {
            return GetBroadbandUserContactDetails(username);
        }

        /// <name>Updates broadband contact details</name>
        /// <description>Changes a broadband users contact details.</description>
        /// <type>Put</type>
        /// <url>/broadband/user/contact/{user@realm}</url>
        /// <group>Broadband Contact</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <optional>false</optional>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>broadband_user_contact</type>
        ///     <field>contact</field>
        ///     <optional>true</optional>
        ///     <description>broadband_user_contact struct.</description>
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
        /// PUT /broadband/user/contact/{user@realm}
        /// {
        ///     "forename": "",
        ///     "surname": "",
        ///     "phone": "",
        ///     "email": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        /// /broadband/user/contact/{user@realm}
        ///     </content>
        /// </example>
        [HttpPut]
        [ApiFromBodyFilter(Parameter = "broadbandUserContact", DataType = typeof(broadband_user_contact))]
        public HttpResponseMessage Put(string username, [FromBody]broadband_user_contact broadbandUserContact) {
            return UpdateBroadbandUserContact(username, broadbandUserContact);
        }

        /// <summary>
        /// Validate broadband user contact details.
        /// </summary>
        /// <param name="broadbandUserContact">broadband_user_contact</param>
        /// <returns>True if the fields are valid; otherwise false.</returns>
        private bool Validate(broadband_user_contact broadbandUserContact) {

            if (String.IsNullOrWhiteSpace(broadbandUserContact.forename)) {
                throw new InvalidParameterException("Forename cannot be blank.");
            }

            if (String.IsNullOrWhiteSpace(broadbandUserContact.surname)) {
                throw new InvalidParameterException("Surname cannot be blank.");
            }

            if (String.IsNullOrWhiteSpace(broadbandUserContact.surname)) {
                throw new InvalidParameterException("Phone number cannot be blank.");
            }

            if (String.IsNullOrWhiteSpace(broadbandUserContact.surname)) {
                throw new InvalidParameterException("Phone number cannot be blank.");
            }
            
            if (!Validation.ValidUkPhoneNumber(broadbandUserContact.phone)) {
                throw new InvalidParameterException("An invalid phone number was entered.");
            }

            if (!String.IsNullOrEmpty(broadbandUserContact.email) && !Validation.ValidEmailAddress(broadbandUserContact.email)) {
                throw new InvalidParameterException("An invalid email address was entered.");
            }
                        
            return true;
        }

        /// <summary>
        /// Updates broadband user contact information.
        /// </summary>
        /// <param name="fullUsername">The existing username.</param>
        /// <param name="broadbandUserContact">broadband_user_contact</param>
        /// <returns>True if the contact is updated succesfully; otherwise false.</returns>
        private HttpResponseMessage UpdateBroadbandUserContact(string fullUsername, broadband_user_contact broadbandUserContact) {

            // Validate contact details.
            Validate(broadbandUserContact);

            try
            {
                // Set the location header.
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NoContent);
                response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_UserContact_View_Update"));
                return response;
            }
            catch {
                throw new InternalApiException("Unable to update the broaband user contact information.");
            }
        }

        /// <summary>
        /// Gets broadband user contact details from a username.
        /// </summary>
        /// <param name="fullUsername">The existing username.</param>
        /// <returns>broadband_user_contact</returns>
        private broadband_user_contact GetBroadbandUserContactDetails(string fullUsername) {
    
            // Initialize the results.
            broadband_user_contact contact = new broadband_user_contact() {};

            return contact;
        }

    }
}
