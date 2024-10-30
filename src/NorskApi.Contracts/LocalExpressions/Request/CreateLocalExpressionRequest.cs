using System.Text.Json.Serialization;
using NorskApi.Contracts.LocalExpressions.Common;

namespace NorskApi.Contracts.LocalExpressions.Request;
public record CreateLocalExpressionRequest(
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType
);

