using System.Text.Json.Serialization;
using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

public sealed class TopicId : AggregateRootId<Guid>
{
    private TopicId() { }

    // [JsonConstructor]
    public TopicId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(TopicId data) => data.Value;

    public static TopicId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TopicId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
