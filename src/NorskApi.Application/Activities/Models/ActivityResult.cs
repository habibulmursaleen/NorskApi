using NorskApi.Domain.ActivityAggregate.Enums;

namespace NorskApi.Application.Activities.Models;

public record ActivityResult(
    Guid Id,
    string Label,
    ActivityType ActivityType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
