using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.SDK {

    internal class Sha512 {
        /// <summary>
        /// Returns Sha512 hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static String Hash(String plainText) {
            byte[] hashBytes;
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(plainText);

            SHA512Managed sha512 = new SHA512Managed();
            // Hash the string
            hashBytes = sha512.ComputeHash(textBytes);
            // return string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
