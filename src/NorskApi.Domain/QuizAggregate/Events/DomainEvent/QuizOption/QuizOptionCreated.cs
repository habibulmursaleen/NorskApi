using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.Events.DomainEvent.QuizOption
{
    public record QuizOptionCreatedDomainEvent(NorskApi.Domain.QuizAggregate.Entites.QuizOption QuizOption) : IDomainEvent;
}
