using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public sealed class SentenceStructureId : ValueObject
{
    private SentenceStructureId() { }

    public Guid Value { get; set; }

    public SentenceStructureId(Guid value)
    {
        this.Value = value;
    }

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
