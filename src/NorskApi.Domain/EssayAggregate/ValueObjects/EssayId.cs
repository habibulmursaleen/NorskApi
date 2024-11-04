using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;

public sealed class EssayId : AggregateRootId<Guid>
{
    private EssayId() { }

    private EssayId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(EssayId data) => data.Value;

    public static EssayId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static EssayId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
