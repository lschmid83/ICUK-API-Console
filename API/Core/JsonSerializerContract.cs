using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace API.Core {

    /// <summary>
    /// Customizes how the JSON.NET JsonSerializer serializes and deserializes objects to JSON.
    /// </summary>
    public class JsonSerializerContract : DefaultContractResolver {

        /// <summary>
        /// Creates a JsonProperty for the given MemberInfo.
        /// </summary>
        /// <param name="member">The member to create a JsonProperty for.</param>
        /// <param name="memberSerialization">The member's parent MemberSerialization.</param>
        /// <returns>A created JsonProperty for the given MemberInfo.</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            
            // Serialize all properties.
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.Ignored = false;
            return property;

        }
    }
}
