using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class TaskWorkRepository : ITaskWorkRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsWithTopicBuilder;

    public TaskWorkRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsWithTopicBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithTopicBuilder = queryParamsWithTopicBuilder;
    }

    public async Task<List<TaskWork>> GetAll(
        QueryParamsBaseFilters? filters,
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

    public async Task<List<TaskWork>> GetAllByTopicId(
        TopicId topicId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsWithTopicBuilder.BuildQueriesTaskWorks<TaskWork>(filters);
        query = query?.Where(x => x.TopicId == topicId);
        if (query == null)
        {
            return new List<TaskWork>();
        }
        List<TaskWork>? tasks = await query.AsSplitQuery().ToListAsync(cancellationToken);

        return tasks;
    }

    public async Task<TaskWork?> GetById(
        TopicId topicId,
        TaskWorkId taskWorkId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.TaskWorks.SingleOrDefaultAsync(
            x => x.TopicId == topicId && x.Id == taskWorkId,
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
