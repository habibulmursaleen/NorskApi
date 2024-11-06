namespace NorskApi.Application.TaskWorks.Commands.CreateTaskWork;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;

public class CreateTaskWorkHandler : IRequestHandler<CreateTaskWorkCommand, ErrorOr<TaskWorkResult>>
{
    private readonly ITaskWorkRepository taskWorkRepository;

    public CreateTaskWorkHandler(ITaskWorkRepository taskWorkRepository)
    {
        this.taskWorkRepository = taskWorkRepository;
    }

    public async Task<ErrorOr<TaskWorkResult>> Handle(
        CreateTaskWorkCommand command,
        CancellationToken cancellationToken
    )
    {
        var topicId = TopicId.Create(command.TopicId);
        TaskWork taskWork = TaskWork.Create(
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

        await this.taskWorkRepository.Add(taskWork, cancellationToken);

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
