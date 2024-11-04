using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IPodcastRepository
{
    Task<List<Podcast>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    );
    Task<Podcast?> GetById(PodcastId PodcastId, CancellationToken cancellationToken);
    Task Add(Podcast podcast, CancellationToken cancellationToken);
    Task Update(Podcast podcast, CancellationToken cancellationToken);
    Task Delete(Podcast podcast, CancellationToken cancellationToken);
}
