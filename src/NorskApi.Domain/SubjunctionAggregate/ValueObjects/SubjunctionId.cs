using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.SubjunctionAggregate.ValueObjects;
public sealed class SubjunctionId : AggregateRootId<Guid>
{
    private SubjunctionId()
    {
    }

    private SubjunctionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(SubjunctionId data) => data.Value;

    public static SubjunctionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SubjunctionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
