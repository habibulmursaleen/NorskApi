using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;

public sealed class ParagraphId : AggregateRootId<Guid>
{
    private ParagraphId() { }

    private ParagraphId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(ParagraphId data) => data.Value;

    public static ParagraphId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ParagraphId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
