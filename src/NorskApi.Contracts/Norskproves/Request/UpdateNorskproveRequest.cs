using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Norskproves.Request;

public record UpdateNorskproveRequest(
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
    List<UpdateNorskproveTagIdsRequest> NorskproveTagIds,
    List<UpdateSpeakingContentIdsRequest> SpeakingContentIds,
    List<UpdateListeningContentIdsRequest> ListeningContentIds,
    List<UpdateReadingContentIdsRequest> ReadingContentIds,
    List<UpdateWritingContentIdsRequest> WritingContentIds,
    List<UpdateAdditionalGrammarTaskIdsRequest> AdditionalGrammarTaskIds
);

public record UpdateNorskproveTagIdsRequest(Guid TagId);

public record UpdateSpeakingContentIdsRequest(Guid QuestionId);

public record UpdateListeningContentIdsRequest(Guid DictationId);

public record UpdateReadingContentIdsRequest(Guid EssayId);

public record UpdateWritingContentIdsRequest(Guid DiscussionId);

public record UpdateAdditionalGrammarTaskIdsRequest(Guid TaskWorkId);
