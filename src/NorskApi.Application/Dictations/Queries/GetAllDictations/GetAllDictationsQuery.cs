using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Dictations.Models;

namespace NorskApi.Application.Dictations.Queries.GetAllDictations;

public record GetAllDictationsQuery(QueryParamsWithEssayFilters Filters)
    : IRequest<ErrorOr<List<DictationResult>>>;
