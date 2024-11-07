using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.Enums;
using NorskApi.Domain.EssayAggregate.Events.DomainEvent.Paragraph;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.EssayAggregate.Entities;

public sealed class Paragraph : AggregateRoot<ParagraphId, Guid>
{
    public string? Title { get; set; }
    public string Content { get; set; }
    public ContentType ContentType { get; set; } // Enum: RELATED, ADDITIONAL
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Paragraph() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Paragraph(ParagraphId id, string? title, string content, ContentType contentType)
        : base(id)
    {
        this.Id = id;
        this.Title = title;
        this.Content = content;
        this.ContentType = contentType;
    }

    public static Paragraph Create(string? title, string content, ContentType contentType)
    {
        Paragraph paragraph = new Paragraph(
            ParagraphId.CreateUnique(),
            title,
            content,
            contentType
        );

        paragraph.AddDomainEvent(new ParagraphCreatedDomainEvent(paragraph));

        return paragraph;
    }

    public void Update(string? title, string content, ContentType contentType)
    {
        this.Title = title;
        this.Content = content;
        this.ContentType = contentType;

        this.AddDomainEvent(new ParagraphUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new ParagraphDeletedDomainEvent(this));
    }
}
