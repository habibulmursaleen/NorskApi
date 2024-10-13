using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.RoleplayAggregate.Events.DomainEvent
{
    public record RoleplayUpdatedDomainEvent(Roleplay Roleplay) : IDomainEvent;
}

