using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.ActivityAggregate.ValueObjects;

public sealed class ActivityId : AggregateRootId<Guid>
{
    private ActivityId() { }

    private ActivityId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(ActivityId data) => data.Value;

    public static ActivityId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ActivityId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
