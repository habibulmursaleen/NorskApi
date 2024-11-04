using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParams;

public record QueryParamsBaseFiltersRequest(
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
