using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Numerics;

namespace API.Core {

    /// <summary>
    /// Calculates properties of IP addresses.
    /// </summary>
    public class IpPropertyCalculator {

        BigInteger ipInteger;
        BigInteger ipRangeInteger;
        BigInteger broadcastInteger;
        BigInteger networkInteger;
        BigInteger ipNetMaskInteger;

        String broadcastAddress;
        String networkAddress;
        String address;
        String ipNetMask;
        Int32 prefix = -1;
        
        /// <summary>
        /// IP address.
        /// </summary>
        public String Address {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Address Integer.
        /// </summary>
        public BigInteger AddressInteger {
            get { return ipInteger; }
        }

        /// <summary>
        /// IP prefix.
        /// </summary>
        public Int32 Prefix {
            get { return prefix; }
            set { prefix = value; }
        }

        /// <summary>
        /// Calculates IP address properties.
        /// </summary>
        public void Calculate() {

            IpVersion ipVersion = IpVersion.V4;
            BigInteger two = new BigInteger(2);

            // Check if IPv6.
            if (address.IndexOf(":") != -1)
            {
                ipVersion = IpVersion.V6;

                // Default to single IP.
                if (prefix == -1)
                {
                    prefix = 128;
                }
            }
            else
            {
                if (prefix == -1)
                {
                    prefix = 32;
                }
            }

            // Calculate IP values.
            if (ipVersion == IpVersion.V4)
            {
                Int64 networkV4Integer;
                Int64 broadcastV4Integer;
                
                // Get range of numbers.
                Int64 ipV4RangeInteger = (Int64)(Math.Pow(2, 32 - ((int)prefix)));
                String[] addressSplit = address.Split('.');

                // Retrieve Netmask.
                Int64 ipV4NetMaskInteger = (Int64)Math.Pow(2, 32) - ipV4RangeInteger;

                // Calculate IP integer.
                Int64 ipV4Integer = Convert.ToInt64(addressSplit[0]) * Convert.ToInt64(Math.Pow(2, 8 * 3))
                                  + Convert.ToInt64(addressSplit[1]) * Convert.ToInt64(Math.Pow(2, 8 * 2))
                                  + Convert.ToInt64(addressSplit[2]) * Convert.ToInt64(Math.Pow(2, 8 * 1))
                                  + Convert.ToInt64(addressSplit[3]) * Convert.ToInt64(Math.Pow(2, 8 * 0));

                // Calculate network and broadcast address integer.
                networkV4Integer = (ipV4Integer / ipV4RangeInteger) * ipV4RangeInteger;
                broadcastV4Integer = networkV4Integer + ipV4RangeInteger - 1;

                // Set global values.
                ipNetMaskInteger = new BigInteger(ipV4NetMaskInteger);
                ipInteger = new BigInteger(ipV4Integer);
                networkInteger = new BigInteger(networkV4Integer);
                broadcastInteger = new BigInteger(broadcastV4Integer);
                ipRangeInteger = new BigInteger(ipV4RangeInteger);

                ipNetMask = ConvertIpV4IntToString(ipV4NetMaskInteger);
                networkAddress = ConvertIpV4IntToString(networkV4Integer);
                broadcastAddress = ConvertIpV4IntToString(broadcastV4Integer);

            }
            else
            {

                ipRangeInteger = BigInteger.Pow(two, 128 - ((int)prefix));
                String[] addressSplit = address.Split(':');
                String insert = "";

                // Check if short hand address supplied.
                if (addressSplit.GetUpperBound(0) < 7)
                {

                    // add extra seperators
                    for (Int32 i = addressSplit.GetUpperBound(0); i <= 8; i++)
                    {
                        insert += ":0000";
                    }
                    address = address.Replace("::", insert);

                    // Split address into array.
                    addressSplit = address.Split(':');

                    // Add leading zeros.
                    for (Int32 i = 0; i < 8; i++)
                    {
                        // Ensure that each segment has four digits.
                        while (addressSplit[i].Length < 4)
                        {

                            addressSplit[i] = "0" + addressSplit[i];

                        }
                    }
                }

                // Retrieve Netmask.
                ipNetMaskInteger = BigInteger.Pow(two, 128) - ipRangeInteger;

                // Calculate IP integer.
                // Split address up and assign each section a integer and sum all values.  
                ipInteger = new BigInteger(Int32.Parse(addressSplit[0], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 7)
                          + new BigInteger(Int32.Parse(addressSplit[1], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 6)
                          + new BigInteger(Int32.Parse(addressSplit[2], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 5)
                          + new BigInteger(Int32.Parse(addressSplit[3], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 4)
                          + new BigInteger(Int32.Parse(addressSplit[4], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 3)
                          + new BigInteger(Int32.Parse(addressSplit[5], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 2)
                          + new BigInteger(Int32.Parse(addressSplit[6], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 1)
                          + new BigInteger(Int32.Parse(addressSplit[7], System.Globalization.NumberStyles.HexNumber)) * BigInteger.Pow(two, 16 * 0);

                // Calculate network address integer.
                networkInteger = (ipInteger / ipRangeInteger) * ipRangeInteger;
                broadcastInteger = networkInteger + ipRangeInteger - new BigInteger(1);

                ipNetMask = ConvertIpV6IntToString(ipNetMaskInteger);
                networkAddress = ConvertIpV6IntToString(networkInteger);
                broadcastAddress = ConvertIpV6IntToString(broadcastInteger);

            }

        }

        /// <summary>
        /// ConvertIpV4 integer number to string.
        /// </summary>
        /// <param name="ipv4Integer">IPv4 integer address.</param>
        /// <returns>IPv4 address.</returns>
        public static String ConvertIpV4IntToString(Int64 ipv4Integer) {

            Int64 ipv4Int = (Int64)ipv4Integer;
            
            // Convert back to standard notation.
            Int64 octet1 = ipv4Int / (Int64)Math.Pow(2, 8 * 3);
            Int64 octet2 = ipv4Int % (Int64)Math.Pow(2, 8 * 3) / (Int64)Math.Pow(2, 8 * 2);
            Int64 octet3 = ipv4Int % (Int64)Math.Pow(2, 8 * 2) / (Int64)Math.Pow(2, 8 * 1);
            Int64 octet4 = ipv4Int % (Int64)Math.Pow(2, 8 * 1) / (Int64)Math.Pow(2, 8 * 0);

            return octet1 + "." + octet2 + "." + octet3 + "." + octet4;
        }

        /// <summary>
        /// Convert IpV6 integer number to string.
        /// </summary>
        /// <param name="ipv6Int">IPv6 integer address.</param>
        /// <returns>IPv6 address.</returns>
        public static String ConvertIpV6IntToString(BigInteger ipv6Int) {

            BigInteger two = new BigInteger(2);
            BigInteger remainder = ipv6Int;

            // Convert back to standard notation (by dividing the integer in blocks and workingout remainder).
            Int64 quadHex1 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 7), out remainder));
            Int64 quadHex2 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 6), out remainder));
            Int64 quadHex3 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 5), out remainder));
            Int64 quadHex4 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 4), out remainder));
            Int64 quadHex5 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 3), out remainder));
            Int64 quadHex6 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 2), out remainder));
            Int64 quadHex7 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 1), out remainder));
            Int64 quadHex8 = (Int64)(BigInteger.DivRem(remainder, BigInteger.Pow(two, 16 * 0), out remainder));

            return ConvertToHexadecimal(quadHex1) + ":" + ConvertToHexadecimal(quadHex2) + ":" + ConvertToHexadecimal(quadHex3) + ":" + ConvertToHexadecimal(quadHex4) + ":" + ConvertToHexadecimal(quadHex5) + ":" + ConvertToHexadecimal(quadHex6) + ":" + ConvertToHexadecimal(quadHex7) + ":" + ConvertToHexadecimal(quadHex8);
        }

        /// <summary>
        /// Convert either IpV4 OR IpV6 integer number to string. Anything less than 4294967296 will be treated as a IPv4.
        /// </summary>
        /// <param name="ipInt">Integer IP address.</param>
        /// <returns>IP address.</returns>
        public static String ConvertIpIntToString(BigInteger ipInt) {

            if (ipInt < 4294967296)
            {
                return ConvertIpV4IntToString((Int64)ipInt);
            }
            else
            {
                return ConvertIpV6IntToString(ipInt);
            }
        }

        /// <summary>
        /// Takes an IP address and a prefix and returns all the
        /// IPs in that range. For example, supplying '192.168.0.1'
        /// and '30' will return 192.168.0.1, ..2, ..3 and ..4.
        /// </summary>
        /// <param name="ipAddress">The IP address.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>IP range.</returns>
        public Queue<string> GetIPRange(string ipAddress, int prefix) {

            Queue<string> range = new Queue<string>();

            // Split the IP into bytes.
            string[] ipBytes = ipAddress.Split('.');

            // Each octet of the address.
            int firstOctet = Convert.ToInt32(ipBytes[0]);
            int secondOctet = Convert.ToInt32(ipBytes[1]);
            int thirdOctet = Convert.ToInt32(ipBytes[2]);
            int fourthOctet = Convert.ToInt32(ipBytes[3]);

            // Add the original IP to the list of IPs.
            range.Enqueue(ipAddress);

            // Convert the prefix into a number of IP addresses.
            Int64 ipRange = (Int64)(Math.Pow(2, 32 - prefix));

            // Increment the starting IP over the range of IPs.
            int count = 0;
            while (count < ipRange - 1)
            {

                // Add one to the IP.
                fourthOctet++;

                // If the fourth octet is over 255, then change it to
                // 0 and increment the third octet by 1.
                if (fourthOctet == 256)
                {
                    thirdOctet++;
                    fourthOctet = 0;

                    // If the third octet has gone over 255, change it to 
                    // 0 and increment second octet by 1.
                    if (thirdOctet == 256)
                    {
                        secondOctet++;
                        thirdOctet = 0;

                        // If the second octet has gone over 255, change it
                        // to 0 and increment the first octet by 1.
                        if (secondOctet == 256)
                        {
                            firstOctet++;
                            secondOctet = 0;

                            // If the first octet goes over 255 then make it 255 and end execution,
                            // as there are no more IPs to add.
                            if (firstOctet == 256)
                            {
                                firstOctet = 255;
                                break;
                            }
                        }
                    }
                }

                // Convert this new IP into a string.
                string newIP = firstOctet + "." + secondOctet + "." + thirdOctet + "." + fourthOctet;

                // Add it to the list.
                range.Enqueue(newIP);

                count++;
            }

            return range;
        }

        /// <summary>
        /// Convert To Hexadecimal.
        /// </summary>
        /// <param name="quadHex">Integer IP address.</param>
        /// <returns>Hexadecimal IP addresss.</returns>
        private static String ConvertToHexadecimal(Int64 quadHex) {

            String hexString = quadHex.ToString("X");

            // include leading zeros
            for (Int32 i = hexString.Length; i < 4; i++)
            {
                hexString = "0" + hexString;
            }
            return hexString;
        }

        /// <summary>
        /// Broadcast Address.
        /// </summary>
        public String BroadcastAddress {
            get { return broadcastAddress; }
        }

        /// <summary>
        /// Network Address.
        /// </summary>
        public String NetworkAddress {
            get { return networkAddress; }
        }

        /// <summary>
        /// Range.
        /// </summary>
        public BigInteger IpRange {
            get { return ipRangeInteger; }
        }

        /// <summary>
        /// Netmask.
        /// </summary>
        public String Netmask {
            get { return ipNetMask; }
        }

        /// <summary>
        /// Network Integer.
        /// </summary>
        public BigInteger NetworkInteger {
            get { return networkInteger; }
        }

        /// <summary>
        /// Broadcast Integer.
        /// </summary>
        public BigInteger BroadcastInteger {
            get { return broadcastInteger; }
        }
        
        /// <summary>
        /// IP version.
        /// </summary>
        public enum IpVersion {
            
            /// <summary>
            /// IPv4.
            /// </summary>
            V4 = 4,

            /// <summary>
            /// IPv6.
            /// </summary>
            V6 = 6
        }
    }
}
