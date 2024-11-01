using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParams;
using NorskApi.Application.Discussions.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Discussions.Queries.GetAllDiscussions;

public record GetAllDiscussionsQuery(Guid? EssayId, GetAllDiscussionsFiltersQuery Filters)
    : IRequest<ErrorOr<List<DiscussionResult>>>;
