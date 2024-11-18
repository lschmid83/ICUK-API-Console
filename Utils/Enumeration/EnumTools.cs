using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Utils.Enumeration {
	
	/// <summary>
	/// Static methods for working with enums.
	/// </summary>
	public class EnumTools {

		/// <summary>
		/// Uses System.Reflection to retrieve the Description attribute set on an enumeration. Defaults to the enumeration itself should a description not be set.
		/// </summary>
		/// <param name="e">The enum value.</param>
		/// <returns>The description string, or the enumeration itself.</returns>
		public static string GetEnumDescription(Enum e) {

			FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

			DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (enumAttributes.Length > 0) {
				return enumAttributes[0].Description;
			}

			return e.ToString();
		}

		/// <summary>
		/// Uses System.Reflection to retrieve the Description attribute set on an enumeration. Defaults to null should a description not be set.
		/// </summary>
        /// <param name="m">Information about the attributes of a member.</param>
		/// <returns>The description string, or the enumeration itself.</returns>
        public static string GetEnumDescription(MemberInfo m) {

            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])m.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0) {
                return enumAttributes[0].Description;
            }

            return null;
        }

	}

	/// <summary>
	/// Static methods for working with enums.
	/// </summary>
	public static class EnumToolsExtension {

		/// <summary>
		/// Uses System.Reflection to retrieve the Description attribute set on an enumeration. Defaults to the enumeration itself should a description not be set.
		/// </summary>
		/// <param name="e">The enum value.</param>
		/// <returns>The description string, or the enumeration itself.</returns>
		public static string GetEnumDescription(this Enum e) {

			FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

			DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if(enumAttributes.Length > 0) {
				return enumAttributes[0].Description;
			}

			return e.ToString();
		}

	}

}
