using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.RoleplayAggregate.Events.DomainEvent
{
    public record RoleplayCreatedDomainEvent(Roleplay Roleplay) : IDomainEvent;
}

