using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.DiscussionAggregate.Events.DomainEvent
{
    public record DiscussionCreatedDomainEvent(Discussion Discussion) : IDomainEvent;
}

