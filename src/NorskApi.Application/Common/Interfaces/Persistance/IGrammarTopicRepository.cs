using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IGrammarTopicRepository
{
    Task<List<GrammarTopic>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    );
    Task<GrammarTopic?> GetById(TopicId topicId, CancellationToken cancellationToken);
    Task Add(GrammarTopic grammarTopic, CancellationToken cancellationToken);
    Task Update(GrammarTopic grammarTopic, CancellationToken cancellationToken);
    Task Delete(GrammarTopic grammarTopic, CancellationToken cancellationToken);
}
