using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IDictationRepository
{
    Task<List<Dictation>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    );
    Task<Dictation?> GetById(DictationId DictationId, CancellationToken cancellationToken);
    Task Add(Dictation dictation, CancellationToken cancellationToken);
    Task Update(Dictation dictation, CancellationToken cancellationToken);
    Task Delete(Dictation dictation, CancellationToken cancellationToken);
}
