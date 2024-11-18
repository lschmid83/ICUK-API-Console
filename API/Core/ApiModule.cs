using API.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Core {

    /// <summary>
    /// Retrieves API module information from the database.
    /// </summary>
    public class ApiModule {

        /// <summary>
        /// ModuleID.
        /// </summary>
        public int ModuleID { get; set; }
        /// <summary>
        /// Module name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Module description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Get all modules from database.
        /// </summary>
        /// <returns></returns>
        public static List<ApiModule> GetApiModules()
        {
            List<ApiModule> modules = new List<ApiModule>();

            // Create connection.
            SqlConnection sqlConn = Database.Open();

            // Set query.
            string sqlQuery = "SELECT * FROM icuk_api.dbo.Tbl_Module";

            // SQL Command.
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);

            // Reader.
            SqlDataReader sqlReader = null;

            try {

                sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) {

                    // Read from the table.
                    modules.Add(new ApiModule() { ModuleID = Convert.ToInt32(sqlReader["Module_ID"]), Name = sqlReader["Module_Name"].ToString(), Description = sqlReader["Module_Description"].ToString() });

                }
            }
            catch (Exception) {
            }
            finally {

                if (sqlReader != null) {
                    try { sqlReader.Close(); }
                    catch { }
                }
                try { sqlConn.Close(); }
                catch { }
            }
                      
            return modules;
        }


        /// <summary>
        /// Gets module documentation dropdown menu.
        /// </summary>
        /// <returns>List of modules the API user has permission to access.</returns>
        public static string GetModuleDropDown() {

            StringBuilder html = new StringBuilder();

            html.AppendLine("<ul class='dropdown-menu'>");

            List<ApiModule> modules = ApiModule.GetApiModules();

            if (HttpContext.Current.Items.Contains("ApiUser")) {
                foreach(ApiModule module in modules) {
                    html.AppendLine("<li><a href='/docs/" + module.Name.ToLower() + "'>" + module.Name + "</a></li>");
                }
            }

            html.AppendLine("</ul>");
            return html.ToString();

        }


        /// <summary>
        /// Gets module documentation side menu.
        /// </summary>
        /// <returns>List of modules the API user has permission to access.</returns>
        public static string GetModuleMenu() {


            StringBuilder html = new StringBuilder();

            html.AppendLine("<ul class='nav nav-list tree active-trial'>");

            List<ApiModule> modules = ApiModule.GetApiModules();

            if (HttpContext.Current.Items.Contains("ApiUser")) {
                foreach (ApiModule module in modules) {
                    html.AppendLine("<li><a class='no-scroll' href='/docs/" + module.Name.ToLower() + "'>" + module.Name + "</a></li>");
                }
            }

            html.AppendLine("</ul>");
            return html.ToString();

        }

    }
}