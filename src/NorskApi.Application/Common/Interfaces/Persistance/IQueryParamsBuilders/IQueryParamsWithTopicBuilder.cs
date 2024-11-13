using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;

public interface IQueryParamsWithTopicBuilder
{
    IQueryable<T>? BuildQueriesTaskWorks<T>(QueryParamsWithTopicFilters filters);
}
