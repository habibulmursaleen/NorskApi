using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Common.QueryParams;

public record QueryParamsWithEssayFiltersRequest(
    DifficultyLevel DifficultyLevel,
    Guid EssayId,
    double Page,
    double Size,
    string? SortBy
);
