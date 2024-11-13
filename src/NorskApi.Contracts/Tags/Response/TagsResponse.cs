using NorskApi.Contracts.Tags.Enums;

namespace NorskApi.Contracts.Tags.Response;

public record TagResponse(
    Guid Id,
    string Label,
    string Color,
    TagType TagType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
