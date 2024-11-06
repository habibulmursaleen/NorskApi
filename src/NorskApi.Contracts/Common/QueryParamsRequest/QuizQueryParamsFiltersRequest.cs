using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParamsRequest;

public record QuizQueryParamsFiltersRequest(
    Guid EssayId,
    Guid TopicId,
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
