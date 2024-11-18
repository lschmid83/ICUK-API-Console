using API.Controllers;
using API.Core;
using Newtonsoft.Json.Converters;
using System.Web.Http;

namespace API {

    /// <summary>
    /// Route configuration for the Web API.
    /// </summary>
    public static class WebApiConfig {

        /// <summary>
        /// Routes HTTP requests to controller.
        /// </summary>
        public static void Register(HttpConfiguration config) {
            
            // Handlers
            config.MessageHandlers.Add(new LoggingHandler());
            config.MessageHandlers.Add(new HostHandler());

            // Serialize enum to name string value
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            // Serialize datetime fields in ISO 8601 format
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            
            // Serialize all struct properties and ignore [DataMember(IsRequired = true)] attribute
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new JsonSerializerContract();

            // Do not use the default serializer for XML as it sets the root elements to ArrayOfObject rather than the real object name
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // Filter all errors thrown by methods 
            GlobalConfiguration.Configuration.Filters.Add(new ApiExceptionFilterAttribute());

            #region Broadband API

            config.Routes.MapHttpRoute(
                name: "BroadbandUser_View_Create_Delete",
                routeTemplate: "broadband/user/{username}",
                defaults: new {
                    controller = "BroadbandUser",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "BroadbandUserCease_Create",
                routeTemplate: "broadband/user/cease/{username}",
                defaults: new {
                    controller = "BroadbandUser",
                    username = RouteParameter.Optional
                }
            );
                    
            config.Routes.MapHttpRoute(
                name: "BroadbandAccount_View_Create_Delete",
                routeTemplate: "broadband/account/{accountname}",
                defaults: new {
                    controller = "BroadbandAccount",
                    accountname = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "BroadbandAccount_Map",
                routeTemplate: "broadband/account/{domain}/{username}",
                defaults: new {
                    controller = "BroadbandAccount",
                    domain = RouteParameter.Optional,
                    username = RouteParameter.Optional
                }
            );
            
            config.Routes.MapHttpRoute(
                name: "BroadbandAvailability_CLI_or_Postcode",
                routeTemplate: "broadband/availability/{cli_or_postcode}",
                defaults: new {
                    controller = "BroadbandAvailability",
                    cli_or_postcode = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "BroadbandAvailability_Exact_Address",
                routeTemplate: "broadband/availability/",
                defaults: new {
                    controller = "BroadbandAvailability",
                }
            );

            config.Routes.MapHttpRoute(
                name: "BroadbandAddress_Postcode_Search",
                routeTemplate: "broadband/address_search/{postcode}",
                defaults: new {
                    controller = "BroadbandAddress",
                    postcode = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_OnlineStatus",
                routeTemplate: "broadband/online_status",
                defaults: new {
                    controller = "BroadbandStatus",
                    username = RouteParameter.Optional,
                     
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_OnlineStatus_Singleuser",
                routeTemplate: "broadband/online_status/{username}",
                defaults: new {
                    controller = "BroadbandStatus",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_AuthenticationLog",
                routeTemplate: "broadband/authentication_logs/{username}",
                defaults: new {
                    controller = "BroadbandAuthentication",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_SessionHistory",
                routeTemplate: "broadband/session_history/{username}",
                defaults: new {
                    controller = "BroadbandSession",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_UserPassword_View_Update",
                routeTemplate: "broadband/user/password/{username}",
                defaults: new {
                    controller = "BroadbandPassword",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_UserContact_View_Update",
                routeTemplate: "broadband/user/contact/{username}",
                defaults: new {
                    controller = "BroadbandContact",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferDaily_View",
                routeTemplate: "broadband/data_transfer/daily/{username}",
                defaults: new
                {
                    action = "Daily",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferDaily_View_YearMonth",
                routeTemplate: "broadband/data_transfer/daily/{username}/{year}/{month}",
                defaults: new
                {
                    action = "Daily",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional,
                    year = RouteParameter.Optional,
                    month = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferHourly_View_User",
                routeTemplate: "broadband/data_transfer/hourly/{username}",
                defaults: new {
                    action = "Hourly",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional,
                }
            );
            
            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferHourly_View_UserYearMonthDay",
                routeTemplate: "broadband/data_transfer/hourly/{username}/{year}/{month}/{day}",
                defaults: new {
                    action = "Hourly",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional,
                    year = RouteParameter.Optional,
                    month = RouteParameter.Optional,
                    day = RouteParameter.Optional,
                }
            );
            
            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferMonthly_View",
                routeTemplate: "broadband/data_transfer/monthly/{username}",
                defaults: new {
                    action = "Monthly",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional
                }
            );
    
            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferMonthly_View_YearMonth",
                routeTemplate: "broadband/data_transfer/monthly/{year}/{month}",
                defaults: new {
                    action = "Monthly",
                    controller = "BroadbandDataTransfer",
                    year = RouteParameter.Optional,
                    month = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_DataTransferMonthly_View_UserYearMonth",
                routeTemplate: "broadband/data_transfer/monthly/{username}/{year}/{month}",
                defaults: new {
                    action = "Monthly",
                    controller = "BroadbandDataTransfer",
                    username = RouteParameter.Optional,
                    year = RouteParameter.Optional,
                    month = RouteParameter.Optional,
                }
            );
           
            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandRipePerson_Create_View_Update_Delete",
                routeTemplate: "broadband/ripe/person/{ripe_nic_handle}",
                defaults: new {
                    controller = "BroadbandRipePerson",
                    ripe_nic_handle = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandIp_View",
                routeTemplate: "broadband/ip/{username}",
                defaults: new {
                    controller = "BroadbandIp",
                    ripe_nic_handle = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandIp_Static_Create_Delete",
                routeTemplate: "broadband/ip/{action}/{username}",
                defaults: new {
                    controller = "BroadbandIp",
                    username = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandIp_Routed_Create_Delete",
                routeTemplate: "broadband/ip/{action}/{username}",
                defaults: new {
                    controller = "BroadbandIp",
                    username = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandIp_Ipv6_Create_Delete",
                routeTemplate: "broadband/ipv6/{username}",
                defaults: new {
                    controller = "BroadbandIpv6",
                    username = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandProduct_View",
                routeTemplate: "broadband/products/",
                defaults: new {
                    controller = "BroadbandProduct"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandProductAdsl_View",
                routeTemplate: "broadband/products/{action}/{product_id}",
                defaults: new {
                    controller = "BroadbandProduct",
                    product_id = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_Create_Migrate",
                routeTemplate: "broadband/order/migrate",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "MigrateOrder"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_Create_Provide",
                routeTemplate: "broadband/order/provide",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "ProvideOrder"
                }
            );
            
            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_Create_Cease",
                routeTemplate: "broadband/order/cease/{username}",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "CeaseOrder",
                    username = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_View_Summary",
                routeTemplate: "broadband/order/",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "OrderSummary"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_View",
                routeTemplate: "broadband/order/{order_id}",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "OrderDetails",
                    order_id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_View_Type_Status",
                routeTemplate: "broadband/order/{order_type}/{order_status}",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "SearchOrderSummary",
                    order_type = RouteParameter.Optional,
                    order_status = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_View_Summary_Date",
                routeTemplate: "broadband/order/updates/{start_date}/{end_date}",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "OrderUpdatesDateRange",
                    start_date = RouteParameter.Optional,
                    end_date = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "Broadband_BroadbandOrder_View_Summary_OrderId_Date",
                routeTemplate: "broadband/order/updates/{order_id}/{start_date}/{end_date}",
                defaults: new {
                    controller = "BroadbandOrder",
                    action = "OrderIdUpdatesDateRange",
                    order_id = RouteParameter.Optional,
                    start_date = RouteParameter.Optional,
                    end_date = RouteParameter.Optional,
                }
            );
                        
            #endregion
                       
        }
   
    }

}
