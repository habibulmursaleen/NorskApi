using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Common.QueryParamsBuilder;

public record QueryParamsWithEssayFilters(
    DifficultyLevel DifficultyLevel,
    Guid EssayId,
    double Page,
    double Size,
    string? SortBy
);
