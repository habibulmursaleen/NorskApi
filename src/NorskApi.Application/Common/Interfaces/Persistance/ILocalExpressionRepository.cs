using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface ILocalExpressionRepository
{
    Task<List<LocalExpression>> GetAll(CancellationToken cancellationToken);
    Task<LocalExpression?> GetById(LocalExpressionId localExpressionId, CancellationToken cancellationToken);
    Task Add(LocalExpression localExpression, CancellationToken cancellationToken);
    Task Update(LocalExpression localExpression, CancellationToken cancellationToken);
    Task Delete(LocalExpression localExpression, CancellationToken cancellationToken);
}