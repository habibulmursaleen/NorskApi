using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.LocalExpressionAggregate.Events.DomainEvent
{
    public record LocalExpressionUpdatedDomainEvent(LocalExpression LocalExpression) : IDomainEvent;
}

