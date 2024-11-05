using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Domain.PodcastAggregate;

namespace NorskApi.Application.Podcasts.Queries.GetAllPodcasts;

public class GetAllPodcastsQueryHandler
    : IRequestHandler<GetAllPodcastsQuery, ErrorOr<List<PodcastResult>>>
{
    private readonly IPodcastRepository podcastRepository;

    public GetAllPodcastsQueryHandler(IPodcastRepository podcastRepository)
    {
        this.podcastRepository = podcastRepository;
    }

    public async Task<ErrorOr<List<PodcastResult>>> Handle(
        GetAllPodcastsQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Podcast> podcasts = new List<Podcast>();
        QueryParamsWithEssayFilters? filters = query.Filters;
        var podcast = await this.podcastRepository.GetAll(filters, cancellationToken);

        var podcastResult = podcast
            .Select(podcast => new PodcastResult(
                podcast.Id.Value,
                podcast.EssayId?.Value,
                podcast.Label,
                podcast.Descriptions,
                podcast.Logo,
                podcast.Url,
                podcast.IsCompleted,
                podcast.IsFeatured,
                podcast.DifficultyLevel,
                podcast.CreatedDateTime,
                podcast.UpdatedDateTime
            ))
            .ToList();

        return podcastResult;
    }
}
