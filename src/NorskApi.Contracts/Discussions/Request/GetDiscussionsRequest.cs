using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Discussions.Request;

public record GetDiscussionsRequest();

public record GetDiscussionsFilters(
    DifficultyLevel DifficultyLevel,
    DateTime FromDate,
    DateTime ToDate,
    double Skip,
    double Count,
    double Page,
    double Size,
    string? SortBy
);
