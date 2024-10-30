using NorskApi.Application.LocalExpressions.Models;

namespace NorskApi.Application.LocalExpressions.Queries.GetAllLocalExpressions;

public record GetAllLocalExpressionQueryResult(List<LocalExpressionResult> LocalExpressions);