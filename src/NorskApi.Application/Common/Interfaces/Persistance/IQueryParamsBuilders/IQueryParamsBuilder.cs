using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;

public interface IQueryParamsBaseBuilder
{
    IQueryable<T>? BuildQueriesRoleplays<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesGrammarTopics<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesEssays<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesGrammarRules<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesNorskproves<T>(QueryParamsBaseFilters filters);
}
