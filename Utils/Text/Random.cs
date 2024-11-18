using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Utils.Text {

    /// <summary>
    /// Random number and string generating routines
    /// </summary>
    public class Random
    {

        // Use a single System.Random object for generating the random numbers to ensure uniqueness throughout calls
        private static System.Random r = new System.Random();

        /// <summary>
        /// Returns an alphanumeric string of the supplied length
        /// </summary>
        /// <param name="length">int</param>
        /// <returns>string</returns>
        public static string RandomAlphanumericString(int length)
        {
            string[] c = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return RandomAlphanumericString(length, c);
        }

        /// <summary>
        /// Returns an alphanumeric string of the supplied length from the supplied list of characters
        /// </summary>
        /// <param name="length">int</param>
        /// <param name="c">String of characters to match</param>
        /// <returns>string</returns>
        public static string RandomAlphanumericString(int length, string[] c)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 1; i <= length; i++)
            {
                s.Append(c[r.Next(0, c.Count())]);
            }

            return s.ToString();
        }

    }

}
