using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Podcasts.Models;

namespace NorskApi.Application.Podcasts.Queries.GetAllPodcasts;

public record GetAllPodcastsQuery(QueryParamsWithEssayFilters Filters)
    : IRequest<ErrorOr<List<PodcastResult>>>;
