using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atc;

// ReSharper disable once CheckNamespace
namespace System.Reflection
{
    /// <summary>
    /// Extensions for the <see cref="MemberInfo"/> class.
    /// </summary>
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Determines whether [has ignore display attribute].
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <returns>
        ///   <c>true</c> if [has ignore display attribute] [the specified member information]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">memberInfo.</exception>
        public static bool HasIgnoreDisplayAttribute(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(IgnoreDisplayAttribute));
            return attributeData != null;
        }

        /// <summary>
        /// Determines whether [has required attribute].
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <returns>
        ///   <c>true</c> if [has required attribute] [the specified member information]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">memberInfo.</exception>
        public static bool HasRequiredAttribute(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            return attributeData != null;
        }

        /// <summary>
        /// Determines whether [is property with setter].
        /// </summary>
        /// <param name="member">The member.</param>
        public static bool IsPropertyWithSetter(this MemberInfo member)
        {
            var property = member as PropertyInfo;

            return property?.GetSetMethod(true) != null;
        }

        /// <summary>
        /// Gets the type of the underlying.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">member.</exception>
        /// <exception cref="ArgumentException">Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo.</exception>
        public static Type GetUnderlyingType(this MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            switch (member.MemberType)
            {
                case MemberTypes.Event:
                    return ((EventInfo)member).EventHandlerType;
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Method:
                    return ((MethodInfo)member).ReturnType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException("Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo");
            }
        }
    }
}