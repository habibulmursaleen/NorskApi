using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.Entities.EssayAggregate.Events.DomainEvent
{
    public record EssayCreatedDomainEvent(Essay Essay) : IDomainEvent;
}

