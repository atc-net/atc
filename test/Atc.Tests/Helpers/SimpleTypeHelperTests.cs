using System;
using Atc.Helpers;
using Xunit;

namespace Atc.Tests.Helpers
{
    public class SimpleTypeHelperTests
    {
        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("byte", typeof(byte))]
        [InlineData("char", typeof(char))]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("DateTimeOffset", typeof(DateTimeOffset))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("double", typeof(double))]
        [InlineData("float", typeof(float))]
        [InlineData("Guid", typeof(Guid))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("object", typeof(object))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("short", typeof(short))]
        [InlineData("string", typeof(string))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("void", typeof(void))]
        [InlineData("bool?", typeof(bool?))]
        [InlineData("byte?", typeof(byte?))]
        [InlineData("char?", typeof(char?))]
        [InlineData("DateTime?", typeof(DateTime?))]
        [InlineData("DateTimeOffset?", typeof(DateTimeOffset?))]
        [InlineData("decimal?", typeof(decimal?))]
        [InlineData("double?", typeof(double?))]
        [InlineData("float?", typeof(float?))]
        [InlineData("Guid?", typeof(Guid?))]
        [InlineData("int?", typeof(int?))]
        [InlineData("long?", typeof(long?))]
        [InlineData("sbyte?", typeof(sbyte?))]
        [InlineData("short?", typeof(short?))]
        [InlineData("uint?", typeof(uint?))]
        [InlineData("ulong?", typeof(ulong?))]
        [InlineData("ushort?", typeof(ushort?))]
        public void GetBeautifyTypeName(string expected, Type type)
            => Assert.Equal(expected, SimpleTypeHelper.GetBeautifyTypeName(type));

        [Theory]
        [InlineData(typeof(bool))]
        public void GetBeautifyTypeNameByRef(Type type)
        {
            // Act
            Exception exception = null;
            try
            {
                SimpleTypeHelper.GetBeautifyTypeNameByRef(type);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Theory]
        [InlineData("bool[]", typeof(bool[]))]
        [InlineData("byte[]", typeof(byte[]))]
        [InlineData("char[]", typeof(char[]))]
        [InlineData("DateTime[]", typeof(DateTime[]))]
        [InlineData("DateTimeOffset[]", typeof(DateTimeOffset[]))]
        [InlineData("decimal[]", typeof(decimal[]))]
        [InlineData("double[]", typeof(double[]))]
        [InlineData("float[]", typeof(float[]))]
        [InlineData("Guid[]", typeof(Guid[]))]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("long[]", typeof(long[]))]
        [InlineData("object[]", typeof(object[]))]
        [InlineData("sbyte[]", typeof(sbyte[]))]
        [InlineData("short[]", typeof(short[]))]
        [InlineData("string[]", typeof(string[]))]
        [InlineData("uint[]", typeof(uint[]))]
        [InlineData("ulong[]", typeof(ulong[]))]
        [InlineData("ushort[]", typeof(ushort[]))]

        public void GetBeautifyArrayTypeName(string expected, Type type)
            => Assert.Equal(expected, SimpleTypeHelper.GetBeautifyArrayTypeName(type));
    }
}