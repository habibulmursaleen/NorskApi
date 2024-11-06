using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParamsRequest;

public record QueryParamsBaseFiltersRequest(
    DifficultyLevel DifficultyLevel,
    double Page,
    double Size,
    string? SortBy
);
