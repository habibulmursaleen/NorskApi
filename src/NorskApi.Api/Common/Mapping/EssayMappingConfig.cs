namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Essays.Command.CreateEssay;
using NorskApi.Application.Essays.Command.DeleteEssay;
using NorskApi.Application.Essays.Command.UpdateEssay;
using NorskApi.Application.Essays.Queries.GetAllEssays;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Essays.Requests;

public class EssayMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateEssayRequest, CreateEssayCommand>()
            .Map(dest => dest.Logo, src => src.Logo)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Progress, src => src.Progress)
            .Map(dest => dest.Activities, src => src.Activities)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Notes, src => src.Notes)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.IsSaved)
            .Map(dest => dest.Tags, src => src.Tags)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.RelatedGrammarTopicIds, src => src.RelatedGrammarTopicIds)
            .Map(dest => dest.Paragraphs, src => src.Paragraphs);

        config
            .NewConfig<(Guid id, UpdateEssayRequest request), UpdateEssayCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Logo, src => src.request.Logo)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.Progress, src => src.request.Progress)
            .Map(dest => dest.Activities, src => src.request.Activities)
            .Map(dest => dest.Status, src => src.request.Status)
            .Map(dest => dest.Notes, src => src.request.Notes)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.request.IsSaved)
            .Map(dest => dest.Tags, src => src.request.Tags)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.RelatedGrammarTopicIds, src => src.request.RelatedGrammarTopicIds)
            .Map(dest => dest.Paragraphs, src => src.request.Paragraphs);

        config.NewConfig<Guid, DeleteEssayCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QueryParamsBaseFiltersRequest, GetAllEssaysQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<CreateParagraphRequest, CreateParagraphCommand>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.ContentType, src => src.ContentType);

        config
            .NewConfig<UpdateParagraphRequest, UpdateParagraphCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.ContentType, src => src.ContentType);
    }
}
