using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.Enums;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;
namespace NorskApi.Application.LocalExpressions.Models;

public record LocalExpressionResult(
    Guid Id,
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
