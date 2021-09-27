using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Atc.Data;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Data
{
    public class DataFactoryTests
    {
        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
        public void CreateKeyValueDataTableOfIntString_DropDownFirstItemType(int expectedCount, DropDownFirstItemType dropDownFirstItemType)
        {
            // Act
            var actual = DataFactory.CreateKeyValueDataTableOfIntString(dropDownFirstItemType);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.BeOfType<DataTable>();
            actual.Rows.Cast<DataRow>().Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
        public void CreateKeyValueDataTableOfGuidString_DropDownFirstItemType(int expectedCount, DropDownFirstItemType dropDownFirstItemType)
        {
            // Act
            var actual = DataFactory.CreateKeyValueDataTableOfGuidString(dropDownFirstItemType);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.BeOfType<DataTable>();
            actual.Rows.Cast<DataRow>().Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        public void CreateKeyValueDictionaryOfIntString_DropDownFirstItemType(int expectedCount, DropDownFirstItemType dropDownFirstItemType)
        {
            // Act
            var actual = DataFactory.CreateKeyValueDictionaryOfIntString(dropDownFirstItemType);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.BeOfType<Dictionary<int, string>>();
            actual.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        public void CreateKeyValueDictionaryOfGuidString_DropDownFirstItemType(int expectedCount, DropDownFirstItemType dropDownFirstItemType)
        {
            // Act
            var actual = DataFactory.CreateKeyValueDictionaryOfGuidString(dropDownFirstItemType);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.BeOfType<Dictionary<Guid, string>>();
            actual.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        public void CreateKeyValueDictionaryOfStringString_DropDownFirstItemType(int expectedCount, DropDownFirstItemType dropDownFirstItemType)
        {
            // Act
            var actual = DataFactory.CreateKeyValueDictionaryOfStringString(dropDownFirstItemType);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.BeOfType<Dictionary<string, string>>();
            actual.Should().HaveCount(expectedCount);
        }
    }
}