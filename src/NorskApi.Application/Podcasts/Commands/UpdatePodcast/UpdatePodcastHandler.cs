using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

namespace NorskApi.Application.Podcasts.Commands.UpdatePodcast;

public class UpdatePodcastHandler : IRequestHandler<UpdatePodcastCommand, ErrorOr<PodcastResult>>
{
    private readonly IPodcastRepository podcastRepository;

    public UpdatePodcastHandler(IPodcastRepository podcastRepository)
    {
        this.podcastRepository = podcastRepository;
    }

    public async Task<ErrorOr<PodcastResult>> Handle(
        UpdatePodcastCommand command,
        CancellationToken cancellationToken
    )
    {
        var podcastId = PodcastId.Create(command.Id);
        var essayId = command.EssayId is not null ? EssayId.Create(command.EssayId.Value) : null;
        Podcast? podcast = await podcastRepository.GetById(podcastId, cancellationToken);

        if (podcast is null)
        {
            return Errors.PodcastErrors.PodcastNotFound(command.Id);
        }

        podcast.Update(
            essayId,
            command.Label,
            command.Descriptions,
            command.Logo,
            command.Url,
            command.IsCompleted,
            command.IsFeatured,
            command.DifficultyLevel
        );

        await this.podcastRepository.Update(podcast, cancellationToken);

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
