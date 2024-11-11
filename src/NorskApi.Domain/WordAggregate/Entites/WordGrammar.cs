using NorskApi.Domain.Common.Models;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Domain.WordAggregate.Entites;

public sealed class WordGrammer : Entity<WordGrammarId>
{
    public WordId? WordId_FK { get; set; }
    public string? GenderMasculine { get; set; }
    public string? GenderFeminine { get; set; }
    public string? GenderNeutral { get; set; }
    public string? SingularDefinitiv { get; set; }
    public string? SingularIndefinitiv { get; set; }
    public string? PluralDefinitiv { get; set; }
    public string? PluralIndefinitiv { get; set; }
    public string? Infinitiv { get; set; }
    public string? PresentTense { get; set; }
    public string? PastTense { get; set; }
    public string? PresentPerfectTense { get; set; }
    public string? FutureTense { get; set; }
    public string? Positive { get; set; }
    public string? Comparative { get; set; }
    public string? Superlative { get; set; }
    public string? SuperlativeDetermined { get; set; }
    public string? PastParticiple { get; set; }
    public string? PresentParticiple { get; set; }
    public bool? Irregular { get; set; }
    public bool? StrongVerb { get; set; }
    public bool? WeakVerb { get; set; }

    private WordGrammer() { }

    private WordGrammer(
        WordGrammarId id,
        WordId? wordId_FK,
        string? genderMasculine,
        string? genderFeminine,
        string? genderNeutral,
        string? singularDefinitiv,
        string? singularIndefinitiv,
        string? pluralDefinitiv,
        string? pluralIndefinitiv,
        string? infinitiv,
        string? presentTense,
        string? pastTense,
        string? presentPerfectTense,
        string? futureTense,
        string? positive,
        string? comparative,
        string? superlative,
        string? superlativeDetermined,
        string? pastParticiple,
        string? presentParticiple,
        bool? irregular,
        bool? strongVerb,
        bool? weakVerb
    )
        : base(id)
    {
        this.WordId_FK = wordId_FK;
        this.GenderMasculine = genderMasculine;
        this.GenderFeminine = genderFeminine;
        this.GenderNeutral = genderNeutral;
        this.SingularDefinitiv = singularDefinitiv;
        this.SingularIndefinitiv = singularIndefinitiv;
        this.PluralDefinitiv = pluralDefinitiv;
        this.PluralIndefinitiv = pluralIndefinitiv;
        this.Infinitiv = infinitiv;
        this.PresentTense = presentTense;
        this.PastTense = pastTense;
        this.PresentPerfectTense = presentPerfectTense;
        this.FutureTense = futureTense;
        this.Positive = positive;
        this.Comparative = comparative;
        this.Superlative = superlative;
        this.SuperlativeDetermined = superlativeDetermined;
        this.PastParticiple = pastParticiple;
        this.PresentParticiple = presentParticiple;
        this.Irregular = irregular;
        this.StrongVerb = strongVerb;
        this.WeakVerb = weakVerb;
    }

    public static WordGrammer Create(
        WordId? wordId,
        string? genderMasculine,
        string? genderFeminine,
        string? genderNeutral,
        string? singularDefinitiv,
        string? singularIndefinitiv,
        string? pluralDefinitiv,
        string? pluralIndefinitiv,
        string? infinitiv,
        string? presentTense,
        string? pastTense,
        string? presentPerfectTense,
        string? futureTense,
        string? positive,
        string? comparative,
        string? superlative,
        string? superlativeDetermined,
        string? pastParticiple,
        string? presentParticiple,
        bool? irregular,
        bool? strongVerb,
        bool? weakVerb
    )
    {
        WordGrammer wordGrammer = new WordGrammer(
            WordGrammarId.CreateUnique(),
            wordId,
            genderMasculine,
            genderFeminine,
            genderNeutral,
            singularDefinitiv,
            singularIndefinitiv,
            pluralDefinitiv,
            pluralIndefinitiv,
            infinitiv,
            presentTense,
            pastTense,
            presentPerfectTense,
            futureTense,
            positive,
            comparative,
            superlative,
            superlativeDetermined,
            pastParticiple,
            presentParticiple,
            irregular,
            strongVerb,
            weakVerb
        );

        return wordGrammer;
    }

    public void Update(
        string? genderMasculine,
        string? genderFeminine,
        string? genderNeutral,
        string? singularDefinitiv,
        string? singularIndefinitiv,
        string? pluralDefinitiv,
        string? pluralIndefinitiv,
        string? infinitiv,
        string? presentTense,
        string? pastTense,
        string? presentPerfectTense,
        string? futureTense,
        string? positive,
        string? comparative,
        string? superlative,
        string? superlativeDetermined,
        string? pastParticiple,
        string? presentParticiple,
        bool? irregular,
        bool? strongVerb,
        bool? weakVerb
    )
    {
        this.GenderMasculine = genderMasculine;
        this.GenderFeminine = genderFeminine;
        this.GenderNeutral = genderNeutral;
        this.SingularDefinitiv = singularDefinitiv;
        this.SingularIndefinitiv = singularIndefinitiv;
        this.PluralDefinitiv = pluralDefinitiv;
        this.PluralIndefinitiv = pluralIndefinitiv;
        this.Infinitiv = infinitiv;
        this.PresentTense = presentTense;
        this.PastTense = pastTense;
        this.PresentPerfectTense = presentPerfectTense;
        this.FutureTense = futureTense;
        this.Positive = positive;
        this.Comparative = comparative;
        this.Superlative = superlative;
        this.SuperlativeDetermined = superlativeDetermined;
        this.PastParticiple = pastParticiple;
        this.PresentParticiple = presentParticiple;
        this.Irregular = irregular;
        this.StrongVerb = strongVerb;
        this.WeakVerb = weakVerb;
    }
}
