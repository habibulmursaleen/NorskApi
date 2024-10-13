using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.Events.DomainEvent.AdditionalContent;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.EssayAggregate.Entities;

public sealed class AdditionalContent : AggregateRoot<AdditionalContentId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private AdditionalContent() { }

    private AdditionalContent(
        AdditionalContentId id,
        EssayId? essayId,
        string? content,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id)
    {
        this.Id = id;
        this.EssayId = essayId;
        this.Content = content;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static AdditionalContent Create(
        EssayId? essayId,
        string? content,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        AdditionalContent additionalContent = new AdditionalContent(
            AdditionalContentId.CreateUnique(),
            essayId,
            content,
            createdAt,
            updatedAt
        );

        additionalContent.AddDomainEvent(new AdditionalContentCreatedDomainEvent(additionalContent));

        return additionalContent;
    }

    public void Update(
        EssayId? essayId,
        string? content,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Content = content;
        this.UpdatedAt = updatedAt;
    }

    public void Delete()
    {
        this.AddDomainEvent(new AdditionalContentDeletedDomainEvent(this));
    }

}
