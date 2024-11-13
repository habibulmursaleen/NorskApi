using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.ActivityAggregate;

namespace NorskApi.Application.Activities.Queries.GetAllActivities;

public class GetAllActivitiesQueryHandler
    : IRequestHandler<GetAllActivitiesQuery, ErrorOr<List<ActivityResult>>>
{
    private readonly IActivityRepository activityRepository;

    public GetAllActivitiesQueryHandler(IActivityRepository activityRepository)
    {
        this.activityRepository = activityRepository;
    }

    public async Task<ErrorOr<List<ActivityResult>>> Handle(
        GetAllActivitiesQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Activity> activitys = new List<Activity>();
        var activity = await this.activityRepository.GetAll(cancellationToken);

        var activityResults = activity
            .Select(activity => new ActivityResult(
                activity.Id.Value,
                activity.Label,
                activity.ActivityType,
                activity.CreatedDateTime,
                activity.UpdatedDateTime
            ))
            .ToList();

        return activityResults;
    }
}
