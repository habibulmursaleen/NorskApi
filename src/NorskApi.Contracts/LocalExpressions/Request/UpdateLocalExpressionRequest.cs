using NorskApi.Contracts.LocalExpressions.Common;

namespace NorskApi.Contracts.LocalExpressions.Request;
public record UpdateLocalExpressionRequest(
    Guid Id,
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType
);