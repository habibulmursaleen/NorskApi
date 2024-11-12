using NorskApi.Contracts.Subjunctions.Enums;

namespace NorskApi.Contracts.Subjunctions.Response;

public record SubjunctionResponse(
    Guid Id,
    string Label,
    SubjunctionType SubjunctionType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
