using ErrorOr;
using MediatR;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Roleplays.Commands.UpdateRoleplay;

public record UpdateRoleplayCommand(
    Guid Id,
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<RoleplayResult>>;
