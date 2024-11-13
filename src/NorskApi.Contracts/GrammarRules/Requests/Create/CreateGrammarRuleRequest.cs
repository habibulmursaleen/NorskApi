using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Requests.Create;

public record CreateGrammarRuleRequest(
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<CreateGrammarRuleTagIdsRequest>? GrammarRuleTagIds,
    string? AdditionalInformation,
    List<string>? Comments,
    List<CreateRelatedGramarRuleIdsRequest>? RelatedGrammarRuleIds,
    List<CreateSentenceStructureRequest> SentenceStructures,
    List<CreateExceptionRequest> Exceptions,
    List<CreateExampleOfRuleRequest> ExampleOfRules
);

public record CreateSentenceStructureRequest(string Label);

public record CreateRelatedGramarRuleIdsRequest(Guid GrammarRuleId);

public record CreateGrammarRuleTagIdsRequest(Guid TagId);
