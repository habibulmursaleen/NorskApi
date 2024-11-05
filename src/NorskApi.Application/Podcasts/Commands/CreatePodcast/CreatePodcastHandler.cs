namespace NorskApi.Application.Podcasts.Commands.CreatePodcast;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.PodcastAggregate;

public class CreatePodcastHandler : IRequestHandler<CreatePodcastCommand, ErrorOr<PodcastResult>>
{
    private readonly IPodcastRepository podcastRepository;

    public CreatePodcastHandler(IPodcastRepository podcastRepository)
    {
        this.podcastRepository = podcastRepository;
    }

    public async Task<ErrorOr<PodcastResult>> Handle(
        CreatePodcastCommand command,
        CancellationToken cancellationToken
    )
    {
        var essayId = command.EssayId is not null ? EssayId.Create(command.EssayId.Value) : null;
        Podcast podcast = Podcast.Create(
            essayId,
            command.Label,
            command.Descriptions,
            command.Logo,
            command.Url,
            command.IsCompleted,
            command.IsFeatured,
            command.DifficultyLevel
        );

        await this.podcastRepository.Add(podcast, cancellationToken);

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
