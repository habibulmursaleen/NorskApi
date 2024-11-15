using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;

public sealed class RoleplayId : ValueObject
{
    private RoleplayId() { }

    public Guid Value { get; set; }

    public RoleplayId(Guid value)
    {
        this.Value = value;
    }

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
