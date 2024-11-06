namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Podcasts.Commands.CreatePodcast;
using NorskApi.Application.Podcasts.Commands.DeletePodcast;
using NorskApi.Application.Podcasts.Commands.UpdatePodcast;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Application.Podcasts.Queries.GetAllPodcasts;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Podcasts.Request;
using NorskApi.Contracts.Podcasts.Response;

public class PodcastMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreatePodcastRequest, CreatePodcastCommand>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Descriptions, src => src.Descriptions)
            .Map(dest => dest.Logo, src => src.Logo)
            .Map(dest => dest.Url, src => src.Url)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsFeatured, src => src.IsFeatured)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);

        config
            .NewConfig<(Guid id, UpdatePodcastRequest request), UpdatePodcastCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.request.EssayId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Descriptions, src => src.request.Descriptions)
            .Map(dest => dest.Logo, src => src.request.Logo)
            .Map(dest => dest.Url, src => src.request.Url)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.IsFeatured, src => src.request.IsFeatured)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeletePodcastCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QueryParamsWithEssayFiltersRequest, GetAllPodcastsQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsWithEssayFiltersRequest, QueryParamsWithEssayFilters>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<PodcastResult, PodcastResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Descriptions, src => src.Descriptions)
            .Map(dest => dest.Logo, src => src.Logo)
            .Map(dest => dest.Url, src => src.Url)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsFeatured, src => src.IsFeatured)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
