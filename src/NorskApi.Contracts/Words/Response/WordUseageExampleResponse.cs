namespace NorskApi.Contracts.Words.Response;

public record WordUseageExampleResponse(
    Guid Id,
    Guid WordId,
    string CorrectSentence,
    string IncorrectSentence,
    string EnglishSentence,
    string NewSentence,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
