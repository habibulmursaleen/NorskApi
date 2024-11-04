namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Questions.Commands.CreateQuestion;
using NorskApi.Application.Questions.Commands.DeleteQuestion;
using NorskApi.Application.Questions.Commands.UpdateQuestion;
using NorskApi.Application.Questions.Models;
using NorskApi.Application.Questions.Queries.GetAllQuestions;
using NorskApi.Contracts.Questions.Request;
using NorskApi.Contracts.Questions.Response;

public class QuestionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(Guid essayId, CreateQuestionRequest request), CreateQuestionCommand>()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Answer, src => src.request.Answer)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config
            .NewConfig<
                (Guid essayId, Guid id, UpdateQuestionRequest request),
                UpdateQuestionCommand
            >()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Answer, src => src.request.Answer)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeleteQuestionCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<(Guid essayId, QueryParamsBaseFilters filters), GetAllQuestionsQuery>()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Filters, src => src.filters);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QueryParamsBaseFilters, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<QuestionResult, QuestionResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
