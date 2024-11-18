using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace API.Core {
    /// <summary>
    /// Provides the default control panel database functions.
    /// </summary>
    public class Database {

        private static string devConnString = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=icuk_api;Persist Security Info=True;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD";
        
        /// <summary>
        /// Returns an open database connection.
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection Open() {

            SqlConnection conn = new SqlConnection(devConnString);

            try
            {
                conn.Open();
            }
            catch { }

            return conn;
        }

        /// <summary>
        /// Executes a given SQL string on the database.
        /// </summary>
        /// <param name="sqlString">SQL string.</param>
        public static void Execute(string sqlString) {

            // Open DB Connection.
            SqlConnection sqlConn = Database.Open();

            // Create SQL Command Object.
            SqlCommand sqlCmd = new SqlCommand(sqlString, sqlConn);

            // Try to execute SQL.
            try
            {
                sqlCmd.ExecuteNonQuery();
            }

            // Print any SQL errors.
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            // Close SQL Connection.
            finally
            {
                try
                {
                    sqlConn.Close();
                }
                catch { }
            }
        }

    }

}
