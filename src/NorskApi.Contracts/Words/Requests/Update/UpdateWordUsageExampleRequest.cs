namespace NorskApi.Contracts.Words.Requests.Update;

public record UpdateWordUsageExampleRequest(
    Guid Id,
    Guid WordId,
    string CorrectSentence,
    string IncorrectSentence,
    string EnglishSentence,
    string NewSentence
);
