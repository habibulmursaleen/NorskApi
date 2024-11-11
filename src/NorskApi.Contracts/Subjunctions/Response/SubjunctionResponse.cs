namespace NorskApi.Contracts.Subjunctions.Response;

public record SubjunctionResponse(
    Guid Id,
    List<string>? Time,
    List<string>? Arsak,
    List<string>? Hensikt,
    List<string>? Betingelse,
    List<string>? Motsetning,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
