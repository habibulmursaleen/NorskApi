using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IDiscussionRepository
{
    Task<List<Discussion>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    );

    Task<Discussion?> GetById(DiscussionId discussionId, CancellationToken cancellationToken);
    Task Add(Discussion discussion, CancellationToken cancellationToken);
    Task Update(Discussion discussion, CancellationToken cancellationToken);
    Task Delete(Discussion discussion, CancellationToken cancellationToken);
}
