using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.DiscussionAggregate.Events.DomainEvent
{
    public record DiscussionUpdatedDomainEvent(Discussion Discussion) : IDomainEvent;
}

