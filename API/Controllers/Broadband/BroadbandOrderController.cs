using API.Controllers.Broadband.Enum;
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
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Utils.Text;

namespace API.Controllers.Broadband
{

    /// <description>Methods for ordering broadband products.</description>
    public class BroadbandOrderController : IcukApiController
    {

        #region API Methods

        /// <name>Orders a broadband product</name>
        /// <description>Orders a new ADSL broadband product for a telephone line or address that does not currently have ADSL installed.</description>
        /// <type>Post</type>
        /// <url>/broadband/order/provide</url>
        /// <group>Broadband Order</group>  
        /// <parameter>
        ///     <type>broadband_order_details</type>
        ///     <field>order</field>
        ///     <description>broadband_order_details struct.</description>
        /// </parameter>  
        /// <parameter>
        ///     <type>broadband_order_customer</type>
        ///     <field>customer</field>
        ///     <description>broadband_order_customer struct.</description>
        /// </parameter> 
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>PasswordException</type>   
        /// </error>
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/order/provide
        /// {
        ///     "order": {
        ///         "username": %username%,
        ///         "password": "",
        ///         "simultaneous_provide": false,
        ///         "bt_order_reference": "",
        ///         "product_id": 0,
        ///         "activation_date": "2014-03-19",
        ///         "losing_isp": "unknown",
        ///         "fast_track": false,
        ///         "care_level": "STANDARD",
        ///         "send_completion_email": false,
        ///         "customer": {
        ///             "forename": "",
        ///             "surname": "",
        ///             "address": {
        ///                 "house_name": "",
        ///                 "street_name": "",
        ///                 "town": "",
        ///                 "county": "",
        ///                 "post_code": ""
        ///             },
        ///             "contact": {
        ///                 "contact_number": "",
        ///                 "contact_mobile": "",
        ///                 "email_address": ""
        ///             }
        ///         }
        ///     }
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/user/{user@realm}
        ///     </content>
        /// </example>
        [HttpPost]
        [ActionName("ProvideOrder")]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_order))]
        public HttpResponseMessage PostProvideOrder(broadband_order value)
        {
            return CreateBroadbandOrder(value, "provide");
        }

        /// <name>Orders a migration to a broadband product</name>
        /// <description>Orders a migration of an existing ADSL broadband connection for a telephone line or address.</description>
        /// <type>Post</type>
        /// <url>/broadband/order/migrate</url>
        /// <group>Broadband Order</group>  
        /// <parameter>
        ///     <type>broadband_order_details</type>
        ///     <field>order</field>
        ///     <description>broadband_order_details struct.</description>
        /// </parameter>  
        /// <parameter>
        ///     <type>broadband_order_customer</type>
        ///     <field>customer</field>
        ///     <description>broadband_order_customer struct.</description>
        /// </parameter> 
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>PasswordException</type>   
        /// </error>
        /// <error>
        ///     <type>PaymentException</type>   
        /// </error>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Request</title>
        ///     <content>
        /// POST /broadband/order/migrate
        /// {
        ///     "order": {
        ///         "username": %username%,
        ///         "password": "",
        ///         "simultaneous_provide": false,
        ///         "bt_order_reference": "",
        ///         "product_id": 0,
        ///         "activation_date": "2014-03-19",
        ///         "mac_code": "",
        ///         "losing_isp": "unknown",
        ///         "fast_track": false,
        ///         "care_level": "STANDARD",
        ///         "send_completion_email": false,
        ///         "customer": {
        ///             "forename": "",
        ///             "surname": "",
        ///             "address": {
        ///                 "house_name": "",
        ///                 "street_name": "",
        ///                 "town": "",
        ///                 "county": "",
        ///                 "post_code": ""
        ///             },
        ///             "contact": {
        ///                 "contact_number": "",
        ///                 "contact_mobile": "",
        ///                 "email_address": ""
        ///             }
        ///         }
        ///     }
        /// }
        ///     </content>
        /// </example>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/user/{user@realm}
        ///     </content>
        /// </example>
        [HttpPost]
        [ActionName("MigrateOrder")]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_order))]
        public HttpResponseMessage PostMigrateOrder(broadband_order value)
        {
            return CreateBroadbandOrder(value, "migrate");
        }

        /// <name>Ceases a broadband user</name>
        /// <description>Places a cease order for a existing ADSL broadband connection for a specific date.</description>
        /// <type>Post</type>
        /// <url>/broadband/order/cease/{user@realm}</url>
        /// <group>Broadband Order</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter> 
        /// <parameter>
        ///     <type>broadband_order_cease</type>
        ///     <field>cease</field>
        ///     <description>broadband_order_cease struct.</description>
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
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 201 OK
        /// /broadband/user/{user@realm}
        ///     </content>
        /// </example>
        [HttpPost]
        [ActionName("CeaseOrder")]
        [ApiFromBodyFilter(Parameter = "value", DataType = typeof(broadband_order_cease))]
        public HttpResponseMessage PostCeaseOrder(string username, [FromBody] broadband_order_cease value)
        {
            return CeaseBroadbandOrder(username, value);
        }

        /// <name>Gets broadband order summary for order type and status</name>
        /// <description>Retrieves the broadband order summary for all users for the specified order type and status.</description>
        /// <type>Get</type>
        /// <url>/broadband/order/{order_type}/{order_status}</url>
        /// <group>Broadband Order</group>
        /// <parameter>
        ///     <type>broadband_order_type</type>
        ///     <field>order_type</field>
        ///     <description>Order type.</description>
        ///     <optional>true</optional>
        /// </parameter> 
        /// <parameter>
        ///     <type>broadband_order_status</type>
        ///     <field>order_status</field>
        ///     <description>Order status.</description>
        ///     <optional>true</optional>
        /// </parameter>  
        /// <success>
        ///     <type>broadband_order_summary[]</type>
        ///     <field>broadband_orders</field>
        ///     <description>Array of broadband_order_summary structs.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "broadband_orders": [
        ///         {
        ///             "order_id": 0,
        ///             "reference": "",
        ///             "product_id": 0,
        ///             "technology": "",
        ///             "cli": "",
        ///             "mac_code": "",
        ///             "username": %username%,
        ///             "order_type": "PROVIDE",
        ///             "order_subtype": "PROVIDE_DIRECTORY_NUMBER",
        ///             "order_status": "COMPLETE",
        ///             "order_date": %start_time%,
        ///             "required_date": %end_time%,
        ///             "last_update": %end_time%
        ///        }
        ///    ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("SearchOrderSummary")]
        public broadband_order_summary_results Get(broadband_order_type order_type, broadband_order_status order_status)
        {
            return GetBroadbandOrderSummary(order_type, order_status);
        }

        /// <name>Gets broadband order summary</name>
        /// <description>Retrieves the broadband order summary for all users.</description>
        /// <type>Get</type>
        /// <url>/broadband/order</url>
        /// <group>Broadband Order</group>
        /// <success>
        ///     <type>broadband_order_summary[]</type>
        ///     <field>broadband_orders</field>
        ///     <description>Array of broadband_order_summary structs.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "broadband_orders": [
        ///         {
        ///             "order_id": 0,
        ///             "reference": "",
        ///             "product_id": 0,
        ///             "technology": "",
        ///             "cli": "",
        ///             "mac_code": "",
        ///             "username": %username%,
        ///             "order_type": "PROVIDE",
        ///             "order_subtype": "PROVIDE_DIRECTORY_NUMBER",
        ///             "order_status": "COMPLETE",
        ///             "order_date": %start_time%,
        ///             "required_date": %end_time%,
        ///             "last_update": %end_time%
        ///        }
        ///    ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("OrderSummary")]
        public broadband_order_summary_results Get()
        {
            return GetBroadbandOrderSummary();
        }

        /// <name>Gets broadband order updates</name>
        /// <description>Retrieves the broadband orders which have been updated within a datetime range.</description>
        /// <type>Get</type>
        /// <url>/broadband/order/updates/{start_date}/{end_date}</url>
        /// <group>Broadband Order</group>
        /// <parameter>
        ///     <type>DateTime</type>
        ///     <field>start_date</field>
        ///     <description>Start date.</description>
        ///     <day>-5</day>
        ///     <time>true</time>
        /// </parameter> 
        /// <parameter>
        ///     <type>DateTime</type>
        ///     <field>end_date</field>
        ///     <description>End date.</description>
        ///     <time>true</time>
        /// </parameter> 
        /// <success>
        ///     <type>broadband_order_information[]</type>
        ///     <field>orders_updates</field>
        ///     <description>Array of broadband_order_information structs.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "order_updates": [
        ///         {
        ///             "order_summary": {
        ///                 "order_id": 0,
        ///                 "reference": "",
        ///                 "product_id": 0,
        ///                 "technology": "",
        ///                 "cli": "",
        ///                 "mac_code": "",
        ///                 "username": %username%,
        ///                 "order_type": "PROVIDE",
        ///                 "order_subtype": "PROVIDE_DIRECTORY_NUMBER",
        ///                 "order_status": "COMPLETE",
        ///                 "order_date": %start_time%,
        ///                 "required_date": %end_time%,
        ///                 "last_update": %end_time%
        ///             },
        ///             "broadband_user": {
        ///                 "username": %username%,
        ///                 "password": "",
        ///                 "cli": "",
        ///                 "product": "",
        ///                 "postcode": "",
        ///                 "forename": "",
        ///                 "surname": "",
        ///                 "installation_address": {
        ///                     "house_name": "",
        ///                     "street_name": "",
        ///                     "town": "",
        ///                     "county": "",
        ///                     "postcode": ""
        ///                 },
        ///                 "is_online": false
        ///             },
        ///             "order_history": {
        ///                 "order_events": [
        ///                     {
        ///                         "date": %start_time%,
        ///                         "name": "",
        ///                         "description": ""
        ///                     }
        ///                 ]
        ///             }
        ///         }             
        ///     ]     
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("OrderUpdatesDateRange")]
        public broadband_order_update_results Get(DateTime start_date, DateTime end_date)
        {
            return GetBroadbandOrderUpdates(start_date, end_date);
        }

        /// <name>Gets a broadband order update</name>
        /// <description>Retrieves a specific broadband order which has been updated within a datetime range.</description>
        /// <type>Get</type>
        /// <url>/broadband/order/updates/{order_id}/{start_date}/{end_date}</url>
        /// <group>Broadband Order</group>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>order_id</field>
        ///     <description>Broadband order ID.</description>
        /// </parameter> 
        /// <parameter>
        ///     <type>DateTime</type>
        ///     <field>start_date</field>
        ///     <description>Start date.</description>
        ///     <day>-5</day>
        ///     <time>true</time>
        /// </parameter> 
        /// <parameter>
        ///     <type>DateTime</type>
        ///     <field>end_date</field>
        ///     <description>End date.</description>
        ///     <time>true</time>
        /// </parameter> 
        /// <success>
        ///     <type>broadband_order_information</type>
        ///     <field>order_update</field>
        ///     <description>broadband_order_information struct.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "order_summary": {
        ///         "order_id": 0,
        ///         "reference": "",
        ///         "product_id": 0,
        ///         "technology": "",
        ///         "cli": "",
        ///         "mac_code": "",
        ///         "username": %username%,
        ///         "order_type": "PROVIDE",
        ///         "order_subtype": "PROVIDE_DIRECTORY_NUMBER",
        ///         "order_status": "COMPLETE",
        ///         "order_date": %start_time%,
        ///         "required_date": %end_time%,
        ///         "last_update": %end_time%
        ///     },
        ///     "broadband_user": {
        ///          "username": %username%,
        ///          "password": "",
        ///          "cli": "",
        ///          "product": "",
        ///          "postcode": "",
        ///          "forename": "",
        ///          "surname": "",
        ///          "installation_address": {
        ///             "house_name": "",
        ///             "street_name": "",
        ///             "town": "",
        ///             "county": "",
        ///             "postcode": ""
        ///          }, 
        ///          "is_online": false
        ///     },
        ///     "order_history": {
        ///         "order_events": [
        ///             {
        ///                "date": %start_time%,
        ///                "name": "",
        ///                "description": ""
        ///             }
        ///         ]
        ///     }
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("OrderIdUpdatesDateRange")]
        public broadband_order_information? Get(int order_id, DateTime start_date, DateTime end_date)
        {

            broadband_order_information order = GetBroadbandOrderUpdates(start_date, end_date, order_id).order_updates.FirstOrDefault<broadband_order_information>();
            if (!order.Equals(default(broadband_order_information)))
                return order;
            else
                throw new InternalApiException("There were no broadband orders associated with this account that were placed within the date range.");
        }

        /// <name>Gets a broadband order details</name>
        /// <description>Retrieves the broadband order details for a broadband order ID.</description>
        /// <type>Get</type>
        /// <url>/broadband/order/{order_id}</url>
        /// <group>Broadband Order</group>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>order_id</field>
        ///     <description>Order ID.</description>
        /// </parameter> 
        /// <success>
        ///     <type>broadband_order_information</type>
        ///     <field>broadband_order</field>
        ///     <description>broadband_order_information struct.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "order_summary": {
        ///         "order_id": 0,
        ///         "reference": "",
        ///         "product_id": 0,
        ///         "technology": "",
        ///         "cli": "",
        ///         "mac_code": "",
        ///         "username": %username%,
        ///         "order_type": "PROVIDE",
        ///         "order_subtype": "PROVIDE_DIRECTORY_NUMBER",
        ///         "order_status": "COMPLETE",
        ///         "order_date": %start_time%,
        ///         "required_date": %end_time%,
        ///         "last_update": %end_time%
        ///     },
        ///     "broadband_user": {
        ///          "username": %username%,
        ///          "password": "",
        ///          "cli": "",
        ///          "product": "",
        ///          "postcode": "",
        ///          "forename": "",
        ///          "surname": "",
        ///          "installation_address": {
        ///             "house_name": "",
        ///             "street_name": "",
        ///             "town": "",
        ///             "county": "",
        ///             "postcode": ""
        ///          },
        ///          "is_online": false
        ///     },
        ///     "order_history": {
        ///         "order_events": [
        ///             {
        ///                "date": %start_time%,
        ///                "name": "",
        ///                "description": ""
        ///             }
        ///         ]
        ///     }
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("OrderDetails")]
        public broadband_order_information Get(int order_id)
        {
            return GetBroadbandOrderInformation(order_id);
        }

        #endregion

        /// <summary>
        /// Gets broadband orders which have been updated with a date range.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <param name="order_id">Broadband order ID.</param>
        private broadband_order_update_results GetBroadbandOrderUpdates(DateTime startDate, DateTime endDate, int? order_id = null)
        {

            if (startDate > DateTime.Now)
            {
                throw new InvalidParameterException("Invalid start date.");
            }

            if (endDate > DateTime.Now)
            {
                throw new InvalidParameterException("Invalid end date.");
            }

            broadband_order_update_results results = GetResults<broadband_order_update_results>("Broadband/broadband_order_updates_datetime_range.json");
            return results;

        }

        /// <summary>
        /// Gets a broadband users order details.
        /// </summary>
        /// <param name="orderId">Broadband order ID.</param>
        /// <returns>broadband_order_information</returns>
        private broadband_order_information GetBroadbandOrderInformation(int orderId)
        {

            broadband_order_information results = GetResults<broadband_order_information>("Broadband/broadband_order_details_id.json");
            return results;

        }

        /// <summary>
        /// Gets a summary of the broadband users order details.
        /// </summary>
        /// <returns>List of broadband_order_summary objects.</returns>
        private broadband_order_summary_results GetBroadbandOrderSummary(broadband_order_type type = broadband_order_type.ALL, broadband_order_status status = broadband_order_status.ALL, int? orderId = null, DateTime? startDate = null, DateTime? endDate = null)
        {

            broadband_order_summary_results results = GetResults<broadband_order_summary_results>("Broadband/broadband_order_summary_all_users.json");
            return results;

        }

        /// <summary>
        /// Ceases a broadband user account.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="cease">broadband_user_cease</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CeaseBroadbandOrder(string fullUsername, broadband_order_cease cease)
        {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);

            // Set the location header and include an entity that describes the result
            HttpResponseMessage response = Request.CreateResponse<broadband_order_cease>(HttpStatusCode.Created, cease);
            response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "BroadbandUser_View_Create_Delete"));
            return response;
        }

        /// <summary>
        /// Orders a broadband product.
        /// </summary>
        /// <param name="broadbandOrder">broadand_order</param>
        /// <param name="requestedOrderType">Order type requested by API user.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage CreateBroadbandOrder(broadband_order broadbandOrder, string requestedOrderType)
        {

            // Validate broadband order details
            ValidateBroadbandOrder(ref broadbandOrder);

            // Set the location header and include an entity that describes the result
            HttpResponseMessage response = null;
            if (Request != null)
            {
                response = Request.CreateResponse<broadband_order>(HttpStatusCode.Created, broadbandOrder);
                response.Headers.Location = new Uri(RouteUtil.GetRoutePath(Request, "BroadbandUser_View_Create_Delete") + "/" + broadbandOrder.order.username);
            }
            else
                response = new HttpResponseMessage(HttpStatusCode.Created);

            return response;
        }

        /// <summary>
        /// Validate broaband_order struct.
        /// </summary>
        /// <param name="broadbandOrder">broadband_order</param>
        private void ValidateBroadbandOrder(ref broadband_order broadbandOrder)
        {

            // Validate broadband username
            BroadbandUsername username = new BroadbandUsername(broadbandOrder.order.username);
            ValidateUsername(username.User, username.Realm);
            ValidatePassword(broadbandOrder.order.password);

            // Validate postcode
            string postCode = broadbandOrder.customer.address.postcode;
            if (string.IsNullOrEmpty(postCode) || !Validation.ValidPostcode(postCode))
            {
                throw new InvalidParameterException(@"Invalid postcode.");
            }

            // Validate forename
            if (string.IsNullOrEmpty(broadbandOrder.customer.forename))
            {
                throw new InvalidParameterException("Invalid forename supplied.");
            }

            // Validate surname
            if (string.IsNullOrEmpty(broadbandOrder.customer.surname))
            {
                throw new InvalidParameterException("Invalid surname supplied.");
            }

            // Validate address
            if (string.IsNullOrEmpty(broadbandOrder.customer.address.house_name))
            {
                throw new InvalidParameterException("Invalid house supplied.");
            }

            if (string.IsNullOrEmpty(broadbandOrder.customer.address.street_name))
            {
                throw new InvalidParameterException("Invalid street supplied.");
            }

            if (string.IsNullOrEmpty(broadbandOrder.customer.address.town))
            {
                throw new InvalidParameterException("Invalid town supplied.");
            }

            // Validate the contact number
            string cli = Regex.Replace(broadbandOrder.customer.contact.contact_number, @"[^0-9]+", "");
            if (string.IsNullOrEmpty(cli) || !Validation.ValidUkPhoneNumber(cli))
            {
                throw new InvalidParameterException("Invalid customer contact number.");
            }

            // Validate mobile number
            string contactMobile = broadbandOrder.customer.contact.contact_mobile;
            if (!string.IsNullOrEmpty(contactMobile) && !Validation.ValidUkPhoneNumber(contactMobile))
            {
                throw new InvalidParameterException("Invalid contact mobile number supplied.");
            }

            string contactEmail = broadbandOrder.customer.contact.email_address;
            if (!string.IsNullOrEmpty(contactEmail) && !Validation.ValidEmailAddress(contactEmail))
            {
                throw new InvalidParameterException("Invalid contact email address supplied.");
            }

            // Validate the COR string if simultaneous provide has been selected
            if (broadbandOrder.order.simultaneous_provide)
            {

                // Retrieve the BT reference
                string cor = broadbandOrder.order.bt_order_reference;
                if (string.IsNullOrEmpty(cor) || !Regex.IsMatch(cor, "^[a-zA-Z0-9\\-]+$"))
                {
                    throw new InvalidParameterException("Invalid BT order reference supplied.");
                }
            }

            // Validate activation date
            if (broadbandOrder.order.activation_date < DateTime.Now.Date)
            {
                throw new InvalidParameterException("Activation date cannot be in the past.");
            }

            // Validate IP allocation
            if (broadbandOrder.order.ip.allocation == broadband_ip.STATIC_ROUTED)
            {

                if (broadbandOrder.order.ip.prefix == null)
                    throw new InvalidParameterException("IP prefix cannot be blank.");

                // Check the IP prefix is within the allowed range
                if ((broadbandOrder.order.ip.prefix < 27 || broadbandOrder.order.ip.prefix > 30) && broadbandOrder.order.ip.prefix != 32)
                    throw new InvalidParameterException("IP prefix must be between 27 and 30.");


                // Validate the RIPE justification
                if (String.IsNullOrEmpty(broadbandOrder.order.ripe.ripe_justification))
                {
                    throw new InvalidParameterException("Please provide a justification for RIPE regarding why a routed IPv4 subnet is needed.");
                }

            }
        }

        /// <summary>
        /// Validates broadband password.
        /// </summary>
        /// <param name="password">Password.</param>
        private void ValidatePassword(string password)
        {

            // Validate the password
            if (string.IsNullOrEmpty(password))
            {
                throw new PasswordException("No password supplied.");
            }
            // Allow most characters in the password, but ensure special characters such as newlines cannot be entered
            else if (!Regex.IsMatch(password, @"^[a-zA-Z0-9\!\""\£\$\%\^\&\*\(\)_\-\=\{\}\[\]\;\'\#\:\@\~\,\.\/\<\>\?]+$"))
            {
                throw new PasswordException("Invalid password supplied.");
            }
            else if (password.Length < 8 || password.Length > 253)
            {
                throw new PasswordException("The password must be between 8 and 253 characters in length.");
            }
        }

        /// <summary>
        /// Validates username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="realm">Realm.</param>
        private void ValidateUsername(string username, string realm)
        {

            // Validate the username
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidParameterException("No username supplied.");
            }
            else if (!Regex.IsMatch(username, "^[a-zA-Z0-9\\-\\.]+$"))
            {
                throw new InvalidParameterException("Invalid username supplied.");
            }
            else if (username.Length < 5 || username.Length > 128)
            {
                throw new InvalidParameterException("The username must be between 5 and 128 characters in length.");
            }
        }
    }
}