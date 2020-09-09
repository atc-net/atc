using System;
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
        public static void SetPrivateField(object target, string fieldName, object value)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullOrDefaultException(nameof(fieldName));
            }

            var type = target.GetType();
            FieldInfo? fi = null;
            while (type != null)
            {
                fi = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi != null)
                {
                    break;
                }

                type = type.BaseType!;
            }

            if (fi == null)
            {
                throw new ArgumentPropertyException($"Field '{fieldName}' not found in type hierarchy.");
            }

            fi.SetValue(target, value);
        }
    }
}