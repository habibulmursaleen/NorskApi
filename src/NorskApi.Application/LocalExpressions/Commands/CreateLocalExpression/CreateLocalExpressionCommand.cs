using ErrorOr;
using MediatR;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate.Enums;

namespace NorskApi.Application.LocalExpressions.Commands.CreateLocalExpression;

public record CreateLocalExpressionCommand(
    string Label,
    string Description,
    string MeaningInNorsk,
    string MeaningInEnglish,
    LocalExpressionType LocalExpressionType
) : IRequest<ErrorOr<LocalExpressionResult>>;