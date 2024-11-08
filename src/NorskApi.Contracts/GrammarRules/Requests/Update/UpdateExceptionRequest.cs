namespace NorskApi.Contracts.GrammarRules.Requests.Update;

public record UpdateExceptionRequest(
    Guid Id,
    Guid GrammarRuleId,
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);
