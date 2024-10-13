using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.Events.DomainEvent.QuizOption
{
    public record QuizOptionUpdatedDomainEvent(NorskApi.Domain.QuizAggregate.Entites.QuizOption QuizOption) : IDomainEvent;
}

