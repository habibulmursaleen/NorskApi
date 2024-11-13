using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;

public interface IQueryParamsWithEssayBuilder
{
    IQueryable<T>? BuildQueriesQuestions<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesDictations<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesPodcasts<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesWords<T>(QueryParamsWithEssayFilters filters);
    IQueryable<T>? BuildQueriesDiscussions<T>(QueryParamsWithEssayFilters filters);
}
