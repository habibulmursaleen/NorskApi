
using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Discussions.Request;
public record UpdateDiscussionRequest(
    string Title,
    string DiscussionEssays,
    string Note,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
);

