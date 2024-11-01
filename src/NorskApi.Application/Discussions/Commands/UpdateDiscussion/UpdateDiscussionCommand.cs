using ErrorOr;
using MediatR;
using NorskApi.Application.Discussions.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Discussions.Commands.UpdateDiscussion;

public record UpdateDiscussionCommand(
    Guid Id,
    Guid EssayId,
    string Title,
    string DiscussionEssays,
    string Note,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<DiscussionResult>>;
