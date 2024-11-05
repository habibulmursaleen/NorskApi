using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;

namespace NorskApi.Application.Roleplays.Queries.GetAllRoleplays;

public class GetAllRoleplaysQueryHandler
    : IRequestHandler<GetAllRoleplaysQuery, ErrorOr<List<RoleplayResult>>>
{
    private readonly IRoleplayRepository roleplayRepository;

    public GetAllRoleplaysQueryHandler(IRoleplayRepository roleplayRepository)
    {
        this.roleplayRepository = roleplayRepository;
    }

    public async Task<ErrorOr<List<RoleplayResult>>> Handle(
        GetAllRoleplaysQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Roleplay> roleplays = new List<Roleplay>();
        QueryParamsBaseFilters? filters = query.Filters;

        if (query.EssayId == Guid.Empty)
        {
            roleplays = await this.roleplayRepository.GetAll(filters, cancellationToken);
        }
        else
        {
            var essayId = EssayId.Create(query.EssayId ?? Guid.Empty);
            roleplays = await this.roleplayRepository.GetAllByEssayId(
                essayId,
                filters,
                cancellationToken
            );
        }

        List<RoleplayResult> roleplaysResults = roleplays
            .Select(roleplays => new RoleplayResult(
                roleplays.Id.Value,
                roleplays.EssayId,
                roleplays.Content,
                roleplays.IsCompleted,
                roleplays.DifficultyLevel,
                roleplays.CreatedDateTime,
                roleplays.UpdatedDateTime
            ))
            .ToList();

        return roleplaysResults;
    }
}
