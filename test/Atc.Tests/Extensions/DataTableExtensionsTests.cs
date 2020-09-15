using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Atc.Tests.XUnitTestTypes;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class DataTableExtensionsTests
    {
        [Theory]
        [InlineData(6, "Patient", SortDirectionType.Ascending)]
        [InlineData(6, "Patient", SortDirectionType.Descending)]
        public void SortTable(int expected, string sortOnColumn, SortDirectionType sortDirection)
        {
            // Arrange
            var dt = GenerateTestTable();

            // Act
            var actual = dt.SortTable(sortOnColumn, sortDirection);
            dt.Dispose();

            // Assert
            actual.Should().NotBeNull().And.BeOfType<DataTable>();
            actual.Rows.Should().HaveCount(expected);
            var sortOnColumnArray = (
                from DataRow row
                    in actual.Rows
                select row[sortOnColumn].ToString())
                .ToArray();
            if (sortDirection == SortDirectionType.Ascending)
            {
                sortOnColumnArray.Should().Equal("Brian", "Christoff", "David", "Janet", "Melanie", "Sam");
            }
            else
            {
                sortOnColumnArray.Should().Equal("Sam", "Melanie", "Janet", "David", "Christoff", "Brian");
            }
        }

        [Theory]
        [InlineData(6, "", "")]
        [InlineData(2, "Drug='Hydralazine'", "")]
        [InlineData(6, "", "Drug")]
        [InlineData(1, "Drug='Indocin'", "Patient")]
        [InlineData(2, "Drug='Hydralazine'", "Patient")]
        public void FilterTable(int expected, string filterExpression, string sortExpression)
        {
            // Arrange
            var dt = GenerateTestTable();

            // Act
            var actual = dt.FilterTable(filterExpression, sortExpression);
            dt.Dispose();

            // Assert
            actual.Should().NotBeNull().And.BeOfType<DataTable>();
            actual.Rows.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(6, "Patient")]
        [InlineData(5, "Drug")]
        public void GetGroupCount(int expected, string countOnColumn)
        {
            // Arrange
            var dt = GenerateTestTable();

            // Act
            var actual = dt.GetGroupCount(countOnColumn);
            dt.Dispose();

            // Assert
            actual.Should().NotBeNull().And.BeOfType<Dictionary<string, int>>();
            actual.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(6)]
        public void ToCollection(int expected)
        {
            // Arrange
            var dt = GenerateTestTable();

            // Act
            var actual = dt.ToCollection<TestItem>();
            dt.Dispose();

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<TestItem>>()
                .And.HaveCount(expected);
        }

        [Fact]
        public void ToXPathNodeIterator()
        {
            // Arrange
            var dt = GenerateTestTable();

            // Act
            var actual = dt.ToXPathNodeIterator();
            dt.Dispose();

            // Assert
            actual.Should().NotBeNull();
        }

        private static DataTable GenerateTestTable()
        {
            var table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Brian", DateTime.Now);

            return table;
        }
    }
}