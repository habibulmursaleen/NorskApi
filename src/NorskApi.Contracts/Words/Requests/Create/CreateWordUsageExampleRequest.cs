namespace NorskApi.Contracts.Words.Requests.Create;

public record CreateWordUsageExampleRequest(
    string CorrectSentence,
    string IncorrectSentence,
    string EnglishSentence,
    string NewSentence
);
