using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.Events.DomainEvent.Quiz
{
    public record QuizCreatedDomainEvent(NorskApi.Domain.QuizAggregate.Quiz Quiz) : IDomainEvent;
}

