namespace NorskApi.Application.GrammarRules.Models;

public record WordUsageExampleResult(
    Guid Id,
    Guid? WordId,
    string? CorrectSentence,
    string? IncorrectSentence,
    string? EnglishSentence,
    string? NewSentence,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
