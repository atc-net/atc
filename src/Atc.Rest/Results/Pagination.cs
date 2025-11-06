namespace Atc.Rest.Results;

/// <summary>
/// Represents a paginated collection of items with metadata for navigation.
/// </summary>
/// <typeparam name="T">The type of items in the paginated collection.</typeparam>
/// <remarks>
/// This class supports two pagination models:
/// <list type="bullet">
/// <item>Offset-based pagination using PageIndex and TotalCount</item>
/// <item>Cursor-based pagination using ContinuationToken</item>
/// </list>
/// </remarks>
public class Pagination<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pagination{T}"/> class.
    /// </summary>
    /// <remarks>
    /// This parameterless constructor is provided for serialization support.
    /// </remarks>
    public Pagination()
    {
        // Dummy for serialization.
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Pagination{T}"/> class with offset-based pagination.
    /// </summary>
    /// <param name="items">The items for the current page.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="queryString">The original query string from the request.</param>
    /// <param name="pageIndex">The zero-based page index.</param>
    /// <param name="totalCount">The total number of items across all pages.</param>
    public Pagination(
        IEnumerable<T> items,
        int pageSize,
        string? queryString,
        int pageIndex,
        int totalCount)
    {
        ArgumentNullException.ThrowIfNull(items);

        Items = new List<T>(items);
        PageSize = pageSize;
        QueryString = queryString;
        PageIndex = pageIndex;
        TotalCount = totalCount;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Pagination{T}"/> class with cursor-based pagination.
    /// </summary>
    /// <param name="items">The items for the current page.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="queryString">The original query string from the request.</param>
    /// <param name="continuationToken">The continuation token for fetching the next page.</param>
    public Pagination(
        IEnumerable<T> items,
        int pageSize,
        string? queryString,
        string? continuationToken)
    {
        ArgumentNullException.ThrowIfNull(items);

        Items = new List<T>(items);
        PageSize = pageSize;
        QueryString = queryString;
        ContinuationToken = continuationToken;
    }

    /// <summary>
    /// Gets or sets the number of items per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the zero-based page index for offset-based pagination.
    /// </summary>
    public int? PageIndex { get; set; }

    /// <summary>
    /// Gets or sets the original query string from the request.
    /// </summary>
    public string? QueryString { get; set; }

    /// <summary>
    /// Gets or sets the continuation token for cursor-based pagination.
    /// </summary>
    public string? ContinuationToken { get; set; }

    /// <summary>
    /// Gets the number of items in the current page.
    /// </summary>
    public int Count => Items?.Count ?? 0;

    /// <summary>
    /// Gets or sets the total number of items across all pages (for offset-based pagination).
    /// </summary>
    public int? TotalCount { get; set; }

    /// <summary>
    /// Gets the total number of pages based on TotalCount and PageSize.
    /// </summary>
    public int? TotalPages => TotalCount is null
        ? default(int?)
        : (int)System.Math.Ceiling((double)TotalCount / PageSize);

    /// <summary>
    /// Gets or sets the items for the current page.
    /// </summary>
    public IReadOnlyList<T>? Items { get; set; } = Array.Empty<T>();

    /// <inheritdoc />
    public override string ToString()
        => string.Create(CultureInfo.InvariantCulture, $"{nameof(PageIndex)}: {PageIndex}, {nameof(PageSize)}: {PageSize}, {nameof(QueryString)}: {QueryString}, {nameof(ContinuationToken)}: {ContinuationToken}, {nameof(Count)}: {Count}, {nameof(TotalCount)}: {TotalCount}, {nameof(TotalPages)}: {TotalPages}");
}