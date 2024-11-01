namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Discussions.Commands.CreateDiscussion;
using NorskApi.Application.Discussions.Commands.DeleteDiscussion;
using NorskApi.Application.Discussions.Commands.UpdateDiscussion;
using NorskApi.Application.Discussions.Models;
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
