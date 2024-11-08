using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.Exception;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Domain.GrammmarRuleAggregate.Entites;

public sealed class Exception : Entity<ExceptionId>
{
    public GrammarRuleId GrammarRuleId_FK { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Comments { get; set; }
    public string? CorrectSentence { get; set; }
    public string? IncorrectSentence { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Exception() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Exception(
        ExceptionId id,
        GrammarRuleId grammarRuleId_FK,
        string? title,
        string? description,
        string? comments,
        string? correctSentence,
        string? incorrectSentence
    )
        : base(id)
    {
        this.GrammarRuleId_FK = grammarRuleId_FK;
        this.Title = title;
        this.Description = description;
        this.Comments = comments;
        this.CorrectSentence = correctSentence;
        this.IncorrectSentence = incorrectSentence;
    }

    public static Exception Create(
        GrammarRuleId grammarRuleId_FK,
        string? title,
        string? description,
        string? comments,
        string? correctSentence,
        string? incorrectSentence
    )
    {
        Exception exception = new Exception(
            ExceptionId.CreateUnique(),
            grammarRuleId_FK,
            title,
            description,
            comments,
            correctSentence,
            incorrectSentence
        );

        exception.AddDomainEvent(new ExceptionCreatedDomainEvent(exception));

        return exception;
    }

    public void Update(
        GrammarRuleId grammarRuleId_FK,
        string? title,
        string? description,
        string? comments,
        string? correctSentence,
        string? incorrectSentence
    )
    {
        this.GrammarRuleId_FK = grammarRuleId_FK;
        this.Title = title;
        this.Description = description;
        this.Comments = comments;
        this.CorrectSentence = correctSentence;
        this.IncorrectSentence = incorrectSentence;

        AddDomainEvent(new ExceptionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        AddDomainEvent(new ExceptionDeletedDomainEvent(this));
    }
}
