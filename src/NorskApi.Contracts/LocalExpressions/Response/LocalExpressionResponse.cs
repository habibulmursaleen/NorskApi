using NorskApi.Contracts.LocalExpressions.Common;

namespace NorskApi.Contracts.LocalExpressions.Response;

public record LocalExpressionResponse(
    Guid Id,
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);