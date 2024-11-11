using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IWordRepository
{
    Task<List<Word>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    );

    Task<Word?> GetById(WordId wordId, CancellationToken cancellationToken);
    Task Add(Word word, CancellationToken cancellationToken);
    Task Update(Word word, CancellationToken cancellationToken);
    Task Delete(Word word, CancellationToken cancellationToken);
}
