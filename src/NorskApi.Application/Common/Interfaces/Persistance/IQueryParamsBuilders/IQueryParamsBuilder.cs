using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQueryParamsBaseBuilder
{
    IQueryable<T>? BuildQueriesDiscussions<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesQuestions<T>(QueryParamsBaseFilters filters);
    IQueryable<T>? BuildQueriesRoleplays<T>(QueryParamsBaseFilters filters);
}
