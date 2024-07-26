using CardAccess.Application.Common.Models;

namespace CardAccess.Application.Common.Mappings;

public static class MappingExtensions
{
    // Creates a paginated list asynchronously from the provided IQueryable source.
    // Parameters:
    //   queryable: The IQueryable source to paginate.
    //   pageNumber: The page number to retrieve.
    //   pageSize: The number of items per page.
    // Returns:
    //   A task representing the asynchronous operation, yielding a PaginatedList<TDestination> instance.
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable,
        int pageNumber,
        int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    // Projects the queryable source to a list of TDestination asynchronously using AutoMapper.
    // Parameters:
    //   queryable: The IQueryable source to project.
    //   configuration: The AutoMapper configuration provider.
    // Returns:
    //   A task representing the asynchronous operation, yielding a list of TDestination instances.
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(
        this IQueryable queryable, 
        IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
