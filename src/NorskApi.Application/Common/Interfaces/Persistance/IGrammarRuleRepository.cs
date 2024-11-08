using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IGrammarRuleRepository
{
    Task<List<GrammarRule>> GetAll(
        QueryParamsWithTopicFilters? filters,
        CancellationToken cancellationToken
    );
    Task<List<GrammarRule>> GetAllByTopicId(
        TopicId topicId,
        QueryParamsWithTopicFilters filters,
        CancellationToken cancellationToken
    );
    Task<GrammarRule?> GetById(
        TopicId topicId,
        GrammarRuleId grammarRuleId,
        CancellationToken cancellationToken
    );
    Task Add(GrammarRule grammarRule, CancellationToken cancellationToken);
    Task Update(GrammarRule grammarRule, CancellationToken cancellationToken);
    Task Delete(GrammarRule grammarRule, CancellationToken cancellationToken);
}
