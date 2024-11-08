using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.ExmapleOfRule;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Domain.GrammmarRuleAggregate.Entites;

public sealed class ExampleOfRule : Entity<ExampleOfRuleId>
{
    public GrammarRuleId GrammarRuleId_FK { get; set; }
    public string? Subjunction { get; set; }
    public string? Subject { get; set; }
    public string? Adverbial { get; set; }
    public string? Verb { get; set; }
    public string? Object { get; set; }
    public string? Rest { get; set; }
    public string? CorrectSentence { get; set; }
    public string? EnglishSentence { get; set; }
    public string? IncorrectSentence { get; set; }
    public string? TransformationFrom { get; set; }
    public string? TransformationTo { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private ExampleOfRule() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private ExampleOfRule(
        ExampleOfRuleId id,
        GrammarRuleId grammarRuleId_FK,
        string? subjunction,
        string? subject,
        string? adverbial,
        string? verb,
        string? obj,
        string? rest,
        string? correctSentence,
        string? englishSentence,
        string? incorrectSentence,
        string? transformationFrom,
        string? transformationTo
    )
        : base(id)
    {
        this.GrammarRuleId_FK = grammarRuleId_FK;
        this.Subjunction = subjunction;
        this.Subject = subject;
        this.Adverbial = adverbial;
        this.Verb = verb;
        this.Object = obj;
        this.Rest = rest;
        this.CorrectSentence = correctSentence;
        this.EnglishSentence = englishSentence;
        this.IncorrectSentence = incorrectSentence;
        this.TransformationFrom = transformationFrom;
        this.TransformationTo = transformationTo;
    }

    public static ExampleOfRule Create(
        GrammarRuleId grammarRuleId_FK,
        string? subjunction,
        string? subject,
        string? adverbial,
        string? verb,
        string? obj,
        string? rest,
        string? correctSentence,
        string? englishSentence,
        string? incorrectSentence,
        string? transformationFrom,
        string? transformationTo
    )
    {
        ExampleOfRule exampleOfRule = new ExampleOfRule(
            ExampleOfRuleId.CreateUnique(),
            grammarRuleId_FK,
            subjunction,
            subject,
            adverbial,
            verb,
            obj,
            rest,
            correctSentence,
            englishSentence,
            incorrectSentence,
            transformationFrom,
            transformationTo
        );

        exampleOfRule.AddDomainEvent(new ExmapleOfRuleCreatedDomainEvent(exampleOfRule));

        return exampleOfRule;
    }

    public void Update(
        GrammarRuleId grammarRuleId_FK,
        string? subjunction,
        string? subject,
        string? adverbial,
        string? verb,
        string? obj,
        string? rest,
        string? correctSentence,
        string? englishSentence,
        string? incorrectSentence,
        string? transformationFrom,
        string? transformationTo
    )
    {
        this.GrammarRuleId_FK = grammarRuleId_FK;
        this.Subjunction = subjunction;
        this.Subject = subject;
        this.Adverbial = adverbial;
        this.Verb = verb;
        this.Object = obj;
        this.Rest = rest;
        this.CorrectSentence = correctSentence;
        this.EnglishSentence = englishSentence;
        this.IncorrectSentence = incorrectSentence;
        this.TransformationFrom = transformationFrom;
        this.TransformationTo = transformationTo;

        AddDomainEvent(new ExmapleOfRuleUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        AddDomainEvent(new ExmapleOfRuleDeletedDomainEvent(this));
    }
}
