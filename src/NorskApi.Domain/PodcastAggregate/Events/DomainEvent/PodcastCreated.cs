using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.PodcastAggregate.Events.DomainEvent
{
    public record PodcastCreatedDomainEvent(Podcast Podcast) : IDomainEvent;
}

