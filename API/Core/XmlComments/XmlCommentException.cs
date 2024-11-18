using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Utils.Enumeration;

namespace API.Core.XmlComments {
    
    /// <summary>
    /// Represents exceptions which occur due to missing or badly formed XML comments.
    /// </summary>
    public class XmlCommentException : System.Exception {

        /// <summary>
        /// Type where exception occured.
        /// </summary>
        public TypeInfo Type { get; set; }

        /// <summary>
        /// Method where exception occured.
        /// </summary>
        public MethodInfo Method { get; set; }
        
        /// <summary>
        /// Member where exception occured.
        /// </summary>
        public MemberInfo Member { get; set; }

        /// <summary>
        /// Property where exception occured.
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// Initializes an XmlCommentException with controller type info.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="typeInfo">TypeInfo</param>
        public XmlCommentException(string message, TypeInfo typeInfo)
            : base(message + Environment.NewLine +  "Type: " + typeInfo.FullName) {
            Type = typeInfo;
        }
        
        /// <summary>
        /// Initializes an XmlCommentException with controller method info.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="methodInfo">MethodInfo</param>
        public XmlCommentException(string message, MethodInfo methodInfo) 
            : base(message + Environment.NewLine + GetExceptionDetails(methodInfo)) {
            Method = methodInfo;
        }

        /// <summary>
        /// Initializes an XmlCommentException with controller struct property info.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="propertyInfo">PropertyInfo</param>
        public XmlCommentException(string message, PropertyInfo propertyInfo)
            : base(message + Environment.NewLine + GetExceptionDetails(propertyInfo)) {
            Property = propertyInfo;
        }

        /// <summary>
        /// Initializes an XmlCommentException with controller member info.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="memberInfo">MemberInfo</param>
        public XmlCommentException(string message, MemberInfo memberInfo)
            : base(message + Environment.NewLine + GetExceptionDetails(memberInfo)) {
            Member = memberInfo;
        }   
        
        /// <summary>
        /// Gets exception details.
        /// </summary>
        /// <param name="methodInfo">MethodInfo</param>
        /// <returns>Exception details.</returns>
        public static string GetExceptionDetails(MethodInfo methodInfo) {
            if (methodInfo != null) {
                return "Type: " + methodInfo.DeclaringType + Environment.NewLine + "Method: " + GetMethodSignature(methodInfo);
            }
            return "";
        }

        /// <summary>
        /// Gets exception details.
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        /// <returns>Exception details.</returns>
        public static string GetExceptionDetails(PropertyInfo propertyInfo) {
            if (propertyInfo != null) {
                return "Type: " + propertyInfo.DeclaringType + Environment.NewLine + "Property: " + GetPropertySignature(propertyInfo);
            }
            return "";
        }

        /// <summary>
        /// Gets exception details.
        /// </summary>
        /// <param name="memberInfo">MemberInfo</param>
        /// <returns>Exception details.</returns>
        public static string GetExceptionDetails(MemberInfo memberInfo) {
            if (memberInfo != null) {
                return "Type: " + memberInfo.DeclaringType + Environment.NewLine + "Member: " + GetMemberSignature(memberInfo);
            }
            return "";
        }

        /// <summary>
        /// Gets property signature from PropertyInfo.
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        /// <returns>Property signature.</returns>
        public static string GetPropertySignature(PropertyInfo propertyInfo) {

            if (propertyInfo == null)
                return "";

            string result = "public " + propertyInfo.PropertyType.Name + " " + propertyInfo.Name + " { get; set; }";

            return result;
        }

        /// <summary>
        /// Gets member signature from MemberInfo.
        /// </summary>
        /// <param name="memberInfo">MemberInfo</param>
        /// <returns>Member signature.</returns>
        public static string GetMemberSignature(MemberInfo memberInfo) {

            if (memberInfo == null)
                return "";

            string result = memberInfo.Name + " = " + EnumTools.GetEnumDescription(memberInfo);

            return result;
        }
                
        /// <summary>
        /// Gets method signature from MethodInfo.
        /// </summary>
        /// <param name="methodInfo">MethodInfo</param>
        /// <returns>Method signature.</returns>
        public static string GetMethodSignature(MethodInfo methodInfo) {

            if (methodInfo == null)
                return "";

            string result = "public " + methodInfo.ReturnType.Name + " " + methodInfo.Name + "(";

            foreach (ParameterInfo parameter in methodInfo.GetParameters()) {
                result += parameter.ParameterType.Name + " " + parameter.Name + ", ";
            }
            result = result.Trim().TrimEnd(',');

            result += ")";

            return result;
        }
    }
}