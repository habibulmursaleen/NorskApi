using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Requests.Create;

public record CreateGrammarRuleRequest(
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<string>? SentenceStructure,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<string>? Tags,
    string? AdditionalInformation,
    List<string>? Comments,
    List<Guid>? RelatedRuleIds,
    List<CreateExceptionRequest>? Exceptions,
    List<CreateExampleOfRuleRequest>? ExampleOfRules
);
