using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface INorskproveRepository
{
    Task<List<Norskprove>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    );
    Task<Norskprove?> GetById(NorskproveId norskproveId, CancellationToken cancellationToken);
    Task Add(Norskprove norskprove, CancellationToken cancellationToken);
    Task Update(Norskprove norskprove, CancellationToken cancellationToken);
    Task Delete(Norskprove norskprove, CancellationToken cancellationToken);
}
