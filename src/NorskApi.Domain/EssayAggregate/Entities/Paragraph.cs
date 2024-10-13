using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.Events.DomainEvent.Paragraph;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.EssayAggregate.Entities;
public sealed class Paragraph : AggregateRoot<ParagraphId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string? Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Paragraph() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Paragraph(
        ParagraphId id,
        EssayId? essayId,
        string? title,
        string content,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id)
    {
        this.Id = id;
        this.EssayId = essayId;
        this.Title = title;
        this.Content = content;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Paragraph Create(
        EssayId? essayId,
        string? title,
        string content,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Paragraph paragraph = new Paragraph(
            ParagraphId.CreateUnique(),
            essayId,
            title,
            content,
            createdAt,
            updatedAt
        );

        paragraph.AddDomainEvent(new ParagraphCreatedDomainEvent(paragraph));

        return paragraph;
    }

    public void Update(
        EssayId? essayId,
        string? title,
        string content,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Title = title;
        this.Content = content;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new ParagraphUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new ParagraphDeletedDomainEvent(this));
    }


}
