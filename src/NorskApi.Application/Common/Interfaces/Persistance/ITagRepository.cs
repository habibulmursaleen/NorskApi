using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface ITagRepository
{
    Task<List<Tag>> GetAll(TagsQueryParamsFilters? filters, CancellationToken cancellationToken);
    Task<Tag?> GetById(TagId tagId, CancellationToken cancellationToken);
    Task Add(Tag tag, CancellationToken cancellationToken);
    Task Update(Tag tag, CancellationToken cancellationToken);
    Task Delete(Tag tag, CancellationToken cancellationToken);
}
