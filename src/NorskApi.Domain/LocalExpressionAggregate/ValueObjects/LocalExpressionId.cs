using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

public sealed class LocalExpressionId : AggregateRootId<Guid>
{
    private LocalExpressionId()
    {
    }

    private LocalExpressionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(LocalExpressionId data) => data.Value;

    public static LocalExpressionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static LocalExpressionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
