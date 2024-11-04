using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Common.QueryParamsBuilder;

public record QueryParamsWithTopicFilters(
    DifficultyLevel DifficultyLevel,
    Guid TopicId,
    double Page,
    double Size,
    string? SortBy
);
