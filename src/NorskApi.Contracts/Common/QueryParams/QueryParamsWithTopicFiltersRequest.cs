using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParams;

public record QueryParamsWithTopicFiltersRequest(
    DifficultyLevel DifficultyLevel,
    Guid TopicId,
    double Page,
    double Size,
    string? SortBy
);
