using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class NorskproveRepository : INorskproveRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public NorskproveRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<Norskprove>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsBaseBuilder.BuildQueriesNorskproves<Norskprove>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Norskproves.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Norskprove?> GetById(
        NorskproveId norskproveId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Norskproves.SingleOrDefaultAsync(
            x => x.Id == norskproveId,
            cancellationToken
        );
    }

    public async Task Add(Norskprove norskprove, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(norskprove, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Norskprove norskprove, CancellationToken cancellationToken)
    {
        this.dbContext.Update(norskprove);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Norskprove norskprove, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(norskprove);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
