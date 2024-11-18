using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utils.Enumeration;

namespace API.Core.Broadband {

    /// <summary>
    /// Represents a broadband user.
    /// </summary>
    public class BroadbandUser {

        private int id = 0;
        private string username = "";
        private string realm = "";
        private string password = "";
        private string cli = "";
        private OrderStatus status;
        private bool isClosed;
        private string productName;

        /// <summary>
        /// Initializes a new BroadbandUser object.
        /// </summary>
        public BroadbandUser() {
        }

        /// <summary>
        /// Initialises the broadband user from an existing username.
        /// </summary>
        /// <param name="fullUsername">The existing full username.</param>
        /// <param name="parentAccount">Parent account.</param>
        /// <param name="accountLiveCheck">Throw NotLiveException if order status is not 'Complete'.</param>
        public BroadbandUser(string fullUsername, int parentAccount, bool accountLiveCheck = false) {           
            if(accountLiveCheck && !IsAccountLive())
                throw new NotLiveException("Account is " + EnumTools.GetEnumDescription(Status).ToLower() + ".");
        }

       
        /// <summary>
        /// Checkes the order status and throws an exception if not completed.
        /// </summary>
        /// <returns>True if the order status is complete; otherwise.</returns>
        public bool IsAccountLive() {

            if (status == OrderStatus.COMPLETE) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Username.
        /// </summary>
        public string Username {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Realm.
        /// </summary>
        public string Realm {
            get { return realm; }
            set { realm = value; }
        }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// UserId.
        /// </summary>
        public int UserId {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Status.
        /// </summary>
        public OrderStatus Status {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// IsClosed.
        /// </summary>
        public bool IsClosed {
            get { return isClosed; }
            set { isClosed = value; }
        }

        /// <summary>
        /// CLI.
        /// </summary>
        public string Cli {
            get { return cli; }
            set { cli = value; } 
        }

        /// <summary>
        /// Product name.
        /// </summary>
        public string ProductName {
            get { return productName; }
            set { productName = value; }
        }

    }
}