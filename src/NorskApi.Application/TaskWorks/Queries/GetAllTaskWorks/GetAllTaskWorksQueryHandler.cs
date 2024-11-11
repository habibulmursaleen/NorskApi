using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;

namespace NorskApi.Application.TaskWorks.Queries.GetAllTaskWorks;

public class GetAllTasksQueryHandler
    : IRequestHandler<GetAllTaskWorksQuery, ErrorOr<List<TaskWorkResult>>>
{
    private readonly ITaskWorkRepository taskWorkRepository;

    public GetAllTasksQueryHandler(ITaskWorkRepository taskWorkRepository)
    {
        this.taskWorkRepository = taskWorkRepository;
    }

    public async Task<ErrorOr<List<TaskWorkResult>>> Handle(
        GetAllTaskWorksQuery query,
        CancellationToken cancellationToken
    )
    {
        List<TaskWork> taskWorks = [];
        QueryParamsBaseFilters? filters = query.Filters;

        if (query.TopicId == Guid.Empty)
        {
            taskWorks = await this.taskWorkRepository.GetAll(filters, cancellationToken);
        }
        else
        {
            var topicId = TopicId.Create(query.TopicId ?? Guid.Empty);
            taskWorks = await this.taskWorkRepository.GetAllByTopicId(
                topicId,
                filters,
                cancellationToken
            );
        }

        List<TaskWorkResult> tasksResults = taskWorks
            .Select(tasks => new TaskWorkResult(
                tasks.Id.Value,
                tasks.TopicId.Value,
                tasks.Logo,
                tasks.Label,
                tasks.TaskPointer,
                tasks.IsCompleted,
                tasks.Answer,
                tasks.Comments,
                tasks.AdditionalInfo,
                tasks.DifficultyLevel,
                tasks.CreatedDateTime,
                tasks.UpdatedDateTime
            ))
            .ToList();

        return tasksResults;
    }
}
