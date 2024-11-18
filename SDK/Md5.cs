using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.SDK {

    internal class Md5 {
        /// <summary>
        /// Returns MD5 hash.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Hash(string plainText) {
            byte[] hashBytes;
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(plainText);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // Hash the string
            hashBytes = md5.ComputeHash(textBytes);
            // return string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
