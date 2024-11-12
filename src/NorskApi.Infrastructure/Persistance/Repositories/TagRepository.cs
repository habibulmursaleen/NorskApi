using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class TagRepository : ITagRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly ITagsQueryParamsBuilder tagsQueryParamsBuilder;

    public TagRepository(
        NorskApiDbContext dbContext,
        ITagsQueryParamsBuilder tagsQueryParamsBuilder
    )
    {
        this.dbContext = dbContext;
        this.tagsQueryParamsBuilder = tagsQueryParamsBuilder;
    }

    public async Task<List<Tag>> GetAll(
        TagsQueryParamsFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Tags.AsQueryable();
        query = filters != null ? tagsQueryParamsBuilder.BuildQueriesTags<Tag>(filters) : query;
        if (query == null)
        {
            return await this.dbContext.Tags.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Tag?> GetById(TagId tagId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Tags.SingleOrDefaultAsync(
            x => x.Id == tagId,
            cancellationToken
        );
    }

    public async Task Add(Tag tag, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(tag, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Tag tag, CancellationToken cancellationToken)
    {
        this.dbContext.Update(tag);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Tag tag, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(tag);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
