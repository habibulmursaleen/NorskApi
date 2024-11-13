using NorskApi.Application.Common.QueryParamsBuilder;

namespace NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;

public interface IQuizQueryParamsBuilder
{
    IQueryable<T>? BuildQueriesQuizes<T>(QuizQueryParamsFilters filters);
}
