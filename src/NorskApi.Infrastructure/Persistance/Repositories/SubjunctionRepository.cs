using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.SubjunctionAgreegate;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class SubjunctionRepository : ISubjunctionRepository
{
    private readonly NorskApiDbContext dbContext;

    public SubjunctionRepository(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Subjunction>> GetAll(CancellationToken cancellationToken)
    {
        return await this.dbContext.Subjunctions.ToListAsync();
    }
}
