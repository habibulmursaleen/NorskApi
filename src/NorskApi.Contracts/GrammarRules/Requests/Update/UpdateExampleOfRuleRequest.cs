namespace NorskApi.Contracts.GrammarRules.Requests.Update;

public record UpdateExampleOfRuleRequest(
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
    string? TransformationTo
);
