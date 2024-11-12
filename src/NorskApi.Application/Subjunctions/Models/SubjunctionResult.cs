using NorskApi.Domain.SubjunctionAggregate.Enums;

namespace NorskApi.Application.Subjunctions.Models;

public record SubjunctionResult(
    Guid Id,
    string Label,
    SubjunctionType SubjunctionType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
