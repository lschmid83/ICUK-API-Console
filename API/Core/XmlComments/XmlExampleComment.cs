using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// Represents API method example documentation.
    /// </summary>
    public class XmlExampleComment : XmlCommentBase, IXmlComment {
        
        /// <summary>
        /// Example title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Example HTTP response.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Validates API method example documentation.
        /// </summary>
        public void Validate() {

            if (String.IsNullOrWhiteSpace(Title))
                throw new XmlCommentException("The <example> -> <title> element is missing or blank.", MethodInfo);

            if (String.IsNullOrWhiteSpace(Content))
                throw new XmlCommentException("The <example> -> <content> element is missing or blank.", MethodInfo);

            string json = "";
            string[] lines = Content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            // Example includes message body
            if (lines.Length > 4) {

                // Rebuild string removing HTTP method
                for(int i = 2; i < lines.Length-1; i++) {
                    json += lines[i] + " ";
                }

                // Replace constants
                json = InsertConstants(json);

                // Replace ellipsis
                json = json.Replace("{...}", "0"); 

                json = json.Trim();
                
                try {
                    // Validate JSON
                    JContainer.Parse(json);
                }
                catch (Exception) {
                    throw new XmlCommentException("The <example> -> <content> message body is not valid JSON.", MethodInfo);
                }
            }
 
        }

        /// <summary>
        /// Constructs a JSON string from the properties.
        /// </summary>
        /// <returns>JSON string.</returns>
        public string ToJson() {

            StringBuilder json = new StringBuilder();

            json.Append(@"
        {");

            json.Append(@"
            ""title"": """ + Title + @""",
            ""content"": """ + FormatExampleContent(InsertConstants(Content)) + @"""
        },");

            return json.ToString();

        }

        /// <summary>
        /// Inserts constants in example content.
        /// </summary>
        /// <param name="content">Example code.</param>
        /// <returns>Example content with constants replaced with enum values.</returns>
        public string InsertConstants(string content) {

            // Account
            content = content.Replace("%username%", ApiConstants.USERNAME.ToJsonString());

            // Date time
            content = content.Replace("%year%", ApiConstants.START_TIME.Year.ToString());
            content = content.Replace("%month%", ApiConstants.START_TIME.Month.ToString());
            content = content.Replace("%day%", ApiConstants.START_TIME.Day.ToString());
            content = content.Replace("%hour%", ApiConstants.START_TIME.Hour.ToString());

            // Broadband peak hours
            content = content.Replace("%peak_start%", ApiConstants.START_TIME.ToString(@"HH\:mm\:ss").ToJsonString());
            content = content.Replace("%peak_end%", ApiConstants.END_TIME.ToString(@"HH\:mm\:ss").ToJsonString());
 
            content = content.Replace("%start_time%", ApiConstants.START_TIME.ToString(@"yyyy-MM-ddTHH\:mm\:ss").ToJsonString());
            content = content.Replace("%end_time%", ApiConstants.END_TIME.ToString(@"yyyy-MM-ddTHH\:mm\:ss").ToJsonString());
            content = content.Replace("%time_span%", new SecondsMagnitudeConverter((int)ApiConstants.END_TIME.Subtract(ApiConstants.START_TIME).TotalSeconds).ToString().ToJsonString());

            // IP allocation
            content = content.Replace("%ip_allocation_type%", ApiConstants.IP_ALLOCATION_TYPE.ToJsonString());
             
            IpPropertyCalculator ipCalc = new IpPropertyCalculator();
            ipCalc.Address = ApiConstants.IPV4;
            ipCalc.Prefix = Int32.Parse(ApiConstants.IP_PREFIX);
            ipCalc.Calculate();
            content = content.Replace("%ipv4%", ipCalc.Address.ToJsonString());
            content = content.Replace("%ipv4_network%", ipCalc.NetworkAddress.ToJsonString());
            content = content.Replace("%ipv4_netmask%", ipCalc.Netmask.ToJsonString());
            content = content.Replace("%ipv4_broadcast%", ipCalc.BroadcastAddress.ToJsonString());

            content = content.Replace("%ip_range%", ipCalc.IpRange.ToString());
            content = content.Replace("%ip_prefix%", ApiConstants.IP_PREFIX.ToJsonString());
            
            ipCalc = new IpPropertyCalculator();
            ipCalc.Address = ApiConstants.IPV6;
            ipCalc.Prefix = Int32.Parse(ApiConstants.IP_PREFIX);
            ipCalc.Calculate();
            content = content.Replace("%ipv6%", ipCalc.Address.ToJsonString());
            content = content.Replace("%ipv6_network%", ipCalc.NetworkAddress.ToJsonString());
            content = content.Replace("%ipv6_netmask%", ipCalc.Netmask.ToJsonString());
            content = content.Replace("%ipv6_broadcast%", ipCalc.BroadcastAddress.ToJsonString());

            content = content.Replace("%timestamp%", ApiConstants.START_TIME.ToString("yyyy-mm-ddTHH:mm:ss").ToJsonString());

            return content;
        }

        /// <summary>
        /// Formats example content.
        /// </summary>
        /// <param name="content">Example code.</param>
        /// <returns>String formatted for JavaScript Prettify.</returns>
        public string FormatExampleContent(string content) {

            // Remove padding in comment block
            StringBuilder formattedContent = new StringBuilder();
            string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Regex r = new Regex("            ");
            foreach (string line in lines) {
                formattedContent.AppendLine(r.Replace(line, "", 1));
            }

            content = formattedContent.ToString();
            
            // Replace new line characters
            content = content.Replace(Environment.NewLine, @"\n");
            content = content.Substring(2, content.Length - 6);
            content = content.Trim();
            
            // Escape quotes in example content
            content = content.Replace("\"", @"\""");

            return content;
        }
    }
}