using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQueryParamsWithEssayBuilder
{
    IQueryable<T>? BuildQueriesDictations<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesPodcasts<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesWords<T>(QueryParamsWithEssayFilters filters);
}
