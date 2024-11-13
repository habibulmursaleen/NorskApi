using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Requests.Update;

public record UpdateGrammarRuleRequest(
    Guid Id,
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<UpdateSentenceStructureRequest> SentenceStructures,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<UpdateGrammarRuleTagIdsRequest> GrammarRuleTagIds,
    string? AdditionalInformation,
    List<string>? Comments,
    List<UpdateRelatedGramarRuleIdsRequest> RelatedGrammarRuleIds,
    List<UpdateExceptionRequest>? Exceptions,
    List<UpdateExampleOfRuleRequest>? ExampleOfRules
);

public record UpdateSentenceStructureRequest(string Label);

public record UpdateRelatedGramarRuleIdsRequest(Guid GrammarRuleId);

public record UpdateGrammarRuleTagIdsRequest(Guid TagId);
