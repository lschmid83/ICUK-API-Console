using API.Core;
using API.Core.XmlComments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace API {
    
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Entry point for the Web API application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication {

        public static string DataFolder = @"C:\Users\User\Documents\GitHub\ICUK-API-Console\API\Data\";

        /// <summary>
        /// Makes configuration changes to the Web API.
        /// </summary>
        protected void Application_Start() {

            // Register Web API route paths.
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Build the API documentation using reflection to extract code comments
            ApiDoc apiDoc = new ApiDoc();
            apiDoc.BuildDocumentation();

            // Read in the API module documentation once on startup to save overhead
            Application.Add("API_Modules", ReadModuleObjects());
            Application.Add("API_Modules_JSON", ReadModuleJson());

            // Read in the template files once on startup to save overhead
            Application.Add("ICUK_Template", ReadFile("Views/template.htm"));
            Application.Add("ICUK_API_Doc", ReadFile("Views/documentation.htm"));
            
            // Store the API server IP Address
            Application.Add("MachineIPAddress", MachineIPAddress());
        }

        /// <summary>
        /// Obtains the Machine's IP Address
        /// </summary>
        /// <returns></returns>
        private string MachineIPAddress() {

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }
                
        /// <summary>
        /// Attempts to read the contents of the supplied file from the physical drive path of the application.
        /// </summary>
        /// <param name="file">The name of the file to read.</param>
        /// <returns>String containing the file contents.</returns>
        private string ReadFile(string file) {
            try {

                string path = HttpRuntime.AppDomainAppPath + "\\" + file;

                StreamReader streamReader = new StreamReader(path);
                String templateString = streamReader.ReadToEnd();
                streamReader.Close();

                return templateString;
            }
            catch (Exception) {
                return "";
            }
        }

        /// <summary>
        /// Reads API module documentation in JSON format.
        /// </summary>
        /// <returns>Dictionary of module names and JSON module documentation in ApiDocJs format.</returns>
        public Dictionary<string, string> ReadModuleJson() {

            Dictionary<string, string> modules = new Dictionary<string, string>();

            List<ApiModule> apiModules = ApiModule.GetApiModules();
            foreach (ApiModule module in apiModules) {

                string json = File.ReadAllText(HttpRuntime.AppDomainAppPath + "javascript\\docs\\" + module.Name.ToLower() + ".js");
                modules.Add(module.Name, json);
            }
            return modules;

        }
        
        /// <summary>
        /// Deserializes API module documentation in JSON format to XmlModuleComment objects.
        /// </summary>
        /// <returns>Dictionary of module names and XmlModuleComment objects.</returns>
        public Dictionary<string, XmlModuleComment> ReadModuleObjects() {

            Dictionary<string, XmlModuleComment> modules = new Dictionary<string, XmlModuleComment>();
                        
            List<ApiModule> apiModules = ApiModule.GetApiModules();
            foreach (ApiModule module in apiModules) {

                string json = File.ReadAllText(HttpRuntime.AppDomainAppPath + "javascript\\docs\\" + module.Name.ToLower() + ".js");                      
                modules.Add(module.Name, XmlModuleComment.DeserializeJson(json));
            }
            return modules;
        }
    }
}
