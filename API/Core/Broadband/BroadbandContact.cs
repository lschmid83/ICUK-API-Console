using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace API.Core.Broadband
{
    /// <summary>
    /// Represents a broadband users contact details.
    /// </summary>
    public class BroadbandContact
    {
        private int id = 0;
        private int userId = 0;
        private string forename = "";
        private string surname = "";
        private string phone = "";
        private string email = "";

        /// <summary>
        /// Initialises an empty contact that can be populated through properties.
        /// </summary>
        public BroadbandContact() { }

        /// <summary>
        /// Initialises the contact from an existing ID.
        /// </summary>
        /// <param name="id">The existing contact ID.</param>
        public BroadbandContact(int id)
        {
        }
    
        /// <summary>
        /// Checks if the mandatory properties have been set and throws an Exception if not.
        /// </summary>
        private void CheckMandatoryPropertiesSet()
        {
            // Check the user ID.
            if (userId == 0)
            {
                throw new Exception("The UserId property must be set before the contact can be added");
            }
        }

        /// <summary>
        /// The Contact ID.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// The user ID.
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// The forename.
        /// </summary>
        public String Forename
        {
            get { return forename; }
            set { forename = value; }
        }

        /// <summary>
        /// The surname.
        /// </summary>
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        /// <summary>
        /// The phone number.
        /// </summary>
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// The email.
        /// </summary>
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Whether the contact ID exists.
        /// </summary>
        public bool Exists
        {
            get { return false; }
        }

    }

}
