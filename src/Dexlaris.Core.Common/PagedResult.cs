using Sieve.Models;

namespace Dexlaris.Core.Common;

public class PagedResult<T>
    where T : class
{
    public PagedResult()
    {
    }

    public PagedResult(SieveModel request, int totalCount)
    {
        request.PageSize ??= 15;

        PageSize = request.PageSize.Value;
        OrderBy = request.Sorts;
        TotalCount = totalCount;
        TotalPagesCount = (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public string OrderBy { get; set; } = string.Empty;

    public int TotalCount { get; set; }

    public int TotalPagesCount { get; set; }

    public int Count => Data.Count;

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPagesCount;

    public List<T> Data { get; set; } = [];
}