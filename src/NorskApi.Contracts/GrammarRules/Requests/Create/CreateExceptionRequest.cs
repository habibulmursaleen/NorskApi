namespace NorskApi.Contracts.GrammarRules.Requests.Create;

public record CreateExceptionRequest(
    Guid GrammarRuleId,
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);
