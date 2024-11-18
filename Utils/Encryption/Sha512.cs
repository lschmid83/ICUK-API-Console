using System;
using System.Security.Cryptography;

namespace Utils.Encryption {

    /// <summary>
    /// SHA-512 algorithm.
    /// </summary>
    public class Sha512 {

        /// <summary>
        /// Returns Sha512 hash.
        /// </summary>
        /// <param name="plainText">Plain text.</param>
        /// <returns>SHA-512 hash.</returns>
        public static String Hash(String plainText) {

            byte[] hashBytes;
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(plainText);

            SHA512Managed sha512 = new SHA512Managed();

            // Hash the string.
            hashBytes = sha512.ComputeHash(textBytes);

            // Return string.
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
