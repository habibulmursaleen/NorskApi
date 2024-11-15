using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;

public sealed class ParagraphId : ValueObject
{
    private ParagraphId() { }

    public Guid Value { get; set; }

    public ParagraphId(Guid value)
    {
        this.Value = value;
    }

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
