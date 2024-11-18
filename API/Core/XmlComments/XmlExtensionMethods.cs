using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Extension methods for XmlComments.
    /// </summary>
    public static class XmlExtensionMethods {

        /// <summary>
        /// Converts a boolean variable to a lowercase string.
        /// </summary>
        /// <param name="b">Boolean</param>
        /// <returns>Boolean value converted to lowercase string.</returns>
        public static string ToLower(this bool b) {
            return b.ToString().ToLower();
        }

        /// <summary>
        /// Determines whether a string represents a boolean value.
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>True if the string is a boolean value; otherwise false.</returns>
        public static bool IsValidBool(this string s) {

            try {
                return Boolean.Parse(s);
            }
            catch (Exception) {
                return false;
            }
        }
        
        /// <summary>
        /// Encodes a JSON string field.
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>JSON string.</returns>
        public static string ToJsonString(this string s) {

            return "\"" + s + "\"";
        }

    }
}