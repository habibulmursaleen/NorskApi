using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Response;

public record GrammarRuleResponse(
    Guid Id,
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
    List<ExceptionResponse>? Exceptions,
    List<ExampleOfRuleResponse>? ExampleOfRules,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
