using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class ExceptionId : AggregateRootId<Guid>
{
    private ExceptionId()
    {
    }

    private ExceptionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(ExceptionId data) => data.Value;

    public static ExceptionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ExceptionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
