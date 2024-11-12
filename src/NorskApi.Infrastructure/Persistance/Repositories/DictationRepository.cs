using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class DictationRepository : IDictationRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder;

    public DictationRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithEssayBuilder = queryParamsWithEssayBuilder;
    }

    public async Task<List<Dictation>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Dictations.AsQueryable();
        query =
            filters != null
                ? queryParamsWithEssayBuilder.BuildQueriesDictations<Dictation>(filters)
                : query;
        if (query == null)
        {
            return await this.dbContext.Dictations.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Dictation?> GetById(
        DictationId dictationId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Dictations.SingleOrDefaultAsync(
            x => x.Id == dictationId,
            cancellationToken
        );
    }

    public async Task Add(Dictation dictation, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(dictation, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Dictation dictation, CancellationToken cancellationToken)
    {
        this.dbContext.Update(dictation);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Dictation dictation, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(dictation);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
