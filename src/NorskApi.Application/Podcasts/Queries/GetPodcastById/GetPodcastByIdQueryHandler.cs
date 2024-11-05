using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

namespace NorskApi.Application.Podcasts.Queries.GetPodcastById;

public record GetPodcastByIdQueryHandler
    : IRequestHandler<GetPodcastByIdQuery, ErrorOr<PodcastResult>>
{
    private readonly IPodcastRepository podcastRepository;

    public GetPodcastByIdQueryHandler(IPodcastRepository podcastRepository)
    {
        this.podcastRepository = podcastRepository;
    }

    public async Task<ErrorOr<PodcastResult>> Handle(
        GetPodcastByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a PodcastId from the Guid
        PodcastId podcastId = PodcastId.Create(query.Id);
        Podcast? podcast = await podcastRepository.GetById(podcastId, cancellationToken);

        if (podcast is null)
        {
            return Errors.PodcastErrors.PodcastNotFound(query.Id);
        }

        return new PodcastResult(
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
        );
    }
}
