using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.LocalExpressionAggregate.Events.DomainEvent
{
    public record LocalExpressionCreatedDomainEvent(LocalExpression LocalExpression) : IDomainEvent;
}

