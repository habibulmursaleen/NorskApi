using NorskApi.Application.Common.QueryParams;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQueryParamsBuilder
{
    IQueryable<T>? BuildQueries<T>(GetAllDiscussionsFiltersQuery filters);
}
