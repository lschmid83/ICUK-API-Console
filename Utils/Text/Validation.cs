using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Utils.Text {

    /// <summary>
    /// Provides common string validation routines.
    /// </summary>
    public class Validation {

        /// <summary>
        /// Validates a UK post code.
        /// </summary>
        /// <param name="value">Postcode to check</param>
        /// <returns>bool</returns>
        public static bool ValidPostcode(string value) {
            Regex remove = new Regex(@"\+|\(|\)|\-|\s", RegexOptions.Compiled);
            value = remove.Replace(value, String.Empty);
            return Regex.IsMatch(value, @"^[A-Za-z]{1,2}(\d{1,2}|[I])[A-Za-z]? ?\d[A-Za-z]{2}$");
        }

        /// <summary>
        /// Validates a UK phone number.
        /// </summary>
        /// <param name="value">UK Phone number to check.</param>
        /// <returns>bool</returns>
        public static bool ValidUkPhoneNumber(string value) {
            Regex remove = new Regex(@"\+|\(|\)|\-|\s", RegexOptions.Compiled);
            value = remove.Replace(value, String.Empty);
            return Regex.IsMatch(value, @"^0[0-9]{9,15}$");
        }

        /// <summary>
        /// Validates a RIPE phone number.
        /// </summary>
        /// <param name="value">Phone number to check.</param>
        /// <returns>bool</returns>
        public static bool ValidRipePhoneNumber(string value) {
            return Regex.IsMatch(value, @"^\+[0-9]+$");

        }

        /// <summary>
        /// Validates an SMS number.
        /// </summary>
        /// <param name="value">SMS number to check.</param>
        /// <returns>bool</returns>
        public static bool ValidSmsPhoneNumber(string value) {
            return Regex.IsMatch(value, @"^\+447[0-9]{9}$");
        }

        /// <summary>
        /// Validates an International SMS number.
        /// </summary>
        /// <param name="value">International SMS number to check.</param>
        /// <returns>bool</returns>
        public static bool ValidInternationalSmsPhoneNumber(string value) {
            return Regex.IsMatch(value, @"^\+(999|998|997|996|995|994|993|992|991|990|979|978|977|976|975|974|973|972|971|970|969|968|967|966|965|964|963|962|961|960|899|898|897|896|895|894|893|892|891|890|889|888|887|886|885|884|883|882|881|880|879|878|877|876|875|874|873|872|871|870|859|858|857|856|855|854|853|852|851|850|839|838|837|836|835|834|833|832|831|830|809|808|807|806|805|804|803|802|801|800|699|698|697|696|695|694|693|692|691|690|689|688|687|686|685|684|683|682|681|680|679|678|677|676|675|674|673|672|671|670|599|598|597|596|595|594|593|592|591|590|509|508|507|506|505|504|503|502|501|500|429|428|427|426|425|424|423|422|421|420|389|388| 387|386|385|384|383|382|381|380|379|378|377|376|375|374|373|372|371|370|359|358|357|356|355|354|353|352|351|350|299|298|297|296|295|294|293|292|291|290|289|288|287|286|285|284|283|282|281|280|269|268|267|266|265|264|263| 262|261|260|259|258|257|256|255|254|253|252|251|250|249|248|247|246|245|244|243|242|241|240|239|238|237|236|235|234|233|232|231|230|229|228|227|226|225|224|223|222|221|220|219|218|217|216|215|214|213|212|211|210|98|95|94|93|92|91|90|86|84|82|81|66|65|64|63|62|61|60|58|57|56|55|54|53|52|51|49|48|47|46|45|43|41|40|39|36|34|33|32|31|30|27|20|7|1)[0-9]{8-15}$");
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="value">Email address to check.</param>
        /// <returns>bool</returns>
        public static bool ValidEmailAddress(string value) {
            return Regex.IsMatch(value, @"^[a-zA-Z0-9_\-\.]+@([a-zA-Z0-9_\-]+\.){1,15}[a-zA-Z0-9_\-]{2,64}$");
        }

        /// <summary>
        /// Validates a domain name.
        /// </summary>
        /// <param name="value">Domain to check.</param>
        /// <returns>bool</returns>
        public static bool ValidDomain(string value) {
            return Regex.IsMatch(value, @"^([a-zA-Z0-9_\-]+\.){1,15}[a-zA-Z0-9_\-]{2,64}$");
        }

        /// <summary>
        /// Validates a full URL (e.g. http://www.example.com/path/to/file.extension)
        /// </summary>
        /// <param name="value">URL to check.</param>
        /// <returns>bool</returns>
        public static bool ValidFullURL(string value) {
            return Regex.IsMatch(value, @"^(http:\/\/)?([a-zA-Z0-9_\-]+\.){1,15}[a-zA-Z0-9_\-]{2,6}(\/[a-zA-Z0-9_\-\.]+)*(\/[a-zA-Z0-9_\-%]+\.)[a-zA-Z0-9_\-]+$");
        }

        /// <summary>
        /// Validates an IP address.
        /// </summary>
        /// <param name="value">IP address to check.</param>
        /// <returns>bool</returns>
        public static bool ValidIpAddress(string value) {
            return Regex.IsMatch(value, @"^((25[0-5]|2[0-4][0-9]|[01]|[1-9][0-9]|[1][0-9][0-9]|[2-9]?)\.){3}((25[0-5]|2[0-4][0-9]|[01]|[1-9][0-9]|[1][0-9][0-9]|[2-9]?)){1}$");
        }

        /// <summary>
        /// Validates an Longhand IPv6 address.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidIp6Address(String value) {
            return Regex.IsMatch(value, @"^(?:[a-fA-F0-9]{1,4}:){7}[a-fA-F0-9]{1,4}$");
        }

        /// <summary>
        /// Validates an Shorthand IPv6 address.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidShorthandIp6Address(String value) {
            return Regex.IsMatch(value, @"((?:[0-9A-Fa-f]{1,4}(?::[0-9A-Fa-f]{1,4})*)?)::((?:[0-9A-Fa-f]{1,4}(?::[0-9A-Fa-f]{1,4})*)?)");
        }

        /// <summary>
        /// Validates a DNS hostname for custom DNS including allowing wildcard (*) and sub-domains (sub.dom.ain) and wildcard sub-domains (*.wildcard)/
        /// </summary>
        /// <param name="value">hostname to check</param>
        /// <returns>bool</returns>
        public static bool ValidDNSHostname(string value) {
            return Regex.IsMatch(value, @"^\*$|^(\*\.){0,1}([a-zA-Z0-9_-]+\.)*[a-zA-Z0-9_-]+$");
        }

        /// <summary>
        /// Checks Alpha characters/
        /// </summary>
        /// <returns></returns>
        public static bool ValidAlphaChars(String value) {
            return Regex.IsMatch(value, @"^[a-zA-Z]*$");
        }

        /// <summary>
        /// Checks AlphaNumeric characters.
        /// </summary>
        /// <returns></returns>
        public static bool ValidAlphaNumericChars(String value) {
            return Regex.IsMatch(value, @"^[0-9a-zA-Z]*$");
        }

        /// <summary>
        /// Checks that all characters are numeric in a string.
        /// </summary>
        /// <returns></returns>
        public static bool ValidNumericChars(String value) {
            return Regex.IsMatch(value, @"^[0-9]*$");
        }

        /// <summary>
        /// Checks for alpha numeric characters, and allows spaces.
        /// </summary>
        /// <returns></returns>
        public static bool ValidAlphaNumericCharsWithSpace(String value) {
            return Regex.IsMatch(value, @"^[0-9a-zA-Z\s]*$");
        }

        /// <summary>
        /// Checks for alpha numeric characters, and allows spaces.
        /// </summary>
        /// <returns></returns>
        public static bool ValidEUCountryMember(String countrycode) {

            // Initialize boolean default.
            bool retVal = false;

            // Check if the country supplied is an EU member state.
            if (countrycode == "GB") retVal = true;
            if (countrycode == "AT") retVal = true;
            if (countrycode == "BE") retVal = true;
            if (countrycode == "CY") retVal = true;
            if (countrycode == "CZ") retVal = true;
            if (countrycode == "DK") retVal = true;
            if (countrycode == "EE") retVal = true;
            if (countrycode == "FI") retVal = true;
            if (countrycode == "FR") retVal = true;
            if (countrycode == "DE") retVal = true;
            if (countrycode == "HU") retVal = true;
            if (countrycode == "IE") retVal = true;
            if (countrycode == "IT") retVal = true;
            if (countrycode == "LV") retVal = true;
            if (countrycode == "LT") retVal = true;
            if (countrycode == "LU") retVal = true;
            if (countrycode == "MT") retVal = true;
            if (countrycode == "NL") retVal = true;
            if (countrycode == "PL") retVal = true;
            if (countrycode == "PT") retVal = true;
            if (countrycode == "RO") retVal = true;
            if (countrycode == "SK") retVal = true;
            if (countrycode == "ES") retVal = true;
            if (countrycode == "SE") retVal = true;

            // Return value to to function.
            return retVal;
        }

        /// <summary>
        /// Validates a year.
        /// </summary>
        /// <param name="year">Year to check.</param>
        /// <returns>True if the year is valid; otherwise false.</returns>
        public static bool ValidYear(int year) {

            bool retValue = true;

            if (!Regex.IsMatch(year.ToString(), @"^\d{4}$"))
                retValue = false;

            if (year < 2000 || year > DateTime.Now.Year)
                retValue = false;

            return retValue;
        }

        /// <summary>
        /// Validates a month.
        /// </summary>
        /// <param name="month">Month to check.</param>
        /// <returns>True if the month is valid; otherwise false.</returns>
        public static bool ValidMonth(int month) {

            bool retValue = true;

            if (!Regex.IsMatch(month.ToString(), @"^\d{1,2}$"))
                retValue = false;

            if (month < 1 || month > 12)
                retValue = false;

            return retValue;

        }

        /// <summary>
        /// Validates a password.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>True if the password is valid; otherwise false.</returns>
        public static bool ValidPassword(string password) {

            bool valid = true;
            if (password.Length < 7) { valid = false; }
            valid = Regex.IsMatch(password, @"^[a-zA-Z0-9\!\""\£\$\%\^\&\*\(\)_\-\=\{\}\[\]\;\'\#\:\@\~\,\.\/\<\>\?]+$");

            return valid;
        }
    }
}
