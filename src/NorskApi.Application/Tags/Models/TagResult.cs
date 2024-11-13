using NorskApi.Domain.TagAggregate.Enums;

namespace NorskApi.Application.Tags.Models;

public record TagResult(
    Guid Id,
    string Label,
    string Color,
    TagType TagType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
