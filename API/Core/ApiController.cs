using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Core {

    /// <summary>
    /// Retrieves API controller information from the database.
    /// </summary>
    public class ApiController {

        /// <summary>
        /// ControllerID.
        /// </summary>
        public int ControllerID { get; set; }
        /// <summary>
        /// Controller name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get all controllers from database.
        /// </summary>
        /// <returns></returns>
        public static List<ApiController> GetApiControllers() {

            List<ApiController> controllers = new List<ApiController>();

            // Create connection.
            SqlConnection sqlConn = Database.Open();

            // Set query.
            string sqlQuery = "SELECT * FROM icuk_api.dbo.Tbl_Controller";

            // SQL Command.
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);

            // Reader
            SqlDataReader sqlReader = null;

            try {

                sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) {

                    // Read from the table.
                    controllers.Add(new ApiController() { ControllerID = Convert.ToInt32(sqlReader["Controller_ID"]), Name = sqlReader["Controller_Name"].ToString() });

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
 
            return controllers;
        }
    }
}