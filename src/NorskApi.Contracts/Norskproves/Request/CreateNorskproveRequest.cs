using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Norskproves.Request;

public record CreateNorskproveRequest(
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
    List<CreateNorskproveTagIdsRequest> NorskproveTagIds,
    List<CreateListeningContentIdsRequest> ListeningContentIds,
    List<CreateReadingContentIdsRequest> ReadingContentIds,
    List<CreateWritingContentIdsRequest> WritingContentIds,
    List<CreateAdditionalGrammarTaskIdsRequest> AdditionalGrammarTaskIds
);

public record CreateNorskproveTagIdsRequest(Guid TagId);

public record CreateListeningContentIdsRequest(Guid DictationId);

public record CreateReadingContentIdsRequest(Guid EssayId);

public record CreateWritingContentIdsRequest(Guid DiscussionId);

public record CreateAdditionalGrammarTaskIdsRequest(Guid TaskWorkId);
