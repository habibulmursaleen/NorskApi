using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class SentenceStructureId : AggregateRootId<Guid>
{
    private SentenceStructureId() { }

    private SentenceStructureId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(SentenceStructureId data) => data.Value;

    public static SentenceStructureId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SentenceStructureId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
