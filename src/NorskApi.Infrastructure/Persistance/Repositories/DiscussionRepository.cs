using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class DiscussionRepository : IDiscussionRepository
{
    private readonly NorskApiDbContext dbContext;

    public DiscussionRepository(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Discussion>> GetAll(CancellationToken cancellationToken)
    {
        return await this.dbContext.Discussions.ToListAsync();
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

    public async Task<List<Discussion>> GetAllByEssayId(
        EssayId essayId,
        CancellationToken cancellationToken
    )
    {
        List<Discussion>? discussions = await this
            .dbContext.Discussions.Where(x => x.EssayId == essayId.Value)
            .ToListAsync(cancellationToken);
        return discussions;
    }
}
