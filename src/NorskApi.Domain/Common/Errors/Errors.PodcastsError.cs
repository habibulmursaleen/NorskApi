namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class PodcastErrors
    {
        public static Error PodcastNotFound(Guid PodcastId) =>
            Error.NotFound(
                code: "Podcast.NotFound",
                description: $"Podcast with id {PodcastId} not found."
            );
    }
}
