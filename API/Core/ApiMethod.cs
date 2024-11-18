using API.Controllers;
using API.Core.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Core {
    
    /// <summary>
    /// Retrieves API method information from the database.
    /// </summary>
    public class ApiMethod {

        /// <summary>
        /// Method name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Method description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Module name.
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// Controller the method belongs to.
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Http method.
        /// </summary>
        public string HttpMethod { get; set; }
        /// <summary>
        /// Method URL.
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Get module methods from the database.
        /// </summary>
        /// <param name="apiUser">API user.</param>
        /// <param name="module">API module.</param>
        /// <returns>List of ApiMethod objects.</returns>
        public static List<ApiMethod> GetModuleMethods(int apiUser, ApiModule module) {

            List<ApiMethod> methods = new List<ApiMethod>();
            
            // Create connection.
            SqlConnection sqlConn = Database.Open();

            // Set query.
            string sqlQuery = @"
                SELECT DISTINCT mod.Module_Name, con.Controller_Name, met.Method_Name, met.Method_Description, met.Http_Method, met.Url, met.User_Type_Permissions
                FROM icuk_api.dbo.Tbl_Module mod,
                     icuk_api.dbo.Tbl_Method met,
                     icuk_api.dbo.Tbl_Controller con
                WHERE 
	                 met.Module_ID = @Module_ID AND
                     mod.Module_ID = met.Module_ID AND
	                 met.Controller_ID = con.Controller_ID";

            // SQL Command.
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);

            // Add parameters.
            sqlCmd.Parameters.Add("Module_ID", SqlDbType.Int).Value = module.ModuleID;

            // Reader.
            SqlDataReader sqlReader = null;


            try {

                sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) {

                    // Read from the table.
                    string httpMethod = sqlReader["Http_Method"].ToString();
                    int methodPermissions = Convert.ToInt32(sqlReader["User_Type_Permissions"]);
                    string moduleName = sqlReader["Module_Name"].ToString();
                    ApiMethod method = new ApiMethod() {
                        Module = sqlReader["Module_Name"].ToString(),
                        Controller = sqlReader["Controller_Name"].ToString(),
                        Name = sqlReader["Method_Name"].ToString(),
                        Description = sqlReader["Method_Description"].ToString(),
                        HttpMethod = sqlReader["Http_Method"].ToString(),
                        Url = sqlReader["Url"].ToString()
                    };
                    methods.Add(method);
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

            return methods;
        }
        
        /// <summary>
        /// Search for module methods in the database.
        /// </summary>
        /// <param name="apiUser">API user.</param>
        /// <param name="methodUrl">Method URL to searach for.</param> 
        /// <returns>List of ApiMethod objects.</returns>
        public static List<ApiMethod> SearchModuleMethods(int apiUser, string methodUrl) {

            List<ApiMethod> methods = new List<ApiMethod>();

            // Create connection.
            SqlConnection sqlConn = Database.Open();

            // Set query.
            string sqlQuery = @"
                SELECT DISTINCT mod.Module_Name, con.Controller_Name, met.Method_Name, met.Method_Description, met.Http_Method, met.Url, met.User_Type_Permissions
                FROM icuk_api.dbo.Tbl_Module mod, 
                     icuk_api.dbo.Tbl_Method met,   
                     icuk_api.dbo.Tbl_Controller con
                WHERE 
	                 met.Url LIKE " + "'%" + methodUrl + @"%' AND
                     met.Module_ID = mod.Module_ID AND
	                 met.Controller_ID = con.Controller_ID";

            // SQL Command.
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);

            // Reader.
            SqlDataReader sqlReader = null;

            try {

                sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) {

                    // Read from the table.
                    int methodPermissions = Convert.ToInt32(sqlReader["User_Type_Permissions"]);
                    string httpMethod = sqlReader["Http_Method"].ToString();
                    string moduleName = sqlReader["Module_Name"].ToString();
                    ApiMethod method = new ApiMethod() {
                        Module = sqlReader["Module_Name"].ToString(),
                        Controller = sqlReader["Controller_Name"].ToString(),
                        Name = sqlReader["Method_Name"].ToString(),
                        Description = sqlReader["Method_Description"].ToString(),
                        HttpMethod = sqlReader["Http_Method"].ToString(),
                        Url = sqlReader["Url"].ToString()
                    };

                    methods.Add(method);
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


            return methods;
        }

    }
}