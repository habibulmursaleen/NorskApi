using ErrorOr;
using MediatR;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.TaskWorks.Commands.UpdateTaskWork;

public record UpdateTaskWorkCommand(
    Guid Id,
    Guid TopicId,
    string? Logo,
    string Label,
    string? TaskPointer,
    bool IsCompleted,
    string? Answer,
    string? Comments,
    string? AdditionalInfo,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<TaskWorkResult>>;
