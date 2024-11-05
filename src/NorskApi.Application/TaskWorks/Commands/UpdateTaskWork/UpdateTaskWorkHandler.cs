using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Application.TaskWorks.Commands.UpdateTaskWork;

public class UpdateTaskWorkHandler : IRequestHandler<UpdateTaskWorkCommand, ErrorOr<TaskWorkResult>>
{
    private readonly ITaskWorkRepository taskWorkRepository;

    public UpdateTaskWorkHandler(ITaskWorkRepository taskWorkRepository)
    {
        this.taskWorkRepository = taskWorkRepository;
    }

    public async Task<ErrorOr<TaskWorkResult>> Handle(
        UpdateTaskWorkCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = TaskWorkId.Create(command.Id);
        var topicId = TopicId.Create(command.TopicId);
        TaskWork? taskWork = await taskWorkRepository.GetById(topicId, id, cancellationToken);

        if (taskWork is null)
        {
            return Errors.TaskWorkErrors.TaskWorkNotFound(command.Id, command.TopicId);
        }

        taskWork.Update(
            topicId,
            command.Logo,
            command.Label,
            command.TaskPointer,
            command.IsCompleted,
            command.Answer,
            command.Comments,
            command.AdditionalInfo,
            command.DifficultyLevel
        );

        await this.taskWorkRepository.Update(taskWork, cancellationToken);

        return new TaskWorkResult(
            taskWork.Id.Value,
            taskWork.TopicId.Value,
            taskWork.Logo,
            taskWork.Label,
            taskWork.TaskPointer,
            taskWork.IsCompleted,
            taskWork.Answer,
            taskWork.Comments,
            taskWork.AdditionalInfo,
            taskWork.DifficultyLevel,
            taskWork.CreatedDateTime,
            taskWork.UpdatedDateTime
        );
    }
}
