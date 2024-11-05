using System.Text;
using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
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
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public DiscussionRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<Discussion>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsBaseBuilder.BuildQueriesDiscussions<Discussion>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Discussions.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<List<Discussion>> GetAllByEssayId(
        EssayId essayId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsBaseBuilder.BuildQueriesDiscussions<Discussion>(filters);
        query = query?.Where(x => x.EssayId == essayId);
        if (query == null)
        {
            return new List<Discussion>();
        }
        List<Discussion>? discussions = await query.AsSplitQuery().ToListAsync(cancellationToken);

        return discussions;
    }

    public async Task<Discussion?> GetById(
        EssayId essayId,
        DiscussionId discussionId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Discussions.SingleOrDefaultAsync(
            x => x.EssayId == essayId && x.Id == discussionId,
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
