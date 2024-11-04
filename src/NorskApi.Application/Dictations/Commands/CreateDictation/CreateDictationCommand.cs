using ErrorOr;
using MediatR;
using NorskApi.Application.Dictations.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Dictations.Commands.CreateDictation;

public record CreateDictationCommand(
    Guid? EssayId,
    string Label,
    string Content,
    string? Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<DictationResult>>;
