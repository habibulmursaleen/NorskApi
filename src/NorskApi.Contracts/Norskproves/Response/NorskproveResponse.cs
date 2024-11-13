using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Norskproves.Response;

public record NorskproveResponse(
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
    List<NorskproveTagIdsResponse> NorskproveTagIds,
    List<SpeakingContentIdsResponse> SpeakingContentIds,
    List<ListeningContentIdsResponse> ListeningContentIds,
    List<ReadingContentIdsResponse> ReadingContentIds,
    List<WritingContentIdsResponse> WritingContentIds,
    List<AdditionalGrammarTaskIdsResponse> AdditionalGrammarTaskIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record NorskproveTagIdsResponse(Guid TagId);

public record SpeakingContentIdsResponse(Guid QuestionId);

public record ListeningContentIdsResponse(Guid DictationId);

public record ReadingContentIdsResponse(Guid EssayId);

public record WritingContentIdsResponse(Guid DiscussionId);

public record AdditionalGrammarTaskIdsResponse(Guid TaskWorkId);
