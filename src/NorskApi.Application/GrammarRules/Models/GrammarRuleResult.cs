using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Application.GrammarRules.Models;

public record GrammarRuleResult(
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
    List<GrammarRuleId>? RelatedRuleIds,
    List<ExceptionResult>? Exceptions,
    List<ExampleOfRuleResult>? ExampleOfRules,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
