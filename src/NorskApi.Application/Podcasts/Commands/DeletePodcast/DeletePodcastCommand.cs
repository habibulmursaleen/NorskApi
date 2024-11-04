namespace NorskApi.Application.Podcasts.Commands.DeletePodcast;

using ErrorOr;
using MediatR;

public record DeletePodcastCommand(Guid Id) : IRequest<ErrorOr<DeletePodcastResult>>;
