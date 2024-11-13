using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly NorskApiDbContext dbContext;

    public ActivityRepository(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Activity>> GetAll(CancellationToken cancellationToken)
    {
        return await this.dbContext.Activities.ToListAsync();
    }

    public async Task<Activity?> GetById(ActivityId activityId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Activities.SingleOrDefaultAsync(
            x => x.Id == activityId,
            cancellationToken
        );
    }

    public async Task Add(Activity activity, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(activity, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Activity activity, CancellationToken cancellationToken)
    {
        this.dbContext.Update(activity);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Activity activity, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(activity);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
