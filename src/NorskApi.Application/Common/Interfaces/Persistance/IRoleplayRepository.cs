using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IRoleplayRepository
{
    Task<List<Roleplay>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    );
    Task<List<Roleplay>> GetAllByEssayId(
        EssayId essayId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    );
    Task<Roleplay?> GetById(
        EssayId essayId,
        RoleplayId roleplayId,
        CancellationToken cancellationToken
    );
    Task Add(Roleplay roleplay, CancellationToken cancellationToken);
    Task Update(Roleplay roleplay, CancellationToken cancellationToken);
    Task Delete(Roleplay roleplay, CancellationToken cancellationToken);
}
