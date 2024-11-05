using ErrorOr;
using MediatR;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Roleplays.Commands.CreateRoleplay;

public record CreateRoleplayCommand(
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<RoleplayResult>>;
