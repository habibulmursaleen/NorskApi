using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TagAggregate.ValueObjects;

public sealed class TagId : AggregateRootId<Guid>
{
    private TagId() { }

    private TagId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(TagId data) => data.Value;

    public static TagId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TagId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
