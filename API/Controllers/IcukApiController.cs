using API.Core;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace API.Controllers {

    /// <summary>
    /// Base class for all API modules.
    /// </summary>
    public class IcukApiController : System.Web.Http.ApiController {

        /// <summary>
        /// Reads API JSON response from a file and deserializes to result type.
        /// </summary>
        /// <typeparam name="T">Type of API response.</typeparam>
        /// <param name="filename">Filename.</param>
        /// <returns>Deserialized result set.</returns>
        public T GetResults<T>(string filename) {
            
            JsonSerializerSettings jss = new JsonSerializerSettings {
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new JsonSerializerContract()
            };

            string workingDirectory = Environment.CurrentDirectory;
            string results = File.ReadAllText(WebApiApplication.DataFolder + filename);

           return JsonConvert.DeserializeObject<T>(results, jss);
        }

    }

}
