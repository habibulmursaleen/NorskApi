using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IQuestionRepository
{
    Task<List<Question>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    );

    Task<Question?> GetById(QuestionId questionId, CancellationToken cancellationToken);
    Task Add(Question question, CancellationToken cancellationToken);
    Task Update(Question question, CancellationToken cancellationToken);
    Task Delete(Question question, CancellationToken cancellationToken);
}
