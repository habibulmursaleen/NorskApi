using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TagAggregate.Events.DomainEvent
{
    public record TagDeletedDomainEvent(Tag Tag) : IDomainEvent;
}
