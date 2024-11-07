using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Essays.Models;

namespace NorskApi.Application.Essays.Queries.GetAllEssays;

public record GetAllEssaysQuery(QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<EssayResult>>>;
