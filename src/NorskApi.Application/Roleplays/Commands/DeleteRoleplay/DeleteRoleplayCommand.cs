namespace NorskApi.Application.Roleplays.Commands.DeleteRoleplay;

using ErrorOr;
using MediatR;

public record DeleteRoleplayCommand(Guid EssayId, Guid Id)
    : IRequest<ErrorOr<DeleteRoleplayResult>>;
