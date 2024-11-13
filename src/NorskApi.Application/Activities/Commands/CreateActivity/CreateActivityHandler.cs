namespace NorskApi.Application.Activities.Commands.CreateActivity;

using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.ActivityAggregate;

public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, ErrorOr<ActivityResult>>
{
    private readonly IActivityRepository activityRepository;

    public CreateActivityHandler(IActivityRepository activityRepository)
    {
        this.activityRepository = activityRepository;
    }

    public async Task<ErrorOr<ActivityResult>> Handle(
        CreateActivityCommand command,
        CancellationToken cancellationToken
    )
    {
        Activity activity = Activity.Create(command.Label, command.ActivityType);

        await this.activityRepository.Add(activity, cancellationToken);

        return new ActivityResult(
            activity.Id.Value,
            activity.Label,
            activity.ActivityType,
            activity.CreatedDateTime,
            activity.UpdatedDateTime
        );
    }
}
