using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for creating, retrieving, updating and deleting RIPE person contact details.</description>
    public class BroadbandRipePersonController : IcukApiController {

        #region API Methods

        /// <name>Gets RIPE person contacts that have been created</name> 
        /// <description>Retrieves the RIPE person contacts that have been created for broadband accounts assigned to the reseller.</description>
        /// <type>Get</type>
        /// <url>/broadband/ripe/person</url>
        /// <group>Broadband RIPE Person</group>
        /// <success>
        ///     <type>broadband_ripe_person[]</type>
        ///     <field>ripe_persons</field>
        ///     <description>Array of broadband_ripe_person[] structs.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "ripe_persons": [
        ///         {
        ///             "name": "",
        ///             "nic_handle": "",
        ///             "mnt_by": "",
        ///             "address_line_1": "",
        ///             "address_line_2": "",
        ///             "town": "",
        ///             "county": "",
        ///             "postcode": "",
        ///             "phone_number": ""
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_ripe_person_results Get() {
            return GetRipePersonsAssignedToReseller();
        }

        /// <name>Gets the RIPE person contacts for a specific nic-handle</name> 
        /// <description>Retrieves a RIPE person contact for a specific nic-handle that has been created for a broadband account assigned to the reseller.</description>
        /// <type>Get</type>
        /// <url>/broadband/ripe/person/{ripe_nic_handle}</url>
        /// <group>Broadband RIPE Person</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>ripe_nic_handle</field>
        ///     <optional>false</optional>
        ///     <description>RIPE nic-handle.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_ripe_person</type>
        ///     <field>ripe_person</field>
        ///     <description>broadband_ripe_person struct.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error> 
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "name": "",
        ///     "nic_handle": "",
        ///     "mnt_by": "",
        ///     "address_line_1": "",
        ///     "address_line_2": "",
        ///     "town": "",
        ///     "county": "",
        ///     "postcode": "",
        ///     "phone_number": ""
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_ripe_person Get(string ripe_nic_handle) {
            return GetRipePersonAssignedToReseller(ripe_nic_handle);
        }

        /// <name>Creates a RIPE person contact details</name>
        /// <description>Creates a RIPE person contact assigned to the reseller.</description>
        /// <type>Post</type>
        /// <url>/broadband/ripe/person</url>
        /// <group>Broadband RIPE Person</group>
        /// <parameter>
        ///     <type>broadband_ripe_person</type>
        ///     <field>ripe_person</field>
        ///     <optional>false</optional>
        ///     <description>broadband_ripe_person struct.</description>
        /// </parameter>  
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error> 
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error> 
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/ripe/person
        /// {
        ///     "name": "",
        ///     "address_line_1": "",
        ///     "address_line_2": "",
        ///     "town": "",
        ///     "county": "",
        ///     "postcode": "",
        ///     "phone_number": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/ripe/person/{ripe_nic_handle}
        ///     </content>
        /// </example>
        [HttpPost]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_ripe_person))]
        public HttpResponseMessage Post([FromBody]broadband_ripe_person value) {
            return CreateRipePersons(value);
        }

        /// <name>Updates the RIPE person contact details for a nic-handle</name>
        /// <description>Changes the RIPE person contact details for a nic-handle.</description>
        /// <type>Put</type>
        /// <url>/broadband/ripe/person/{ripe_nic_handle}</url>
        /// <group>Broadband RIPE Person</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>ripe_nic_handle</field>
        ///     <optional>false</optional>
        ///     <description>RIPE nic-handle.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>broadband_ripe_person</type>
        ///     <field>ripe_person</field>
        ///     <optional>false</optional>
        ///     <description>broadband_ripe_person struct.</description>
        /// </parameter>  
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example> 
        ///     <title>Request</title>
        ///     <content>
        /// PUT /broadband/ripe/person/{ripe_nic_handle}
        /// {
        ///     "name": "",
        ///     "address_line_1": "",
        ///     "address_line_2": "",
        ///     "town": "",
        ///     "county": "",
        ///     "postcode": "",
        ///     "phone_number": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 204 OK
        /// /broadband/ripe/person/{ripe_nic_handle}
        ///     </content>
        /// </example>
        [HttpPut]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_ripe_person))]
        public HttpResponseMessage Put(string ripe_nic_handle, [FromBody]broadband_ripe_person value) {
            return UpdateRipePerson(ripe_nic_handle, value);
        }

        /// <name>Deletes the RIPE person contact details for a nic-handle</name>
        /// <description>Deletes the RIPE person contact details for a nic-handle.</description>
        /// <type>Delete</type>
        /// <url>/broadband/ripe/person/{ripe_nic_handle}</url>
        /// <group>Broadband RIPE Person</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>ripe_nic_handle</field>
        ///     <optional>false</optional>
        ///     <description>RIPE nic-handle.</description>
        /// </parameter>
        /// <error>
        ///     <type>NonExistentUserException</type>   
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
        public HttpResponseMessage Delete(string ripe_nic_handle) {
            return DeleteRipePerson(ripe_nic_handle);
        }
                
        #endregion
  
        /// <summary>
        /// Validates broadband_ripe_person object.
        /// </summary>
        /// <param name="person">broadband_ripe_person</param>
        private void ValidateRipePerson(broadband_ripe_person person) {

            // Check person name
            if (String.IsNullOrWhiteSpace(person.name)) {
                throw new InvalidParameterException("Person name cannot be blank.");
            }
            else {
                string[] nameSplit = person.name.Split(' ');
                if (nameSplit.Count() < 2) {
                    throw new InvalidParameterException("A valid person name must contain at least 2 words separate by one or more spaces.");
                }
            }

            // Check address line 1
            if (String.IsNullOrWhiteSpace(person.address_line_1)) {
                throw new InvalidParameterException("Address line 1 cannot be blank.");
            }

            // Check address line 2
            if (String.IsNullOrEmpty(person.address_line_2))
                person.address_line_2 = "";

            // Check town
            if (String.IsNullOrWhiteSpace(person.town)) {
                throw new InvalidParameterException("Town cannot be blank.");
            }

            // Check county
            if (String.IsNullOrWhiteSpace(person.county)) {
                throw new InvalidParameterException("County cannot be blank.");
            }

            // Check postcode
            if (String.IsNullOrWhiteSpace(person.postcode)) {
                throw new InvalidParameterException("Postcode cannot be blank.");
            }

            // Check phone number
            if (String.IsNullOrWhiteSpace(person.phone_number)) {
                throw new InvalidParameterException("Phone number cannot be blank.");
            }
            else {
                if (!Validation.ValidRipePhoneNumber(person.phone_number)) {
                    throw new InvalidParameterException("Phone number must be composed of a + character followed by a countrycode and phonenumber without leading 0.");
                }
            }
        }

        /// <summary>
        /// Add person contact to ICUK and RIPE database.
        /// </summary>
        /// <param name="broadbandRipePerson">broadband_ripe_person</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CreateRipePersons(broadband_ripe_person broadbandRipePerson) {

            ValidateRipePerson(broadbandRipePerson);

            // Set the location header and include an entity that describes the result
            HttpResponseMessage response = Request.CreateResponse<broadband_ripe_person>(HttpStatusCode.Created, broadbandRipePerson);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_BroadbandRipePerson_Create_View_Update_Delete") + "/" + broadbandRipePerson.nic_handle);
            return response;

        }
        
        /// <summary>
        /// Retrieves the RIPE person contacts that have been created for the reseller account.
        /// </summary>
        /// <returns>broadband_ripe_person_results</returns>
        private broadband_ripe_person_results GetRipePersonsAssignedToReseller() {

            broadband_ripe_person_results results = GetResults<broadband_ripe_person_results>("Broadband/broadband_ripe_person.json");
            return results;

        }

        /// <summary>
        /// Retrieves a RIPE person contact that has been created for the reseller account.
        /// </summary>
        /// <param name="ripe_nic_handle">ripe_nic_handle</param>
        /// <returns>broadband_ripe_person</returns>
        private broadband_ripe_person GetRipePersonAssignedToReseller(string ripe_nic_handle) {

            broadband_ripe_person result = GetResults<broadband_ripe_person_results>("Broadband/broadband_ripe_person.json").ripe_persons.First();
            result.nic_handle = ripe_nic_handle;
            return result;
        }
 
        /// <summary>
        /// Update RIPE person contact.
        /// </summary>
        /// <param name="ripe_nic_handle">RIPE NIC handle.</param>
        /// <param name="broadbandRipePerson">broadband_ripe_person</param>
        /// <returns>HttpResponseMessage.</returns>
        private HttpResponseMessage UpdateRipePerson(string ripe_nic_handle, broadband_ripe_person broadbandRipePerson) {

            ValidateRipePerson(broadbandRipePerson);

            // Set the location header
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NoContent);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "Broadband_BroadbandRipePerson_Create_View_Update_Delete") + "/" + broadbandRipePerson.nic_handle);
            return response;
        }

        /// <summary>
        /// Deletes a RIPE persons contact.
        /// </summary>
        /// <param name="ripe_nic_handle">RIPE NIC handle.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage DeleteRipePerson(string ripe_nic_handle) {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
  
    }

}