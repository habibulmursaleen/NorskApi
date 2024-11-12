using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Response;

public record GrammarRuleResponse(
    Guid Id,
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<SentenceStructureResponse> SentenceStructures,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<GrammarRuleTagIdsResponse> GrammarRuleTagIds,
    string? AdditionalInformation,
    List<string>? Comments,
    List<RelatedGramarRuleIdsResponse> RelatedGrammarRuleIds,
    List<ExceptionResponse>? Exceptions,
    List<ExampleOfRuleResponse>? ExampleOfRules,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record SentenceStructureResponse(string Label);

public record RelatedGramarRuleIdsResponse(Guid GrammarRuleId);

public record GrammarRuleTagIdsResponse(Guid TagId);
