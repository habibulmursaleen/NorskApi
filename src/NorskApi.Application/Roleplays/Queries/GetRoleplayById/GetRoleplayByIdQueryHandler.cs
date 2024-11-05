using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Application.Roleplays.Queries.GetRoleplayById;

public record GetRoleplayByIdQueryHandler
    : IRequestHandler<GetRoleplayByIdQuery, ErrorOr<RoleplayResult>>
{
    private readonly IRoleplayRepository roleplayRepository;

    public GetRoleplayByIdQueryHandler(IRoleplayRepository roleplayRepository)
    {
        this.roleplayRepository = roleplayRepository;
    }

    public async Task<ErrorOr<RoleplayResult>> Handle(
        GetRoleplayByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a RoleplayId from the Guid
        EssayId essayId = EssayId.Create(query.EssayId);
        RoleplayId roleplayId = RoleplayId.Create(query.Id);
        Roleplay? roleplay = await roleplayRepository.GetById(
            essayId,
            roleplayId,
            cancellationToken
        );

        if (roleplay is null)
        {
            return Errors.RoleplayErrors.RoleplayNotFound(query.Id, query.EssayId);
        }

        return new RoleplayResult(
            roleplay.Id.Value,
            roleplay.EssayId,
            roleplay.Content,
            roleplay.IsCompleted,
            roleplay.DifficultyLevel,
            roleplay.CreatedDateTime,
            roleplay.UpdatedDateTime
        );
    }
}
