using NorskApi.Domain.SubjunctionAggregate;

namespace NorskApi.Application.Subjunctions.Models;

public record SubjunctionResult(
    Guid Id,
    List<string>? Time,
    List<string>? Arsak,
    List<string>? Hensikt,
    List<string>? Betingelse,
    List<string>? Motsetning,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
