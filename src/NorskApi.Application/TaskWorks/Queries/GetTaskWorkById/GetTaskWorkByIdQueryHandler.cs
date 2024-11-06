using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Application.TaskWorks.Queries.GetTaskById;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Application.TaskWorks.Queries.GetTaskWorkById;

public record GetTaskByIdQueryHandler
    : IRequestHandler<GetTaskWorkByIdQuery, ErrorOr<TaskWorkResult>>
{
    private readonly ITaskWorkRepository taskWorkRepository;

    public GetTaskByIdQueryHandler(ITaskWorkRepository taskWorkRepository)
    {
        this.taskWorkRepository = taskWorkRepository;
    }

    public async Task<ErrorOr<TaskWorkResult>> Handle(
        GetTaskWorkByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TaskWorkId from the Guid
        TopicId topicId = TopicId.Create(query.TopicId);
        TaskWorkId taskWorkId = TaskWorkId.Create(query.Id);
        TaskWork? taskWork = await taskWorkRepository.GetById(
            topicId,
            taskWorkId,
            cancellationToken
        );

        if (taskWork is null)
        {
            return Errors.TaskWorkErrors.TaskWorkNotFound(query.Id, query.TopicId);
        }

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
