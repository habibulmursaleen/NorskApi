namespace NorskApi.Application.Podcasts.Commands.DeletePodcast;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

public class DeletePodcastHandler
    : IRequestHandler<DeletePodcastCommand, ErrorOr<DeletePodcastResult>>
{
    private readonly IPodcastRepository podcastRepository;

    public DeletePodcastHandler(IPodcastRepository podcastRepository)
    {
        this.podcastRepository = podcastRepository;
    }

    public async Task<ErrorOr<DeletePodcastResult>> Handle(
        DeletePodcastCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a PodcastId from the Guid
        PodcastId podcastId = PodcastId.Create(command.Id);

        Podcast? podcast = await podcastRepository.GetById(podcastId, cancellationToken);

        if (podcast is null)
        {
            return Errors.PodcastErrors.PodcastNotFound(command.Id);
        }

        await podcastRepository.Delete(podcast, cancellationToken);

        return new DeletePodcastResult(podcast.Id.Value);
    }
}
