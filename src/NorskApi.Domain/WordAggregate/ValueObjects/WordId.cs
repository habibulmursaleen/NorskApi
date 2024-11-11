using System.Text.Json.Serialization;
using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.WordAggregate.ValueObjects;

public sealed class WordId : AggregateRootId<Guid>
{
    private WordId() { }

    [JsonConstructor]
    private WordId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(WordId data) => data.Value;

    public static WordId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static WordId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
