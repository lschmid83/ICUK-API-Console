using System;
using System.Security.Cryptography;

namespace Utils.Encryption {

    /// <summary>
    /// SHA-256 algorithm.
    /// </summary>
    public class Sha256 {

        /// <summary>
        /// Returns Sha256 hash
        /// </summary>
        /// <param name="plainText">Plain text.</param>
        /// <returns>SHA-256 hash.</returns>
        public static String Hash(String plainText) {

            byte[] hashBytes;
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(plainText);

            SHA256Managed sha256 = new SHA256Managed();
            // Hash the string
            hashBytes = sha256.ComputeHash(textBytes);
            // return string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
