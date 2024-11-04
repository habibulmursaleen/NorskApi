using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQueryParamsBaseBuilder
{
    IQueryable<T>? BuildQueries<T>(QueryParamsBaseFilters filters);
}
