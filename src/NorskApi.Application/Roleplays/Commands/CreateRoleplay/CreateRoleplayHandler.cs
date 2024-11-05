namespace NorskApi.Application.Roleplays.Commands.CreateRoleplay;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;

public class CreateRoleplayHandler : IRequestHandler<CreateRoleplayCommand, ErrorOr<RoleplayResult>>
{
    private readonly IRoleplayRepository roleplayRepository;

    public CreateRoleplayHandler(IRoleplayRepository roleplayRepository)
    {
        this.roleplayRepository = roleplayRepository;
    }

    public async Task<ErrorOr<RoleplayResult>> Handle(
        CreateRoleplayCommand command,
        CancellationToken cancellationToken
    )
    {
        var essayId = EssayId.Create(command.EssayId);
        Roleplay roleplay = Roleplay.Create(
            essayId,
            command.Content,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.roleplayRepository.Add(roleplay, cancellationToken);

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
