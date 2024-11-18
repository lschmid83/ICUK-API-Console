using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Web.Http;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for provisionally checking your ability to receive Broadband services from ICUK.</description>
    public class BroadbandAvailabilityController : IcukApiController {

        /// <name>Gets broadband availability</name>
        /// <description>Search for your phone number or postcode and return a list of available broadband products with the speeds available.</description>
        /// <type>Get</type>
        /// <url>/broadband/availability/{cli_or_postcode}</url>
        /// <group>Broadband Availability</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>cli_or_postcode</field>
        ///     <description>Phone number or postcode.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_availability_results</type>
        ///     <field>availability</field>
        ///     <description>Represents broadband availability results.</description>
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
        ///     "exchange": {
        ///         "status": "",
        ///         "message": "",
        ///         "exchange_code": "",
        ///         "exchange_name": ""
        ///     },
        ///     "products": [
        ///         {
        ///             "name": "",
        ///             "likely_down_speed": 0,
        ///             "likely_up_speed": 0,
        ///             "availability": true
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_availability_results Get(string cli_or_postcode) {
            return GetBroadbandProducts(cli_or_postcode);
        }

        /// <name>Gets broadband availability for exact address</name>
        /// <description>Search with your exact BT address match and return a list of available broadband products with the speeds available.</description>
        /// <type>POST</type>
        /// <url>/broadband/availability</url>
        /// <group>Broadband Availability</group>
        /// <parameter>
        ///     <type>broadband_address</type>
        ///     <field>address</field>
        ///     <description>broadband_address struct.</description>
        /// </parameter>  
        /// <success>
        ///     <type>broadband_availability_results</type>
        ///     <field>availability</field>
        ///     <description>Represents broadband availability results.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/availability/
        /// {
        ///     "postcode": "",
        ///     "district_id": ""
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "exchange": {
        ///         "status": "",
        ///         "message": "",
        ///         "exchange_code": "",
        ///         "exchange_name": ""
        ///     },
        ///     "products": [
        ///         {
        ///             "name": "",
        ///             "likely_down_speed": 0,
        ///             "likely_up_speed": 0,
        ///             "availability": true
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example>
        [HttpPost]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_address))]
        public broadband_availability_results Get(broadband_address value) {
            return GetBroadbandProducts(value);
        }

        /// <summary>
        /// Search for your CLI, postcode or address search ID and returns a list of available broadband products.
        /// </summary>
        /// <param name="address">broadband_address object.</param>
        /// <returns>broadband_availabilities container.</returns>
        private broadband_availability_results GetBroadbandProducts(broadband_address address) {

            if (!Validation.ValidPostcode(address.postcode)) {
                throw new InvalidParameterException("Parameter is not a valid postcode.");
            }

            broadband_availability_results results = GetResults<broadband_availability_results>("Broadband/broadband_availability_exact.json");
            return results;
        }

        /// <summary>
        /// Search for your CLI, postcode or address search ID and returns a list of available broadband products.
        /// </summary>
        /// <param name="cli_or_postcode">CLI, postcode or address search ID.</param>
        /// <returns>broadband_availabilities container.</returns>
        private broadband_availability_results GetBroadbandProducts(string cli_or_postcode) {

            broadband_availability_results results; 
            if (Validation.ValidUkPhoneNumber(cli_or_postcode)) {
                results = GetResults<broadband_availability_results>("Broadband/broadband_availability_cli.json");
            }
            else if (Validation.ValidPostcode(cli_or_postcode)) {
                results = GetResults<broadband_availability_results>("Broadband/broadband_availability_postcode.json");
            }
            else {
                throw new InvalidParameterException("Parameter is not a valid phone number or postcode.");
            }
            return results;

        }

    }

}
