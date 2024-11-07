using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQuizRepository
{
    Task<List<Quiz>> GetAll(QuizQueryParamsFilters? filters, CancellationToken cancellationToken);
    Task<Quiz?> GetById(QuizId quizId, CancellationToken cancellationToken);
    Task Add(Quiz quiz, CancellationToken cancellationToken);
    Task Update(Quiz quiz, CancellationToken cancellationToken);
    Task Delete(Quiz quiz, CancellationToken cancellationToken);
}
