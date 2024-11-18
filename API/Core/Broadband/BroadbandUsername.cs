using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Utils.Text;

namespace API.Core.Broadband {

    /// <summary>
    /// Represents a broadband account username.
    /// </summary>
    public class BroadbandUsername {

        /// <summary>
        /// Username.
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Realm.
        /// </summary>
        public string Realm { get; set; }
        /// <summary>
        /// Username with realm.
        /// </summary>
        public string FullUsername { get; set; }

        /// <summary>
        /// Initializes a broadband username.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        public BroadbandUsername(string fullUsername) {

            string username, realm;
            try {
                username = fullUsername.Split('@')[0];
                realm =  fullUsername.Split('@')[1];
            }
            catch (Exception) {
                throw new InvalidParameterException("Invalid username supplied.");
            }

            if (String.IsNullOrEmpty(username)) {
                throw new InvalidParameterException("No username supplied.");
            }
            else if (String.IsNullOrEmpty(realm)) {
                throw new InvalidParameterException("No realm supplied.");
            }
            else if (!Regex.IsMatch(username, "^[a-zA-Z0-9\\-\\.]+$")) {
                throw new InvalidParameterException("Invalid username supplied.");
            }
            else if (username.Length < 2 || username.Length > 128) {
                throw new InvalidParameterException("The username must be between 2 and 128 characters in length.");
            }
            else if (!Validation.ValidDomain(realm)) {
                throw new InvalidParameterException("Invalid realm supplied.");
            }
            
            User = username;
            Realm = realm;
            FullUsername = fullUsername;
        }
    }
}