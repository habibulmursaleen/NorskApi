namespace NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

public class DeleteTaskWorkHandler
    : IRequestHandler<DeleteTaskWorkCommand, ErrorOr<DeleteTaskWorkResult>>
{
    private readonly ITaskWorkRepository taskWorkRepository;

    public DeleteTaskWorkHandler(ITaskWorkRepository taskWorkRepository)
    {
        this.taskWorkRepository = taskWorkRepository;
    }

    public async Task<ErrorOr<DeleteTaskWorkResult>> Handle(
        DeleteTaskWorkCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TopicID and TaskWorkId from the Guid
        TopicId topicId = TopicId.Create(command.TopicId);
        TaskWorkId taskWorkId = TaskWorkId.Create(command.Id);

        TaskWork? taskWork = await taskWorkRepository.GetById(
            topicId,
            taskWorkId,
            cancellationToken
        );

        if (taskWork is null)
        {
            return Errors.TaskWorkErrors.TaskWorkNotFound(command.Id, command.TopicId);
        }

        await taskWorkRepository.Delete(taskWork, cancellationToken);

        return new DeleteTaskWorkResult(taskWork.Id.Value);
    }
}
