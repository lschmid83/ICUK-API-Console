using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace API.Core.XmlComments {

    /// <summary>
    /// Interface for XmlComment classes.
    /// </summary>
    public interface IXmlComment {

        /// <summary>
        /// Validates XML comments.
        /// </summary>
        void Validate();

        /// <summary>
        /// Constructs a JSON string from the properties.
        /// </summary>
        /// <returns>JSON string.</returns>
        string ToJson();
    }
}
