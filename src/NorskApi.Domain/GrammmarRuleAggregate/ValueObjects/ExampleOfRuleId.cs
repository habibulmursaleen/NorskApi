using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class ExampleOfRuleId : AggregateRootId<Guid>
{
    private ExampleOfRuleId()
    {
    }

    private ExampleOfRuleId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(ExampleOfRuleId data) => data.Value;

    public static ExampleOfRuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ExampleOfRuleId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
