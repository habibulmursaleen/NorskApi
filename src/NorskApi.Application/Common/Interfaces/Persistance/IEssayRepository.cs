using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IEssayRepository
{
    Task<List<Essay>> GetAll(QueryParamsBaseFilters? filters, CancellationToken cancellationToken);
    Task<Essay?> GetById(EssayId essayId, CancellationToken cancellationToken);
    Task Add(Essay essay, CancellationToken cancellationToken);
    Task Update(Essay essay, CancellationToken cancellationToken);
    Task Delete(Essay essay, CancellationToken cancellationToken);
}
