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
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    DifficultyLevel DifficultyLevel,
    List<UpdateEssayActivityIdsCommand> EssayActivityIds,
    List<UpdateEssayTagIdsCommand> EssayTagIds,
    List<UpdateEssayRelatedGrammarTopicIdsCommand> EssayRelatedGrammarTopicIds,
    List<UpdateParagraphCommand>? Paragraphs,
    List<UpdateRoleplayCommand>? Roleplays
) : IRequest<ErrorOr<EssayResult>>;

public record UpdateParagraphCommand(
    Guid Id,
    string? Title,
    string Content,
    ContentType ContentType
);

public record UpdateRoleplayCommand(Guid Id, string Content, bool IsCompleted);

public record UpdateEssayActivityIdsCommand(Guid ActivityId);

public record UpdateEssayTagIdsCommand(Guid TagId);

public record UpdateEssayRelatedGrammarTopicIdsCommand(Guid TopicId);
