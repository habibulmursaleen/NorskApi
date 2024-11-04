using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Common.QueryParams;

public record GetAllDiscussionsFiltersQuery(
    DifficultyLevel DifficultyLevel,
    DateTime FromDate,
    DateTime ToDate,
    double Skip,
    double Count,
    double Page,
    double Size,
    string? SortBy
);
