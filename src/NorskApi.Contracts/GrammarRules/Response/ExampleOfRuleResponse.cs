namespace NorskApi.Contracts.GrammarRules.Response;

public record ExampleOfRuleResponse(
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
