using ErrorOr;
using MediatR;
using NorskApi.Application.Podcasts.Models;

namespace NorskApi.Application.Podcasts.Queries.GetPodcastById;

public record GetPodcastByIdQuery(Guid Id) : IRequest<ErrorOr<PodcastResult>>;
