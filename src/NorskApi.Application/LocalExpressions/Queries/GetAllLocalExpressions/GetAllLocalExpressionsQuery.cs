using ErrorOr;
using MediatR;
using NorskApi.Application.LocalExpressions.Models;

namespace NorskApi.Application.LocalExpressions.Queries.GetAllLocalExpressions;

public record GetAllLocalExpressionsQuery : IRequest<ErrorOr<List<LocalExpressionResult>>>;
