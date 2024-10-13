using NorskApi.Domain.Common.Models;
using NorskApi.Domain.WordAggregate;

namespace NorskApi.Domain.Entities.WordAggregate.Events.DomainEvent
{
    public record WordCreatedDomainEvent(Word Word) : IDomainEvent;
}

