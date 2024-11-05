using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Application.Roleplays.Commands.UpdateRoleplay;

public class UpdateRoleplayHandler : IRequestHandler<UpdateRoleplayCommand, ErrorOr<RoleplayResult>>
{
    private readonly IRoleplayRepository roleplayRepository;

    public UpdateRoleplayHandler(IRoleplayRepository roleplayRepository)
    {
        this.roleplayRepository = roleplayRepository;
    }

    public async Task<ErrorOr<RoleplayResult>> Handle(
        UpdateRoleplayCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = RoleplayId.Create(command.Id);
        var essayId = EssayId.Create(command.EssayId);
        Roleplay? roleplay = await roleplayRepository.GetById(essayId, id, cancellationToken);

        if (roleplay is null)
        {
            return Errors.RoleplayErrors.RoleplayNotFound(command.Id, command.EssayId);
        }

        roleplay.Update(essayId, command.Content, command.IsCompleted, command.DifficultyLevel);

        await this.roleplayRepository.Update(roleplay, cancellationToken);

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
