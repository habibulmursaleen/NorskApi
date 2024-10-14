using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.PodcastAggregate.ValueObjects;
public sealed class PodcastId : AggregateRootId<Guid>
{
    private PodcastId()
    {
    }

    private PodcastId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(PodcastId data) => data.Value;

    public static PodcastId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PodcastId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
