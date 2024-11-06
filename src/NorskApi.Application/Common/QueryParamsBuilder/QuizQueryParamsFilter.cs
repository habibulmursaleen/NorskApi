using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Common.QueryParamsBuilder;

public record QuizQueryParamsFilters(
    Guid EssayId,
    Guid TopicId,
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
