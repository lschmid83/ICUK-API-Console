using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace API.SDK
{
    /// <summary>
    /// API client.
    /// </summary>
    public class IcukApiClient
    {
        /// <summary>
        /// The username of the connecting user.
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// The user's supplied API key.
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// The authentication method.
        /// </summary>
        public string Encryption { get; set; }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">IcukApiRequest object.</param>
        /// <returns>IcukApiResponse object containing API response.</returns>
        public IcukApiResponse Send(IcukApiRequest request) {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(request.Url));
            webRequest.Method = request.Method;
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            
            string hash = String.Empty;
            Uri uri = new Uri(request.Url);
            string method = uri.AbsolutePath;
            method = HttpUtility.UrlDecode(method);

            if (Encryption == null) {
                Encryption = "SHA-512";
                hash = Sha512.Hash(method + Key);
            }
            else if (Encryption.Equals("SHA-256")) {
                hash = Sha256.Hash(method + Key);
            }
            else if (Encryption.Equals("SHA-512")) {
                hash = Sha512.Hash(method + Key);
            }
            else if (Encryption.Equals("MD5")) {
                hash = Md5.Hash(method + Key);
            }
            else {
                throw new Exception("Unsupported encryption method.");
            }

            webRequest.Headers.Add("User", Username);
            webRequest.Headers.Add("Hash", hash);
            webRequest.Headers.Add("Encryption", Encryption);

            IcukApiResponse response = new IcukApiResponse();

            HttpWebResponse webResponse = null;
            try {

                if (request.Body != null) {
                    string requestBody = "=" + request.Body.ToString();
                    webRequest.ContentLength = requestBody.Length;
                    StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream(), System.Text.Encoding.ASCII);
                    streamWriter.Write(requestBody);
                    streamWriter.Close();
                }
                else {
                    if(request.Method == "POST")
                        webRequest.ContentLength = 0;
                }
                               
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());

                response.Response = reader.ReadToEnd();

                if (webResponse.Headers.AllKeys.Contains("Location"))
                    response.Location = webResponse.Headers["Location"];

                response.StatusCode = (int)webResponse.StatusCode;
                response.Success = true;
            }
            catch (WebException e) {

                // Try and read internal API exception message
                if (e.Response != null) {
                    using (StreamReader stream = new StreamReader(e.Response.GetResponseStream())) {
                        try {
                            JObject json = JsonConvert.DeserializeObject<JObject>(stream.ReadToEnd());
                            response.ErrorMessage = json.GetValue("exception_message").ToString();
                            response.ErrorType = json.GetValue("exception_type").ToString();
                        }
                        catch (Exception) {
                            response.ErrorMessage = e.Message;
                        }
                        response.StatusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                        stream.Close();
                    }
                }
                else {
                    response.ErrorMessage = e.Message;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                response.Success = false;
            }
            finally {
                if (webResponse != null) {
                    webResponse.Close();
                }
            }

            return response;

        }
    }
}
