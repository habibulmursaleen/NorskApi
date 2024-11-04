using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQueryParamsWithEssayBuilder
{
    IQueryable<T>? BuildQueries<T>(QueryParamsWithEssayFilters filters);
}
