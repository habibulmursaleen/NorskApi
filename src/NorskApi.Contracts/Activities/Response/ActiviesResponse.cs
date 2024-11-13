using NorskApi.Contracts.Activities.Enums;

namespace NorskApi.Contracts.Activities.Response;

public record ActivityResponse(
    Guid Id,
    string Label,
    ActivityType ActivityType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
