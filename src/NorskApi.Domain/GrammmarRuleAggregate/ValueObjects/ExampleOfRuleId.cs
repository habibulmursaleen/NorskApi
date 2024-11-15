using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class ExampleOfRuleId : ValueObject
{
    private ExampleOfRuleId() { }

    public Guid Value { get; set; }

    public ExampleOfRuleId(Guid value)
    {
        this.Value = value;
    }

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
