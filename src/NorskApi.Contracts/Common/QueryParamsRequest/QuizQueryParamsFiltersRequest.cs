using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParamsRequest;

public record QuizQueryParamsFiltersRequest(
    Guid EssayId,
    Guid TopicId,
    Guid DictationId,
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
