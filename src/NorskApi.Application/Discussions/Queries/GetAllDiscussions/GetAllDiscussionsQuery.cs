using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Discussions.Models;

namespace NorskApi.Application.Discussions.Queries.GetAllDiscussions;

public record GetAllDiscussionsQuery(QueryParamsWithEssayFilters Filters)
    : IRequest<ErrorOr<List<DiscussionResult>>>;
