using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Norskproves.Models;

public record NorskproveResult(
    Guid Id,
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
    List<NorskproveTagIdsResult> NorskproveTagIds,
    List<ListeningContentIdsResult> ListeningContentIds,
    List<ReadingContentIdsResult> ReadingContentIds,
    List<WritingContentIdsResult> WritingContentIds,
    List<AdditionalGrammarTaskIdsResult> AdditionalGrammarTaskIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record NorskproveTagIdsResult(Guid TagId);

public record ListeningContentIdsResult(Guid DictationId);

public record ReadingContentIdsResult(Guid EssayId);

public record WritingContentIdsResult(Guid DiscussionId);

public record AdditionalGrammarTaskIdsResult(Guid TaskWorkId);
