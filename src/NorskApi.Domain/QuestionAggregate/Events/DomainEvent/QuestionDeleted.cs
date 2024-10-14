using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuestionAggregate.Events.DomainEvent
{
    public record QuestionDeletedDomainEvent(Question Question) : IDomainEvent;
}

