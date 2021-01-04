using System.Collections.Generic;
using System.Linq;
using Atc.Rest.Results;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Atc.Rest.Tests.Results
{
    public class PaginationTests
    {
        private Fixture Fixture { get; } = new Fixture();

        [Fact]
        public void Ctor_Copies_Items_To_Pagination()
        {
            // Arrange
            var data = Fixture.Create<List<string>>();
            var sut = new Pagination<string>(data, 5, null, null);

            // Act
            data.Add(Fixture.Create<string>());

            // Assert
            sut.Count.Should().Be(data.Count - 1);
            sut.Items.Should().NotContain(data.Last());
        }
    }
}
