using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParamsRequest;

public record QueryParamsWithEssayFiltersRequest(
    DifficultyLevel DifficultyLevel,
    Guid EssayId,
    double Page,
    double Size,
    string? SortBy
);
