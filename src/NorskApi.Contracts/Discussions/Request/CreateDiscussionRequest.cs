using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Discussions.Request;
public record CreateDiscussionRequest(
    Guid EssayId,
    string Title,
    string DiscussionEssays,
    string Note,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
);

