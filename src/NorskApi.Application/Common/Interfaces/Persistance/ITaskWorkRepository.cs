using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface ITaskWorkRepository
{
    Task<List<TaskWork>> GetAll(
        QueryParamsWithTopicFilters? filters,
        CancellationToken cancellationToken
    );

    Task<TaskWork?> GetById(TaskWorkId taskWorkId, CancellationToken cancellationToken);
    Task Add(TaskWork taskWork, CancellationToken cancellationToken);
    Task Update(TaskWork taskWork, CancellationToken cancellationToken);
    Task Delete(TaskWork taskWork, CancellationToken cancellationToken);
}
