using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.WordAggregate.ValueObjects;

public sealed class WordUsageExampleId : ValueObject
{
    public Guid Value { get; set; }

    private WordUsageExampleId() { }

    private WordUsageExampleId(Guid value)
    {
        this.Value = value;
    }

    public static implicit operator Guid(WordUsageExampleId data) => data.Value;

    public static WordUsageExampleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static WordUsageExampleId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
