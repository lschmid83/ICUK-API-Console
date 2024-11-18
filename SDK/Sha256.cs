using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.SDK {

    internal class Sha256 {
        /// <summary>
        /// Returns Sha256 hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
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
