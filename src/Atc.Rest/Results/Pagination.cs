using System;
using System.Collections.Generic;

namespace Atc.Rest.Results
{
    public class Pagination<T>
    {
        public Pagination()
        {
            // Dummy for serialization.
        }

        public Pagination(IEnumerable<T> items, int pageSize, string? queryString, int pageIndex, int totalCount)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = new List<T>(items);
            PageSize = pageSize;
            QueryString = queryString;
            PageIndex = pageIndex;
            TotalCount = totalCount;
        }

        public Pagination(IEnumerable<T> items, int pageSize, string? queryString, string? continuationToken)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = new List<T>(items);
            PageSize = pageSize;
            QueryString = queryString;
            ContinuationToken = continuationToken;
        }

        public int PageSize { get; set; }

        public int? PageIndex { get; set; }

        public string? QueryString { get; set; }

        public string? ContinuationToken { get; set; }

        public int Count => Items?.Count ?? 0;

        public int? TotalCount { get; set; }

        public int? TotalPages => TotalCount is null
            ? default(int?)
            : (int)System.Math.Ceiling((double)(TotalCount / PageSize));

        public IReadOnlyList<T>? Items { get; set; } = Array.Empty<T>();

        public override string ToString()
            => FormattableString.Invariant($"{nameof(PageIndex)}: {PageIndex}, {nameof(PageSize)}: {PageSize}, {nameof(QueryString)}: {QueryString}, {nameof(ContinuationToken)}: {ContinuationToken}, {nameof(Count)}: {Count}, {nameof(TotalCount)}: {TotalCount}, {nameof(TotalPages)}: {TotalPages}");
    }
}