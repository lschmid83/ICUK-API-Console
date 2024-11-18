using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace API.Core.XmlComments {

    /// <summary>
    /// XmlComment base class.
    /// </summary>
    public class XmlCommentBase {

        /// <summary>
        /// Attributes of the method.
        /// </summary>
        public MethodInfo MethodInfo { get; set; }

        /// <summary>
        /// Attributes of the property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        /// Attributes of the member.
        /// </summary>
        public MemberInfo MemberInfo { get; set; }

        /// <summary>
        /// Attributes of the type.
        /// </summary>
        public TypeInfo TypeInfo { get; set; }
        
        /// <summary>
        /// Validates a list of XML comment fields.
        /// </summary>
        /// <typeparam name="T">Type of field.</typeparam>
        /// <param name="fields">List of fields.</param>
        /// <returns>True if all of the fields validate; otherwise false.</returns>
        public void ValidateFields<T>(List<T> fields) where T : IXmlComment {

            if (fields == null)
                return;
            
            foreach (T type in fields) {
                type.Validate();
            }

        }
    }
}