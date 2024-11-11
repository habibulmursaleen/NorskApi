namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Quizes.Command.CreateQuiz;
using NorskApi.Application.Quizes.Command.DeleteQuiz;
using NorskApi.Application.Quizes.Command.UpdateQuiz;
using NorskApi.Application.Quizes.Queries.GetAllQuizes;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Quizes.Requests;

public class QuizMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateQuizRequest, CreateQuizCommand>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.DictationId, src => src.DictationId)
            .Map(dest => dest.Question, src => src.Question)
            .Map(dest => dest.Answer, src => src.Answer)
            .Map(dest => dest.IsRightAnswer, src => src.IsRightAnswer)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.QuizType, src => src.QuizType)
            .Map(dest => dest.Options, src => src.Options);

        config
            .NewConfig<(Guid id, UpdateQuizRequest request), UpdateQuizCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.request.EssayId)
            .Map(dest => dest.TopicId, src => src.request.TopicId)
            .Map(dest => dest.DictationId, src => src.request.DictationId)
            .Map(dest => dest.Question, src => src.request.Question)
            .Map(dest => dest.Answer, src => src.request.Answer)
            .Map(dest => dest.IsRightAnswer, src => src.request.IsRightAnswer)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.QuizType, src => src.request.QuizType)
            .Map(dest => dest.Options, src => src.request.Options);

        config
            .NewConfig<UpdateQuizOptionRequest, UpdateQuizOptionCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.IsCorrect, src => src.IsCorrect)
            .Map(dest => dest.MultipleChoiceAnswer, src => src.MultipleChoiceAnswer);

        config.NewConfig<Guid, DeleteQuizCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QuizQueryParamsFiltersRequest, GetAllQuizesQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QuizQueryParamsFiltersRequest, QuizQueryParamsFilters>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.DictationId, src => src.DictationId)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<CreateQuizOptionRequest, CreateQuizOptionCommand>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.IsCorrect, src => src.IsCorrect)
            .Map(dest => dest.MultipleChoiceAnswer, src => src.MultipleChoiceAnswer);
    }
}
