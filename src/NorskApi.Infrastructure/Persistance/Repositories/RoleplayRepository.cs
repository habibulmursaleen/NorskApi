using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class RoleplayRepository : IRoleplayRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public RoleplayRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<Roleplay>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsBaseBuilder.BuildQueriesRoleplays<Roleplay>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Roleplays.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<List<Roleplay>> GetAllByEssayId(
        EssayId essayId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsBaseBuilder.BuildQueriesRoleplays<Roleplay>(filters);
        query = query?.Where(x => x.EssayId == essayId);
        if (query == null)
        {
            return new List<Roleplay>();
        }
        List<Roleplay>? roleplays = await query.AsSplitQuery().ToListAsync(cancellationToken);

        return roleplays;
    }

    public async Task<Roleplay?> GetById(
        EssayId essayId,
        RoleplayId roleplayId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Roleplays.SingleOrDefaultAsync(
            x => x.EssayId == essayId && x.Id == roleplayId,
            cancellationToken
        );
    }

    public async Task Add(Roleplay roleplay, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(roleplay, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Roleplay roleplay, CancellationToken cancellationToken)
    {
        this.dbContext.Update(roleplay);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Roleplay roleplay, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(roleplay);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
