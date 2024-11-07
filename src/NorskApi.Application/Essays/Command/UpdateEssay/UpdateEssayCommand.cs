using ErrorOr;
using MediatR;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.EssayAggregate.Enums;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.Essays.Command.UpdateEssay;

public record UpdateEssayCommand(
    Guid Id,
    string? Logo,
    string Label,
    string? Description,
    double Progress,
    List<string>? Activities,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    List<string>? Tags,
    DifficultyLevel DifficultyLevel,
    List<Guid>? RelatedGrammarTopicIds,
    List<UpdateParagraphCommand> Paragraphs
) : IRequest<ErrorOr<EssayResult>>;

public record UpdateParagraphCommand(
    Guid Id,
    string? Title,
    string Content,
    ContentType ContentType
);
