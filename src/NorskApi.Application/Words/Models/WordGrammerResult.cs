namespace NorskApi.Application.GrammarRules.Models;

public record WordGrammerResult(
    Guid Id,
    Guid? WordId,
    string? GenderMasculine,
    string? GenderFeminine,
    string? GenderNeutral,
    string? SingularDefinitiv,
    string? SingularIndefinitiv,
    string? PluralDefinitiv,
    string? PluralIndefinitiv,
    string? Infinitiv,
    string? PresentTense,
    string? PastTense,
    string? PresentPerfectTense,
    string? FutureTense,
    string? Positive,
    string? Comparative,
    string? Superlative,
    string? SuperlativeDetermined,
    string? PastParticiple,
    string? PresentParticiple,
    bool? Irregular,
    bool? StrongVerb,
    bool? WeakVerb,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
