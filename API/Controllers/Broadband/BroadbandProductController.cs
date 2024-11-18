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
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace API.Controllers.Broadband {

    /// <description>Methods for retrieving the daily data transfer usage of broadband users.</description>
    public class BroadbandProductController : IcukApiController {

        #region API Methods

        /// <name>Gets broadband products available to reseller</name> 
        /// <description>Retrieves the reseller&apos;s available broadband products that can be ordered and their costs.</description>
        /// <type>Get</type>
        /// <url>/broadband/products</url>
        /// <group>Broadband Products</group>
        /// <success>
        ///     <type>broadband_product_results</type>
        ///     <field>broadband_product_results</field>
        ///     <description>broadband_product_results struct.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error> 
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "ip": [
        ///         {
        ///             "name": "Static IP Address",
        ///             "category": "IP",
        ///             "price": 1
        ///         }
        ///     ],
        ///     "routed": [
        ///         {
        ///             "name": "Routed /30 IPv4 Subnet",
        ///             "category": "Routed",
        ///             "price": 4,
        ///             "prefix": 30
        ///         }
        ///     ],
        ///     "elevated_best_effort": [
        ///         {
        ///             "name": "Elevated Best Effort",
        ///             "category": "Elevated Best Effort",
        ///             "price": 3
        ///         }
        ///     ],
        ///     "care": [
        ///         {
        ///             "name": "Enhanced",
        ///             "price": 15,
        ///             "category": "Care",
        ///             "care_level": 2
        ///         }
        ///     ],
        ///     "assured_rate": [
        ///         {
        ///             "name": "Assured Rate",
        ///             "category": "Assured Rate",
        ///             "price": 0.5
        ///         }
        ///     ],
        ///     "broadband_product": [
        ///         {
        ///             "id": 153,
        ///             "name": "Home 2GB Capped 20CN 512k",
        ///             "category": "Home ADSL Broadband Products",
        ///             "price": 8.5,
        ///             "fast_track_price": 200,
        ///             "provider": "WBC - 20CN",
        ///             "technology": "ADSL",
        ///             "down_speed": 512,
        ///             "up_speed": 256,
        ///             "peak_cap": 2,
        ///             "off_peak_cap": 100,
        ///             "contention": 50,
        ///             "product_class": "Home",
        ///             "provider_lead_time": 7,
        ///             "migration_lead_time": 7,
        ///             "peak_start": %peak_start%,
        ///             "peak_end": %peak_end%,
        ///             "contract_length": 1,
        ///             "legacy_product": false,
        ///             "requires_out_line_rental": false,
        ///             "unlimeted_cap": false
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        public broadband_product_results Get() {
            return GetBroadbandProducts();
        }

        /// <name>Gets broadband ADSL product for a product ID</name> 
        /// <description>Retrieves the reseller&apos;s ADSL product details for a specific product ID.</description>
        /// <type>Get</type>
        /// <url>/broadband/products/adsl/{product_id}</url>
        /// <group>Broadband Products</group>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>product_id</field>
        ///     <optional>false</optional>
        ///     <description>Broadband ADSL product ID.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_product</type>
        ///     <field>broadband_product</field>
        ///     <description>broadband_product struct.</description>
        /// </success>
        /// <error>
        ///     <type>InternalApiException</type>   
        /// </error> 
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "id": 153,
        ///     "name": "Home 2GB Capped 20CN 512k",
        ///     "category": "Home ADSL Broadband Products",
        ///     "price": 8.5,
        ///     "fast_track_price": 200,
        ///     "provider": "WBC - 20CN",
        ///     "technology": "ADSL",
        ///     "down_speed": 512,
        ///     "up_speed": 256,
        ///     "peak_cap": 2,
        ///     "off_peak_cap": 100,
        ///     "contention": 50,
        ///     "product_class": "Home",
        ///     "provider_lead_time": 7,
        ///     "migration_lead_time": 7,
        ///     "peak_start": %peak_start%,
        ///     "peak_end": %peak_end%,
        ///     "contract_length": 1,
        ///     "legacy_product": false,
        ///     "requires_out_line_rental": false,
        ///     "unlimeted_cap": false
        /// }
        ///     </content>
        /// </example>
        [HttpGet]
        [ActionName("adsl")]
        public broadband_product Get(int product_id) {
            return GetBroadbandProduct(product_id);
        }

        #endregion

        /// <summary>
        /// Gets a broadband product.
        /// </summary>
        /// <param name="id">Broadband ADSL product ID.</param>
        /// <returns>broadband_product</returns>
        private broadband_product GetBroadbandProduct(int id) {

            broadband_product_results product_results = GetResults<broadband_product_results>("Broadband/broadband_product.json");
            broadband_product product = product_results.broadband_product.FirstOrDefault(x => x.id == id);
            if (product.Equals(default(broadband_product)))
                throw new InternalApiException("Product was not found.");

            return product;
        }

        /// <summary>
        /// Gets broadband products.
        /// </summary>
        /// <returns></returns>
        private broadband_product_results GetBroadbandProducts() {
            
            broadband_product_results product_results = GetResults<broadband_product_results>("Broadband/broadband_product.json");
            return product_results;
        }
    }
}