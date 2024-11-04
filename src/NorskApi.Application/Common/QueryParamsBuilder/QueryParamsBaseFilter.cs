using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Common.QueryParamsBuilder;

public record QueryParamsBaseFilters(
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
