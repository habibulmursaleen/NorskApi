using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;

public sealed class RoleplayId : AggregateRootId<Guid>
{
    private RoleplayId() { }

    private RoleplayId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(RoleplayId data) => data.Value;

    public static RoleplayId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static RoleplayId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
