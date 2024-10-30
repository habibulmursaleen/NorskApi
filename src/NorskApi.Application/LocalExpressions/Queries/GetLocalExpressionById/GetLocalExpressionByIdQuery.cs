using ErrorOr;
using MediatR;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Application.LocalExpressions.Queries.GetLocalExpressionById;

public record GetLocalExpressionByIdQuery(Guid Id) : IRequest<ErrorOr<LocalExpressionResult>>;