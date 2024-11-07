using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IDiscussionRepository
{
    Task<List<Discussion>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    );
    Task<List<Discussion>> GetAllByEssayId(
        EssayId essayId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    );
    Task<Discussion?> GetById(
        EssayId essayId,
        DiscussionId discussionId,
        CancellationToken cancellationToken
    );
    Task Add(Discussion discussion, CancellationToken cancellationToken);
    Task Update(Discussion discussion, CancellationToken cancellationToken);
    Task Delete(Discussion discussion, CancellationToken cancellationToken);
}
