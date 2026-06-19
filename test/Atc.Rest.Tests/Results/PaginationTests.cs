namespace Atc.Rest.Tests.Results;

public class PaginationTests
{
    private Fixture Fixture { get; } = new();

    [Fact]
    public void Ctor_Copies_Items_To_Pagination()
    {
        // Arrange
        var data = Fixture.Create<List<string>>();
        var sut = new Pagination<string>(items: data, pageSize: 5, queryString: null, continuationToken: null);

        // Act
        data.Add(Fixture.Create<string>());

        // Assert
        sut.Count.Should().Be(data.Count - 1);
        sut.Items.Should().NotContain(data[^1]);
    }

    [Theory]
    [InlineData(2, 3, 5, 3)]
    [InlineData(3, 3, 9, 3)]
    [InlineData(1, 10, 9, 9)]
    [InlineData(1, 10, 10, 9)]
    [InlineData(2, 10, 11, 9)]
    [InlineData(2, 10, 11, 10)]
    [InlineData(2, 10, 11, 11)]
    public void Calculate_TotalPages(
        int expectedTotalPages,
        int pageSize,
        int elementsToCreate,
        int elementsToTake)
    {
        // Arrange
        var data = Fixture
            .CreateMany<int>(elementsToCreate)
            .ToList();

        // Act
        var actual = new Pagination<int>(items: data.Take(elementsToTake), pageSize, queryString: null, continuationToken: null)
        {
            TotalCount = data.Count,
        };

        // Assert
        Assert.Equal(expectedTotalPages, actual.TotalPages);
    }

    [Fact]
    public void TotalPages_IsNull_When_PageSize_Is_Zero()
    {
        // Arrange
        var sut = new Pagination<int>(items: Array.Empty<int>(), pageSize: 0, queryString: null, continuationToken: null)
        {
            TotalCount = 10,
        };

        // Act & Assert - guards against the divide-by-zero that produced a garbage page count.
        sut.TotalPages.Should().BeNull();
    }
}