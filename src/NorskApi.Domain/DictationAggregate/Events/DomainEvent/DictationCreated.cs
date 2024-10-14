using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.DictationAggregate.Events.DomainEvent
{
    public record DictationCreatedDomainEvent(Dictation Dictation) : IDomainEvent;
}

