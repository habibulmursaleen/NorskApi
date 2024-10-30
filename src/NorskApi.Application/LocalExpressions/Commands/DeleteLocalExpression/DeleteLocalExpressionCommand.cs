namespace NorskApi.Application.LocalExpressions.Commands.DeleteLocalExpression;

using ErrorOr;
using MediatR;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

public record DeleteLocalExpressionCommand(Guid Id) : IRequest<ErrorOr<DeleteLocalExpressionResult>>;