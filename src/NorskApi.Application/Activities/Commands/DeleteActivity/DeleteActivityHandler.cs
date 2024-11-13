namespace NorskApi.Application.Activities.Commands.DeleteActivity;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Errors;

public class DeleteActivityHandler
    : IRequestHandler<DeleteActivityCommand, ErrorOr<DeleteActivityResult>>
{
    private readonly IActivityRepository activityRepository;

    public DeleteActivityHandler(IActivityRepository activityRepository)
    {
        this.activityRepository = activityRepository;
    }

    public async Task<ErrorOr<DeleteActivityResult>> Handle(
        DeleteActivityCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a ActivityId from the Guid
        ActivityId activityId = ActivityId.Create(command.Id);

        Activity? activity = await activityRepository.GetById(activityId, cancellationToken);

        if (activity is null)
        {
            return Errors.ActivityErrors.ActivityNotFound(command.Id);
        }

        await activityRepository.Delete(activity, cancellationToken);

        return new DeleteActivityResult(activity.Id.Value);
    }
}
