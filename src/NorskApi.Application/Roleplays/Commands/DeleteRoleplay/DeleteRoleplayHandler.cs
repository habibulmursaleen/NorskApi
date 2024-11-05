namespace NorskApi.Application.Roleplays.Commands.DeleteRoleplay;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

public class DeleteRoleplayHandler
    : IRequestHandler<DeleteRoleplayCommand, ErrorOr<DeleteRoleplayResult>>
{
    private readonly IRoleplayRepository roleplayRepository;

    public DeleteRoleplayHandler(IRoleplayRepository roleplayRepository)
    {
        this.roleplayRepository = roleplayRepository;
    }

    public async Task<ErrorOr<DeleteRoleplayResult>> Handle(
        DeleteRoleplayCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a EssayId and RoleplayId from the Guid
        EssayId essayId = EssayId.Create(command.EssayId);
        RoleplayId roleplayId = RoleplayId.Create(command.Id);

        Roleplay? roleplay = await roleplayRepository.GetById(
            essayId,
            roleplayId,
            cancellationToken
        );

        if (roleplay is null)
        {
            return Errors.RoleplayErrors.RoleplayNotFound(command.Id, command.EssayId);
        }

        await roleplayRepository.Delete(roleplay, cancellationToken);

        return new DeleteRoleplayResult(roleplay.Id.Value);
    }
}
