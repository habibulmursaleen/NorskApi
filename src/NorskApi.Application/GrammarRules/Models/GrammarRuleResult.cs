using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Application.GrammarRules.Models;

public record GrammarRuleResult(
    Guid Id,
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<SentenceStructureResult> SentenceStructures,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<GrammarRuleTagIdResult> GrammarRuleTagIds,
    string? AdditionalInformation,
    List<string>? Comments,
    List<RelatedRuleIdResult> RelatedGrammarRuleIds,
    List<ExceptionResult> Exceptions,
    List<ExampleOfRuleResult> ExampleOfRules,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record SentenceStructureResult(string Label);

public record RelatedRuleIdResult(Guid GrammarRuleId);

public record GrammarRuleTagIdResult(Guid TagId);
