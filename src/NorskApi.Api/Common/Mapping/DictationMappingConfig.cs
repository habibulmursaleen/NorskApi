namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Dictations.Commands.CreateDictation;
using NorskApi.Application.Dictations.Commands.DeleteDictation;
using NorskApi.Application.Dictations.Commands.UpdateDictation;
using NorskApi.Application.Dictations.Models;
using NorskApi.Application.Dictations.Queries.GetAllDictations;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Dictations.Request;
using NorskApi.Contracts.Dictations.Response;

public class DictationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateDictationRequest, CreateDictationCommand>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);

        config
            .NewConfig<(Guid id, UpdateDictationRequest request), UpdateDictationCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.request.EssayId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Content, src => src.request.Content)
            .Map(dest => dest.Answer, src => src.request.Answer)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeleteDictationCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query

        config
            .NewConfig<QueryParamsWithEssayFiltersRequest, GetAllDictationsQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsWithEssayFiltersRequest, QueryParamsWithEssayFilters>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<DictationResult, DictationResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
