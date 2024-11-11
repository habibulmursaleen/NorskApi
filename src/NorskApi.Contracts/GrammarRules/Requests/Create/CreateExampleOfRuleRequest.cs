using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Quizes.Common.Enums;

namespace NorskApi.Contracts.GrammarRules.Requests.Create;

public record CreateExampleOfRuleRequest(
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
