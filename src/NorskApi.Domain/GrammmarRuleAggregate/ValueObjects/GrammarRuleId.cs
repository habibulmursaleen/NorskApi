using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class GrammarRuleId : AggregateRootId<Guid>
{
    private GrammarRuleId()
    {
    }

    private GrammarRuleId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(GrammarRuleId data) => data.Value;

    public static GrammarRuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GrammarRuleId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
