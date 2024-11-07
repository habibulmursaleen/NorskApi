using ErrorOr;
using MediatR;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.EssayAggregate.Enums;

namespace NorskApi.Application.Essays.Command.CreateEssay;

public record CreateEssayCommand(
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
    List<CreateParagraphCommand> Paragraphs
) : IRequest<ErrorOr<EssayResult>>;

public record CreateParagraphCommand(string? Title, string Content, ContentType ContentType);
