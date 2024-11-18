using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Core {

    /// <summary>
    /// Converts ceconds to string showing, days, hours, minutes, seconds.
    /// </summary>
    public class SecondsMagnitudeConverter {

        private Int32 seconds;

        /// <summary>
        /// Initializes a new SecondsMagnitudeConverter object.
        /// </summary>
        /// <param name="seconds">Seconds.</param>
        public SecondsMagnitudeConverter(Int32 seconds) {
            this.seconds = seconds;
        }

        /// <summary>
        /// Converts the numeric instance to a string representation.
        /// </summary>
        /// <returns>String representation showing, days, hours, minutes, seconds.</returns>
        public override String ToString() {

            StringBuilder html = new StringBuilder();
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            String s;

            if (timeSpan.Days > 0)
            {
                s = timeSpan.Days == 1 ? "" : "s";
                html.Append(timeSpan.Days + " day" + s + " ");
            }
            if (timeSpan.Hours > 0 | html.Length > 0)
            {
                s = timeSpan.Hours == 1 ? "" : "s";
                html.Append(timeSpan.Hours + " hour" + s + " ");
            }
            if (timeSpan.Minutes > 0 | html.Length > 0)
            {
                s = timeSpan.Minutes == 1 ? "" : "s";
                html.Append(timeSpan.Minutes + " minute" + s + " ");
            }
            if (timeSpan.Seconds > 0 | html.Length > 0)
            {
                s = timeSpan.Seconds == 1 ? "" : "s";
                html.Append(timeSpan.Seconds + " second" + s + " ");
            }

            // Return the string.
            if (html.Length > 0)
            {
                return html.ToString(0, html.Length - 1);
            }
            else
            {
                return "";
            }
        }
    }
}
