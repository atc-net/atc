using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Atc.Collections;
using Xunit;

namespace Atc.Tests.Extensions.Reflection
{
    public class TypeExtensionsTests
    {
        [Theory]
        [InlineData(false, typeof(NumericAlphaComparer))]
        [InlineData(true, typeof(EmailAddressAttribute))]
        public void HasValidationAttributes(bool expected, Type type)
        {
            // Act
            var actual = type.HasValidationAttributes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(NumericAlphaComparer))]
        [InlineData(true, typeof(Delegate))]
        public void IsDelegate(bool expected, Type type)
        {
            // Act
            var actual = type.IsDelegate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(double))]
        [InlineData(true, typeof(double?))]
        public void IsNullable(bool expected, Type type)
        {
            // Act
            var actual = type.IsNullable();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(NumericAlphaComparer))]
        [InlineData(false, typeof(EmailAddressAttribute))]
        [InlineData(true, typeof(DayOfWeek))]
        [InlineData(true, typeof(int))]
        [InlineData(true, typeof(string))]
        public void IsSimple(bool expected, Type type)
        {
            // Act
            var actual = type.IsSimple();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(DataTypeAttribute), typeof(DataTypeAttribute))]
        [InlineData(false, typeof(DataTypeAttribute), typeof(EmailAddressAttribute))]
        [InlineData(false, typeof(EmailAddressAttribute), typeof(EmailAddressAttribute))]
        [InlineData(true, typeof(EmailAddressAttribute), typeof(DataTypeAttribute))]
        public void IsInheritedFrom(bool expected, Type type, Type baseType)
        {
            // Act
            var actual = type.IsInheritedFrom(baseType);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(EmailAddressAttribute), typeof(EmailAddressAttribute), typeof(EmailAddressAttribute))]
        public void IsInheritedFromGenericWithArgumentType(bool expected, Type type, Type baseType, Type argumentType)
        {
            // Act
            var actual = type.IsInheritedFromGenericWithArgumentType(baseType, argumentType);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(EmailAddressAttribute), typeof(EmailAddressAttribute), typeof(EmailAddressAttribute), false)]
        public void IsInheritedFromGenericWithArgumentType_MatchAlsoOnArgumentTypeInterface(bool expected, Type type, Type baseType, Type argumentType, bool matchAlsoOnArgumentTypeInterface)
        {
            // Act
            var actual = type.IsInheritedFromGenericWithArgumentType(baseType, argumentType, matchAlsoOnArgumentTypeInterface);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, typeof(EmailAddressAttribute))]
        public void GetBaseTypeGenericArgumentType(bool expected, Type type)
        {
            // Act
            var actual = type.GetBaseTypeGenericArgumentType();

            // Assert
            if (expected)
            {
                Assert.NotNull(actual);
            }
            else
            {
                Assert.Null(actual);
            }
        }

        [Theory]
        [InlineData(0, typeof(EmailAddressAttribute))]
        public void GetBaseTypeGenericArgumentTypes(int expected, Type type)
        {
            // Act
            var actual = type.GetBaseTypeGenericArgumentTypes();

            // Assert
            if (expected == 0)
            {
                Assert.Null(actual);
            }
            else
            {
                Assert.NotNull(actual);
                Assert.Equal(expected, actual.Length);
            }
        }

        [Theory]
        [InlineData(true, typeof(EmailAddressAttribute))]
        [InlineData(false, typeof(NumericAlphaComparer))]
        public void GetAttribute(bool expected, Type type)
        {
            // Act
            var actual = type.GetAttribute<AttributeUsageAttribute>();

            // Assert
            if (expected)
            {
                Assert.NotNull(actual);
            }
            else
            {
                Assert.Null(actual);
            }
        }

        [Theory]
        [InlineData(true, typeof(EmailAddressAttribute))]
        [InlineData(false, typeof(NumericAlphaComparer))]
        public void TryGetAttribute(bool expected, Type type)
        {
            // Act
            var actual = type.TryGetAttribute<AttributeUsageAttribute>();

            // Assert
            if (expected)
            {
                Assert.NotNull(actual);
            }
            else
            {
                Assert.Null(actual);
            }
        }

        [Theory]
        [InlineData(1, typeof(EmailAddressAttribute))]
        [InlineData(0, typeof(NumericAlphaComparer))]
        public void GetAttributes(int expected, Type type)
        {
            // Act
            var actual = type.GetAttributes<AttributeUsageAttribute>();

            // Assert
            Assert.Equal(expected, actual.Count());
        }

        [Theory]
        [InlineData(1, typeof(EmailAddressAttribute))]
        public void GetPublicDeclaredOnlyMethods(int expected, Type type)
        {
            // Act
            var actual = type.GetPublicDeclaredOnlyMethods();

            // Assert
            Assert.Equal(expected, actual.Length);
        }

        [Theory]
        [InlineData(0, typeof(EmailAddressAttribute))]
        public void GetPrivateDeclaredOnlyMethods(int expected, Type type)
        {
            // Act
            var actual = type.GetPrivateDeclaredOnlyMethods();

            // Assert
            Assert.Equal(expected, actual.Length);
        }

        [Theory]
        [InlineData(false, typeof(EmailAddressAttribute), "IsValid")]
        public void GetPrivateDeclaredOnlyMethod(bool expected, Type type, string methodName)
        {
            // Act
            var actual = type.GetPrivateDeclaredOnlyMethod(methodName);

            // Assert
            if (expected)
            {
                Assert.NotNull(actual);
            }
            else
            {
                Assert.Null(actual);
            }
        }

        [Theory]
        [InlineData("ConcurrentHashSet", typeof(ConcurrentHashSet<int>))]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute))]
        [InlineData("Dictionary", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>))]
        public void GetNameWithoutGenericType(string expected, Type type)
        {
            Assert.Equal(expected, type.GetNameWithoutGenericType());
        }

        [Theory]
        [InlineData("ConcurrentHashSet", typeof(ConcurrentHashSet<int>), false)]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), false)]
        [InlineData("Dictionary", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false)]
        [InlineData("Atc.Collections.ConcurrentHashSet", typeof(ConcurrentHashSet<int>), true)]
        [InlineData("Atc.LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), true)]
        [InlineData("System.Collections.Generic.Dictionary", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true)]
        public void GetNameWithoutGenericType_UseFullName(string expected, Type type, bool useFullName)
        {
            Assert.Equal(expected, type.GetNameWithoutGenericType(useFullName));
        }

        [Theory]
        [InlineData("typeof(int)", typeof(int))]
        [InlineData("typeof(bool)", typeof(bool))]
        [InlineData("typeof(LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute))]
        [InlineData("typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>))]
        [InlineData("typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>))]
        public void BeautifyTypeOfName(string expected, Type type)
        {
            Assert.Equal(expected, type.BeautifyTypeOfName());
        }

        [Theory]
        [InlineData("typeof(int)", typeof(int), false)]
        [InlineData("typeof(int)", typeof(int), true)]
        [InlineData("typeof(bool)", typeof(bool), false)]
        [InlineData("typeof(bool)", typeof(bool), true)]
        [InlineData("typeof(LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), false)]
        [InlineData("typeof(Atc.LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), true)]
        [InlineData("typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false)]
        [InlineData("typeof(System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true)]
        [InlineData("typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false)]
        [InlineData("typeof(System.Collections.Generic.List<System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>>)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true)]
        public void BeautifyTypeOfName_UseFullName(string expected, Type type, bool useFullName)
        {
            Assert.Equal(expected, type.BeautifyTypeOfName(useFullName));
        }

        [Theory]
        [InlineData("typeof(int)", typeof(int), false, false)]
        [InlineData("typeof(int)", typeof(int), true, false)]
        [InlineData("typeof(bool)", typeof(bool), false, false)]
        [InlineData("typeof(bool)", typeof(bool), true, false)]
        [InlineData("typeof(LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), false, false)]
        [InlineData("typeof(Atc.LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), true, false)]
        [InlineData("typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, false)]
        [InlineData("typeof(System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true, false)]
        [InlineData("typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false, false)]
        [InlineData("typeof(System.Collections.Generic.List<System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>>)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true, false)]
        [InlineData("typeof(int)", typeof(int), false, true)]
        [InlineData("typeof(int)", typeof(int), true, true)]
        [InlineData("typeof(bool)", typeof(bool), false, true)]
        [InlineData("typeof(bool)", typeof(bool), true, true)]
        [InlineData("typeof(LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), false, true)]
        [InlineData("typeof(Atc.LocalizedDescriptionAttribute)", typeof(LocalizedDescriptionAttribute), true, true)]
        [InlineData("typeof(Dictionary&lt;LocalizedDescriptionAttribute, LocalizedDescriptionAttribute&gt;)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, true)]
        [InlineData("typeof(System.Collections.Generic.Dictionary&lt;Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute&gt;)", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true, true)]
        [InlineData("typeof(List&lt;Dictionary&lt;LocalizedDescriptionAttribute, LocalizedDescriptionAttribute&gt;&gt;)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false, true)]
        [InlineData("typeof(System.Collections.Generic.List&lt;System.Collections.Generic.Dictionary&lt;Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute&gt;&gt;)", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true, true)]
        public void BeautifyTypeOfName_UseFullName_UseHtmlFormat(string expected, Type type, bool useFullName, bool useHtmlFormat)
        {
            Assert.Equal(expected, type.BeautifyTypeOfName(useFullName, useHtmlFormat));
        }

        [Theory]
        [InlineData("int", typeof(int))]
        [InlineData("bool", typeof(bool))]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute))]
        [InlineData("Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>))]
        [InlineData("List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>))]
        public void BeautifyName(string expected, Type type)
        {
            Assert.Equal(expected, type.BeautifyName());
        }

        [Theory]
        [InlineData("int", typeof(int), false)]
        [InlineData("int", typeof(int), true)]
        [InlineData("bool", typeof(bool), false)]
        [InlineData("bool", typeof(bool), true)]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), false)]
        [InlineData("Atc.LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), true)]
        [InlineData("Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false)]
        [InlineData("System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true)]
        [InlineData("List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false)]
        [InlineData("System.Collections.Generic.List<System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>>", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true)]
        public void BeautifyName_UseFullName(string expected, Type type, bool useFullName)
        {
            Assert.Equal(expected, type.BeautifyName(useFullName));
        }

        [Theory]
        [InlineData("int", typeof(int), false, false)]
        [InlineData("int", typeof(int), true, false)]
        [InlineData("bool", typeof(bool), false, false)]
        [InlineData("bool", typeof(bool), true, false)]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), false, false)]
        [InlineData("Atc.LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), true, false)]
        [InlineData("Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, false)]
        [InlineData("System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true, false)]
        [InlineData("List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false, false)]
        [InlineData("System.Collections.Generic.List<System.Collections.Generic.Dictionary<Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute>>", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true, false)]
        [InlineData("int", typeof(int), false, true)]
        [InlineData("int", typeof(int), true, true)]
        [InlineData("bool", typeof(bool), false, true)]
        [InlineData("bool", typeof(bool), true, true)]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), false, true)]
        [InlineData("Atc.LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), true, true)]
        [InlineData("Dictionary&lt;LocalizedDescriptionAttribute, LocalizedDescriptionAttribute&gt;", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, true)]
        [InlineData("System.Collections.Generic.Dictionary&lt;Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute&gt;", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), true, true)]
        [InlineData("List&lt;Dictionary&lt;LocalizedDescriptionAttribute, LocalizedDescriptionAttribute&gt;&gt;", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), false, true)]
        [InlineData("System.Collections.Generic.List&lt;System.Collections.Generic.Dictionary&lt;Atc.LocalizedDescriptionAttribute, Atc.LocalizedDescriptionAttribute&gt;&gt;", typeof(List<Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>>), true, true)]
        public void BeautifyName_UseFullName_UseHtmlFormat(string expected, Type type, bool useFullName, bool useHtmlFormat)
        {
            Assert.Equal(expected, type.BeautifyName(useFullName, useHtmlFormat));
        }

        [Theory]
        [InlineData("Dictionary<T, LocalizedDescriptionAttribute>", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, false, true)]
        public void BeautifyName_UseFullName_UseHtmlFormat_UseGenericParameterNamesAsT(string expected, Type type, bool useFullName, bool useHtmlFormat, bool useGenericParameterNamesAsT)
        {
            Assert.Equal(expected, type.BeautifyName(useFullName, useHtmlFormat, useGenericParameterNamesAsT));
        }

        [Theory]
        [InlineData("T, LocalizedDescriptionAttribute?", typeof(Dictionary<LocalizedDescriptionAttribute, LocalizedDescriptionAttribute>), false, false, true, true)]
        public void BeautifyName_UseFullName_UseGenericParameterNamesAsT_UseSuffixQuestionMarkForGeneric(string expected, Type type, bool useFullName, bool useHtmlFormat, bool useGenericParameterNamesAsT, bool useSuffixQuestionMarkForGeneric)
        {
            Assert.Equal(expected, type.BeautifyName(useFullName, useHtmlFormat, useGenericParameterNamesAsT, useSuffixQuestionMarkForGeneric));
        }

        [Theory]
        [InlineData("object", null)]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]

        [InlineData("string", typeof(string))]
        [InlineData("bool", typeof(bool))]
        [InlineData("int", typeof(int))]
        [InlineData("uint", typeof(uint))]
        [InlineData("byte", typeof(byte))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("short", typeof(short))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("long", typeof(long))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("char", typeof(char))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("bool?", typeof(bool?))]
        [InlineData("int?", typeof(int?))]
        [InlineData("uint?", typeof(uint?))]
        [InlineData("byte?", typeof(byte?))]
        [InlineData("sbyte?", typeof(sbyte?))]
        [InlineData("short?", typeof(short?))]
        [InlineData("ushort?", typeof(ushort?))]
        [InlineData("long?", typeof(long?))]
        [InlineData("ulong?", typeof(ulong?))]
        [InlineData("char?", typeof(char?))]
        [InlineData("float?", typeof(float?))]
        [InlineData("double?", typeof(double?))]
        [InlineData("decimal?", typeof(decimal?))]
        [InlineData("string[]", typeof(string[]))]
        [InlineData("bool[]", typeof(bool[]))]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("uint[]", typeof(uint[]))]
        [InlineData("byte[]", typeof(byte[]))]
        [InlineData("sbyte[]", typeof(sbyte[]))]
        [InlineData("short[]", typeof(short[]))]
        [InlineData("ushort[]", typeof(ushort[]))]
        [InlineData("long[]", typeof(long[]))]
        [InlineData("ulong[]", typeof(ulong[]))]
        [InlineData("char[]", typeof(char[]))]
        [InlineData("float[]", typeof(float[]))]
        [InlineData("double[]", typeof(double[]))]
        [InlineData("decimal[]", typeof(decimal[]))]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute))]
        public void BeautifyTypeName(string expected, Type type)
        {
            Assert.Equal(expected, type.BeautifyTypeName());
        }

        [Theory]
        [InlineData("int", typeof(int), false)]
        [InlineData("int", typeof(int), true)]
        [InlineData("bool", typeof(bool), false)]
        [InlineData("bool", typeof(bool), true)]
        [InlineData("LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), false)]
        [InlineData("Atc.LocalizedDescriptionAttribute", typeof(LocalizedDescriptionAttribute), true)]
        public void BeautifyTypeName_UseFullName(string expected, Type type, bool useFullName)
        {
            Assert.Equal(expected, type.BeautifyTypeName(useFullName));
        }
    }
}