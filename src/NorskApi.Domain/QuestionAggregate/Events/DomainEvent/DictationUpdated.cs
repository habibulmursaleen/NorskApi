using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuestionAggregate.Events.DomainEvent
{
    public record QuestionUpdatedDomainEvent(Question Question) : IDomainEvent;
}

