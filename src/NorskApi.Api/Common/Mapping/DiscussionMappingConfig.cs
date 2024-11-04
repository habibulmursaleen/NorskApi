namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParams;
using NorskApi.Application.Discussions.Commands.CreateDiscussion;
using NorskApi.Application.Discussions.Commands.DeleteDiscussion;
using NorskApi.Application.Discussions.Commands.UpdateDiscussion;
using NorskApi.Application.Discussions.Models;
using NorskApi.Application.Discussions.Queries.GetAllDiscussions;
using NorskApi.Contracts.Discussions.Request;
using NorskApi.Contracts.Discussions.Response;

public class DiscussionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(Guid essayId, CreateDiscussionRequest request), CreateDiscussionCommand>()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Title, src => src.request.Title)
            .Map(dest => dest.DiscussionEssays, src => src.request.DiscussionEssays)
            .Map(dest => dest.Note, src => src.request.Note)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config
            .NewConfig<
                (Guid essayId, Guid id, UpdateDiscussionRequest request),
                UpdateDiscussionCommand
            >()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Title, src => src.request.Title)
            .Map(dest => dest.DiscussionEssays, src => src.request.DiscussionEssays)
            .Map(dest => dest.Note, src => src.request.Note)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeleteDiscussionCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<(Guid essayId, GetDiscussionsFilters filters), GetAllDiscussionsQuery>()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Filters, src => src.filters);

        // Map Filter Request to Filter Query
        config
            .NewConfig<GetDiscussionsFilters, GetAllDiscussionsFiltersQuery>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.FromDate, src => src.FromDate)
            .Map(dest => dest.ToDate, src => src.ToDate)
            .Map(dest => dest.Skip, src => src.Skip)
            .Map(dest => dest.Count, src => src.Count)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<DiscussionResult, DiscussionResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.DiscussionEssays, src => src.DiscussionEssays)
            .Map(dest => dest.Note, src => src.Note)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
