namespace NorskApi.Contracts.GrammarRules.Response;

public record ExceptionResponse(
    Guid Id,
    Guid GrammarRuleId,
    string Title,
    string Description,
    string Comments,
    string CorrectSentence,
    string IncorrectSentence,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
