using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Norskproves.Models;

namespace NorskApi.Application.Norskproves.Queries.GetAllNorskproves;

public record GetAllNorskprovesQuery(QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<NorskproveResult>>>;
