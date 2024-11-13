using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Errors;

namespace NorskApi.Application.Activities.Commands.UpdateActivity;

public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand, ErrorOr<ActivityResult>>
{
    private readonly IActivityRepository activityRepository;

    public UpdateActivityHandler(IActivityRepository activityRepository)
    {
        this.activityRepository = activityRepository;
    }

    public async Task<ErrorOr<ActivityResult>> Handle(
        UpdateActivityCommand command,
        CancellationToken cancellationToken
    )
    {
        var activityId = ActivityId.Create(command.Id);
        Activity? activity = await activityRepository.GetById(activityId, cancellationToken);

        if (activity is null)
        {
            return Errors.ActivityErrors.ActivityNotFound(command.Id);
        }

        activity.Update(command.Label, command.ActivityType);

        await this.activityRepository.Update(activity, cancellationToken);

        return new ActivityResult(
            activity.Id.Value,
            activity.Label,
            activity.ActivityType,
            activity.CreatedDateTime,
            activity.UpdatedDateTime
        );
    }
}
