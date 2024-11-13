using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface IActivityRepository
{
    Task<List<Activity>> GetAll(CancellationToken cancellationToken);
    Task<Activity?> GetById(ActivityId activityId, CancellationToken cancellationToken);
    Task Add(Activity activity, CancellationToken cancellationToken);
    Task Update(Activity activity, CancellationToken cancellationToken);
    Task Delete(Activity activity, CancellationToken cancellationToken);
}
