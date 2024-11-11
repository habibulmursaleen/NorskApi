namespace NorskApi.Contracts.GrammarRules.Requests.Create;

public record CreateExceptionRequest(
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);
