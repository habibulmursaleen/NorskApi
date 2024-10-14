using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.Exception;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Domain.GrammmarRuleAggregate.Entites;

public sealed class Exception : Entity<ExceptionId>
{
    public GrammarRuleId? GrammarRuleId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Comments { get; set; }
    public string? ExampleSentence { get; set; }

    private Exception() { }

    private Exception(
        ExceptionId id,
        GrammarRuleId? grammarRuleId,
        string? title,
        string? description,
        string? comments,
        string? exampleSentence
    ) : base(id)
    {
        this.GrammarRuleId = grammarRuleId;
        this.Title = title;
        this.Description = description;
        this.Comments = comments;
        this.ExampleSentence = exampleSentence;
    }

    public static Exception Create(
        GrammarRuleId? grammarRuleId,
        string? title,
        string? description,
        string? comments,
        string? exampleSentence
    )
    {
        Exception exception = new Exception(
            ExceptionId.CreateUnique(),
            grammarRuleId,
            title,
            description,
            comments,
            exampleSentence
        );

        exception.AddDomainEvent(new ExceptionCreatedDomainEvent(exception));

        return exception;
    }

    public void Update(
        GrammarRuleId? grammarRuleId,
        string? title,
        string? description,
        string? comments,
        string? exampleSentence
    )
    {
        this.GrammarRuleId = grammarRuleId;
        this.Title = title;
        this.Description = description;
        this.Comments = comments;
        this.ExampleSentence = exampleSentence;

        AddDomainEvent(new ExceptionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        AddDomainEvent(new ExceptionDeletedDomainEvent(this));
    }

}