using NorskApi.Domain.Common.Models;
using NorskApi.Domain.TagAggregate.Enums;
using NorskApi.Domain.TagAggregate.Events.DomainEvent;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Domain.TagAggregate;

public sealed class Tag : AggregateRoot<TagId, Guid>
{
    public string Label { get; set; }
    public string Color { get; set; }
    public TagType TagType { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Tag() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Tag(TagId TagId, string label, string color, TagType tagType)
        : base(TagId)
    {
        this.Label = label;
        this.Color = color;
        this.TagType = tagType;
    }

    public static Tag Create(string label, string color, TagType tagType)
    {
        Tag tag = new Tag(TagId.CreateUnique(), label, color, tagType);

        tag.AddDomainEvent(new TagCreatedDomainEvent(tag));

        return tag;
    }

    public void Update(string label, string color, TagType tagType)
    {
        this.Label = label;
        this.Color = color;
        this.TagType = tagType;

        this.AddDomainEvent(new TagUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new TagDeletedDomainEvent(this));
    }
}
