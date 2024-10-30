using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class LocalExpressionRepository : ILocalExpressionRepository
{
    private readonly NorskApiDbContext dbContext;

    public LocalExpressionRepository(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<LocalExpression>> GetAll(CancellationToken cancellationToken)
    {
        return await this.dbContext.LocalExpressions.ToListAsync();
    }

    public async Task<LocalExpression?> GetById(LocalExpressionId localExpressionId, CancellationToken cancellationToken)
    {
        return await this.dbContext.LocalExpressions.SingleOrDefaultAsync(x => x.Id == localExpressionId, cancellationToken);
    }

    public async Task Add(LocalExpression localExpression, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(localExpression, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(LocalExpression localExpression, CancellationToken cancellationToken)
    {
        this.dbContext.Update(localExpression);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(LocalExpression localExpression, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(localExpression);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}