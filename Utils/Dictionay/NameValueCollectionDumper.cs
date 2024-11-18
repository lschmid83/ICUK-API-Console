using System;
using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;


namespace ControlPanel.Utils {

    /// <summary>
    /// Dumps the supplied NameValueCollection to a line delimited 'key: value' string
    /// </summary>
    public class NameValueCollectionDumper {

        /// <summary>
        /// Uses the default Windows line termination characters, CRLF
        /// </summary>
        /// <param name="collection">The collection to dump</param>
        /// <returns></returns>
        public static string DumpNameValueCollection(NameValueCollection collection) {
            string dump = "";

            foreach (string key in collection.Keys) {
                dump += key + "\t\t" + collection[key] + "\r\n";
            }

            return dump;
        }

        /// <summary>
        /// Uses the supplied characters to terminate lines
        /// </summary>
        /// <param name="collection">The collection to dump</param>
        /// <param name="lineTermChars">
        /// Custom line termination characters
        /// i.e. <br/> | \r\n | \n
        /// </param>
        /// <returns></returns>
        public static string DumpNameValueCollection(NameValueCollection collection, string lineTermChars) {
            string dump = "";

            foreach (string key in collection.Keys) {
                dump += key + "\t\t" + collection[key] + lineTermChars;
            }

            return dump;
        }
    
    }

}
