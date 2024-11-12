using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;

public interface ITagsQueryParamsBuilder
{
    IQueryable<T>? BuildQueriesTags<T>(TagsQueryParamsFilters filters);
}
