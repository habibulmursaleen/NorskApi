using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class EssayRepository : IEssayRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public EssayRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<Essay>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Essays.AsQueryable();
        query = filters != null ? queryParamsBaseBuilder.BuildQueriesEssays<Essay>(filters) : query;
        if (query == null)
        {
            return await this.dbContext.Essays.ToListAsync(cancellationToken: cancellationToken);
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Essay?> GetById(EssayId essayId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Essays.SingleOrDefaultAsync(
            x => x.Id == essayId,
            cancellationToken
        );
    }

    public async Task Add(Essay essay, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(essay, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Essay essay, CancellationToken cancellationToken)
    {
        this.dbContext.Update(essay);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Essay essay, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(essay);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
