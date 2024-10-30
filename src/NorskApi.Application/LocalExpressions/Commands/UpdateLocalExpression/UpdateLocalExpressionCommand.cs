using ErrorOr;
using MediatR;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate.Enums;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Application.LocalExpressions.Commands.UpdateLocalExpression;
public record UpdateLocalExpressionCommand(
    Guid Id,
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType
) : IRequest<ErrorOr<LocalExpressionResult>>;