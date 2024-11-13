using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Errors;

namespace NorskApi.Application.Activities.Queries.GetActivityById;

public record GetActivityByIdQueryHandler
    : IRequestHandler<GetActivityByIdQuery, ErrorOr<ActivityResult>>
{
    private readonly IActivityRepository activityRepository;

    public GetActivityByIdQueryHandler(IActivityRepository activityRepository)
    {
        this.activityRepository = activityRepository;
    }

    public async Task<ErrorOr<ActivityResult>> Handle(
        GetActivityByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a ActivityId from the Guid
        ActivityId activityId = ActivityId.Create(query.Id);
        Activity? activity = await activityRepository.GetById(activityId, cancellationToken);

        if (activity is null)
        {
            return Errors.ActivityErrors.ActivityNotFound(query.Id);
        }

        return new ActivityResult(
            activity.Id.Value,
            activity.Label,
            activity.ActivityType,
            activity.CreatedDateTime,
            activity.UpdatedDateTime
        );
    }
}
