using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class TaskWorkRepository : ITaskWorkRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithTopicBuilder queryParamsWithTopicBuilder;

    public TaskWorkRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithTopicBuilder queryParamsWithTopicBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithTopicBuilder = queryParamsWithTopicBuilder;
    }

    public async Task<List<TaskWork>> GetAll(
        QueryParamsWithTopicFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsWithTopicBuilder.BuildQueriesTaskWorks<TaskWork>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.TaskWorks.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<TaskWork?> GetById(TaskWorkId taskWorkId, CancellationToken cancellationToken)
    {
        return await this.dbContext.TaskWorks.SingleOrDefaultAsync(
            x => x.Id == taskWorkId,
            cancellationToken
        );
    }

    public async Task Add(TaskWork task, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(task, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(TaskWork task, CancellationToken cancellationToken)
    {
        this.dbContext.Update(task);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(TaskWork task, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(task);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
