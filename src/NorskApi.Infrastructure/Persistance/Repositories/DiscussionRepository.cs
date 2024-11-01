using System.Text;
using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParams;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Infrastructure.Common;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class DiscussionRepository : IDiscussionRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBuilder queryParamsBuilder;

    public DiscussionRepository(NorskApiDbContext dbContext, IQueryParamsBuilder queryParamsBuilder)
    {
        this.dbContext = dbContext;
        this.queryParamsBuilder = queryParamsBuilder;
    }

    public async Task<List<Discussion>> GetAll(
        GetAllDiscussionsFiltersQuery? filters,
        CancellationToken cancellationToken
    )
    {
        var query = filters != null ? queryParamsBuilder.BuildQueries<Discussion>(filters) : null;
        if (query == null)
        {
            return await this.dbContext.Discussions.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<List<Discussion>> GetAllByEssayId(
        EssayId essayId,
        GetAllDiscussionsFiltersQuery filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsBuilder.BuildQueries<Discussion>(filters);
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
