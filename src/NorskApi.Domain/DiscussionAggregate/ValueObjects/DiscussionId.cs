using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.DiscussionAggregate.ValueObjects;
public sealed class DiscussionId : AggregateRootId<Guid>
{
    private DiscussionId()
    {
    }

    private DiscussionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(DiscussionId data) => data.Value;

    public static DiscussionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DiscussionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
