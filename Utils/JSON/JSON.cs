using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Newtonsoft.Json.Linq;

namespace Utils.JSON {

	/// <summary>
	/// Static methods for common JSON operations
	/// </summary>
	public class JSON {

		/// <summary>
		/// Uses JsonWriter to build a standard JSON response containing an ok boolean
		/// </summary>
		/// <param name="ok">The status of the request</param>
		/// <returns></returns>
		public static string ConstructJsonResponse(bool ok) {
			StringBuilder json = new StringBuilder();

			using (JsonWriter jsonWriter = new JsonTextWriter(new StringWriter(json))) {

				// Start the object
				jsonWriter.WriteStartObject();

				// Add the status
				jsonWriter.WriteMember("ok");
				jsonWriter.WriteBoolean(ok);

				// End the object
				jsonWriter.WriteEndObject();

			}

			return json.ToString();
		}

		/// <summary>
		/// Build a standard JSON response, containing an ok boolean and error string.
		/// </summary>
		/// <param name="ok">The status of the request.</param>
		/// <param name="msg">A response message, detailing any errors.</param>
		/// <returns>JSON response string.</returns>
		public static string ConstructJsonResponse(bool ok, string msg) {
			
            JObject json = new JObject(new JProperty("ok", msg));
			return json.ToString();

		}

		/// <summary>
		/// Uses JsonWriter to build a standard JSON response, containing an ok boolean, and error and html strings
		/// </summary>
		/// <param name="ok">The status of the request</param>
		/// <param name="msg">A response message, detailing any errors</param>
		/// <param name="html">A HTML content response</param>
		/// <returns></returns>
		public static string ConstructJsonResponse(bool ok, string msg, string html) {
			StringBuilder json = new StringBuilder();

			using (JsonWriter jsonWriter = new JsonTextWriter(new StringWriter(json))) {

				// Start the object
				jsonWriter.WriteStartObject();

				// Add the status
				jsonWriter.WriteMember("ok");
				jsonWriter.WriteBoolean(ok);

				// Add an error message
				jsonWriter.WriteMember("msg");
				jsonWriter.WriteString(msg);

				// Add an empty html string
				jsonWriter.WriteMember("html");
				jsonWriter.WriteString(html);

				// End the object
				jsonWriter.WriteEndObject();

			}

			return json.ToString();
		}
	
	}

}
