using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for searching for addresses.</description>
    public class BroadbandAddressController : IcukApiController {

        /// <name>Gets broadband address</name>
        /// <description>Search for your postcode and it will return a list of BT adddress search results.</description>
        /// <type>Get</type>
        /// <url>/broadband/address_search/{postcode}</url>
        /// <group>Broadband Address</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>postcode</field>
        ///     <description>Postcode of address.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_address[]</type>
        ///     <field>addresses</field>
        ///     <description>Array of broadband_address structs.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "addresses": [
        ///         {
        ///             "sub_premises": "",
        ///             "premises_name": "",
        ///             "thoroughfare_number": "",
        ///             "thoroughfare_name": "",
        ///             "locality": "",
        ///             "post_town": "",
        ///             "post_code": "",
        ///             "district_id": "",
        ///         } 
        ///     ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_address_results Get(string postcode) {
            return GetBroadbandAddresses(postcode);
        }

        /// <summary>
        /// Bt Address Checker.
        /// </summary>
        /// <param name="postcode">Postcode.</param>
        /// <returns>broadband_addresses container.</returns>
        private broadband_address_results GetBroadbandAddresses(string postcode) {

            if (String.IsNullOrEmpty(postcode)) {
                throw new InvalidParameterException("Postcode cannot be blank.");
            }

            if (!Validation.ValidPostcode(postcode)) {
                new InvalidParameterException("Parameter is not a valid postcode.");
            }
            
            broadband_address_results results = GetResults<broadband_address_results>("Broadband/broadband_address_search.json");

            return results;

        }

    }
}
