using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class PodcastRepository : IPodcastRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder;

    public PodcastRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithEssayBuilder = queryParamsWithEssayBuilder;
    }

    public async Task<List<Podcast>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Podcasts.AsQueryable();
        query =
            filters != null
                ? queryParamsWithEssayBuilder.BuildQueriesPodcasts<Podcast>(filters)
                : query;
        if (query == null)
        {
            return await this.dbContext.Podcasts.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Podcast?> GetById(PodcastId podcastId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Podcasts.SingleOrDefaultAsync(
            x => x.Id == podcastId,
            cancellationToken
        );
    }

    public async Task Add(Podcast podcast, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(podcast, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Podcast podcast, CancellationToken cancellationToken)
    {
        this.dbContext.Update(podcast);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Podcast podcast, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(podcast);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
