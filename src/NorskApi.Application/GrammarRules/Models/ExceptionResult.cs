namespace NorskApi.Application.GrammarRules.Models;

public record ExceptionResult(
    Guid Id,
    Guid GrammarRuleId,
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
