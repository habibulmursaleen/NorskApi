namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.TaskWorks.Commands.CreateTaskWork;
using NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;
using NorskApi.Application.TaskWorks.Commands.UpdateTaskWork;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Application.TaskWorks.Queries.GetAllTaskWorks;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.TaskWorks.Request;
using NorskApi.Contracts.TaskWorks.Response;

public class TaskMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateTaskWorkRequest, CreateTaskWorkCommand>()
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Logo, src => src.Logo)
            .Map(dest => dest.TaskPointer, src => src.TaskPointer)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.Comments, src => src.Comments)
            .Map(dest => dest.AdditionalInfo, src => src.AdditionalInfo)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);

        config
            .NewConfig<(Guid id, UpdateTaskWorkRequest request), UpdateTaskWorkCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.TopicId, src => src.request.TopicId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Logo, src => src.request.Logo)
            .Map(dest => dest.TaskPointer, src => src.request.TaskPointer)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.Answer, src => src.request.Answer)
            .Map(dest => dest.Comments, src => src.request.Comments)
            .Map(dest => dest.AdditionalInfo, src => src.request.AdditionalInfo)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeleteTaskWorkCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<QueryParamsWithTopicFiltersRequest, GetAllTaskWorksQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsWithTopicFiltersRequest, QueryParamsWithTopicFilters>()
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<TaskWorkResult, TaskWorkResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Logo, src => src.Logo)
            .Map(dest => dest.TaskPointer, src => src.TaskPointer)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.Comments, src => src.Comments)
            .Map(dest => dest.AdditionalInfo, src => src.AdditionalInfo)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
