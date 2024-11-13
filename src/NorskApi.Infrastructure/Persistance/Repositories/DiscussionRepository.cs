using System.Text;
using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Infrastructure.Common;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class DiscussionRepository : IDiscussionRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder;

    public DiscussionRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithEssayBuilder = queryParamsWithEssayBuilder;
    }

    public async Task<List<Discussion>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsWithEssayBuilder.BuildQueriesDiscussions<Discussion>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Discussions.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Discussion?> GetById(
        DiscussionId discussionId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Discussions.SingleOrDefaultAsync(
            x => x.Id == discussionId,
            cancellationToken
        );
    }

    public async Task Add(Discussion discussion, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(discussion, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Discussion discussion, CancellationToken cancellationToken)
    {
        this.dbContext.Update(discussion);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Discussion discussion, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(discussion);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
