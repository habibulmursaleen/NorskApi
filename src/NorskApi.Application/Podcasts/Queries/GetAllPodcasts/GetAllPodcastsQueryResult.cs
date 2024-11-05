using NorskApi.Application.Podcasts.Models;

namespace NorskApi.Application.Podcasts.Queries.GetAllPodcasts;

public record GetAllPodcastQueryResult(List<PodcastResult> Podcasts);
