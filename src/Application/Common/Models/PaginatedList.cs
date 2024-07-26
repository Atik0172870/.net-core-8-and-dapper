namespace CardAccess.Application.Common.Models;

// Represents a paginated list of items.
public class PaginatedList<T>(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
{
    // Gets the collection of items on the current page.
    public IReadOnlyCollection<T> Items { get; } = items;

    // Gets the current page number.
    public int PageNumber { get; } = pageNumber;

    // Gets the total number of pages.
    public int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);

    // Gets the total number of items.
    public int TotalCount { get; } = count;

    // Indicates whether there is a previous page.
    public bool HasPreviousPage => PageNumber > 1;

    // Indicates whether there is a next page.
    public bool HasNextPage => PageNumber < TotalPages;

    // Creates a paginated list asynchronously from the provided IQueryable source.
    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
}
