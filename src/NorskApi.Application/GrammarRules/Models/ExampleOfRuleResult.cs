using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Application.GrammarRules.Models;

public record ExampleOfRuleResult(
    Guid Id,
    Guid GrammarRuleId,
    string? Subjunction,
    string? Subject,
    string? Adverbial,
    string? Verb,
    string? Object,
    string? Rest,
    string? CorrectSentence,
    string? EnglishSentence,
    string? IncorrectSentence,
    string? TransformationFrom,
    string? TransformationTo,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
