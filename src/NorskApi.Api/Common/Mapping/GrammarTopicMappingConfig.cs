namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Discussions.Queries.GetAllDiscussions;
using NorskApi.Application.GrammarTopics.Commands.CreateGrammarTopic;
using NorskApi.Application.GrammarTopics.Commands.DeleteGrammarTopic;
using NorskApi.Application.GrammarTopics.Commands.UpdateGrammarTopic;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Application.GrammarTopics.Queries.GetAllGrammarTopics;
using NorskApi.Contracts.GrammarTopics.Request;
using NorskApi.Contracts.GrammarTopics.Response;

public class GrammarTopicMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Map from CreateGrammarTopicRequest to CreateGrammarTopicCommand
        config
            .NewConfig<CreateGrammarTopicRequest, CreateGrammarTopicCommand>()
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Chapter, src => src.Chapter)
            .Map(dest => dest.ModuleCount, src => src.ModuleCount)
            .Map(dest => dest.Progress, src => src.Progress)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.IsSaved)
            .Map(dest => dest.Tags, src => src.Tags)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);

        // Map from UpdateGrammarTopicRequest to UpdateGrammarTopicCommand
        config
            .NewConfig<(Guid id, UpdateGrammarTopicRequest request), UpdateGrammarTopicCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.Status, src => src.request.Status)
            .Map(dest => dest.Chapter, src => src.request.Chapter)
            .Map(dest => dest.ModuleCount, src => src.request.ModuleCount)
            .Map(dest => dest.Progress, src => src.request.Progress)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.request.IsSaved)
            .Map(dest => dest.Tags, src => src.request.Tags)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        // Map from Guid to DeleteGrammarTopicCommand
        config.NewConfig<Guid, DeleteGrammarTopicCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<QueryParamsBaseFilters, GetAllGrammarTopicsQuery>()
            .Map(dest => dest.Filters, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QueryParamsBaseFilters, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        // Map from GrammarTopicResult to GrammarTopicResponse
        config
            .NewConfig<GrammarTopicResult, GrammarTopicResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Chapter, src => src.Chapter)
            .Map(dest => dest.ModuleCount, src => src.ModuleCount)
            .Map(dest => dest.Progress, src => src.Progress)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.IsSaved)
            .Map(dest => dest.Tags, src => src.Tags)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
