namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Tags.Commands.CreateTag;
using NorskApi.Application.Tags.Commands.DeleteTag;
using NorskApi.Application.Tags.Commands.UpdateTag;
using NorskApi.Application.Tags.Models;
using NorskApi.Application.Tags.Queries.GetAllTags;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Tags.Request;
using NorskApi.Contracts.Tags.Response;

public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateTagRequest, CreateTagCommand>()
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Color, src => src.Color)
            .Map(dest => dest.TagType, src => src.TagType);

        config
            .NewConfig<(Guid id, UpdateTagRequest request), UpdateTagCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Color, src => src.request.Color)
            .Map(dest => dest.TagType, src => src.request.TagType);

        config.NewConfig<Guid, DeleteTagCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query

        config
            .NewConfig<TagsQueryParamsFiltersRequest, GetAllTagsQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<TagsQueryParamsFiltersRequest, TagsQueryParamsFilters>()
            .Map(dest => dest.TagType, src => src.TagType);

        config
            .NewConfig<TagResult, TagResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Color, src => src.Color)
            .Map(dest => dest.TagType, src => src.TagType);
    }
}
