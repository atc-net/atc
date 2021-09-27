using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Atc.Helpers
{
    /// <summary>
    /// ReflectionHelper.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Sets the private field.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "OK.")]
        [ExcludeFromCodeCoverage]
        public static void SetPrivateField(object target, string fieldName, object value)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullOrDefaultException(nameof(fieldName));
            }

            var type = target.GetType();
            FieldInfo? fi = null;
            while (type is not null)
            {
                fi = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi is not null)
                {
                    break;
                }

                type = type.BaseType!;
            }

            if (fi is null)
            {
                throw new ArgumentPropertyException($"Field '{fieldName}' not found in type hierarchy.");
            }

            fi.SetValue(target, value);
        }
    }
}