using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.Entities.QuizAggregate.Events.DomainEvent
{
    public record QuizDeletedDomainEvent(NorskApi.Domain.QuizAggregate.Quiz Quiz) : IDomainEvent;
}

