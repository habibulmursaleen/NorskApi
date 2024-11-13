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
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    DifficultyLevel DifficultyLevel,
    List<CreateEssayActivityIdsCommand> EssayActivityIds,
    List<CreateEssayTagIdsCommand> EssayTagIds,
    List<CreateEssayRelatedGrammarTopicIdsCommand> EssayRelatedGrammarTopicIds,
    List<CreateParagraphCommand>? Paragraphs,
    List<CreateRoleplayCommand>? Roleplays
) : IRequest<ErrorOr<EssayResult>>;

public record CreateParagraphCommand(string? Title, string Content, ContentType ContentType);

public record CreateRoleplayCommand(string Content, bool IsCompleted);

public record CreateEssayActivityIdsCommand(Guid ActivityId);

public record CreateEssayTagIdsCommand(Guid TagId);

public record CreateEssayRelatedGrammarTopicIdsCommand(Guid TopicId);
