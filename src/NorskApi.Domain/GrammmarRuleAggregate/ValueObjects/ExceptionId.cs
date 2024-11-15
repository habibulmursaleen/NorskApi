using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class ExceptionId : ValueObject
{
    private ExceptionId() { }

    public Guid Value { get; set; }

    public ExceptionId(Guid value)
    {
        this.Value = value;
    }

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
