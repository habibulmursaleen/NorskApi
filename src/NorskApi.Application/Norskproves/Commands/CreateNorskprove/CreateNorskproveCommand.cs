using ErrorOr;
using MediatR;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Norskproves.Commands.CreateNorskprove;

public record CreateNorskproveCommand(
    string Title,
    string? Description,
    bool IsCompleted,
    bool IsSaved,
    double Progress,
    double TimeLimit,
    double EstimatedCompletionTime,
    double Attempts,
    double MaxScore,
    Status Status,
    DifficultyLevel DifficultyLevel,
    List<NorskproveTagIdsCommand> NorskproveTagIds,
    List<SpeakingContentIdsCommand> SpeakingContentIds,
    List<ListeningContentIdsCommand> ListeningContentIds,
    List<ReadingContentIdsCommand> ReadingContentIds,
    List<WritingContentIdsCommand> WritingContentIds,
    List<AdditionalGrammarTaskIdsCommand> AdditionalGrammarTaskIds
) : IRequest<ErrorOr<NorskproveResult>>;

public record NorskproveTagIdsCommand(Guid TagId);

public record SpeakingContentIdsCommand(Guid QuestionId);

public record ListeningContentIdsCommand(Guid DictationId);

public record ReadingContentIdsCommand(Guid EssayId);

public record WritingContentIdsCommand(Guid DiscussionId);

public record AdditionalGrammarTaskIdsCommand(Guid TaskWorkId);
