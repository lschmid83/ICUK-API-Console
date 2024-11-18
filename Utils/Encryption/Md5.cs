using System;
using System.Security.Cryptography;

namespace Utils.Encryption {

    /// <summary>
    /// Encrypts string using MD5.
    /// </summary>
    public class Md5 {

        /// <summary>
        /// Returns MD5 hash.
        /// </summary>
        /// <param name="plainText">Input string.</param>
        /// <returns>MD5 hash.</returns>
        public static string Hash(string plainText)
        {
            byte[] hashBytes;
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(plainText);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           
            // Hash the string.
            hashBytes = md5.ComputeHash(textBytes);
            
            // Return string.
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
