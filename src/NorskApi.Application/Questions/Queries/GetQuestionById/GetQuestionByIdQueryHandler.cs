using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Questions.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

namespace NorskApi.Application.Questions.Queries.GetQuestionById;

public record GetQuestionByIdQueryHandler
    : IRequestHandler<GetQuestionByIdQuery, ErrorOr<QuestionResult>>
{
    private readonly IQuestionRepository questionRepository;

    public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }

    public async Task<ErrorOr<QuestionResult>> Handle(
        GetQuestionByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a QuestionId from the Guid
        EssayId essayId = EssayId.Create(query.EssayId);
        QuestionId questionId = QuestionId.Create(query.Id);
        Question? question = await questionRepository.GetById(
            essayId,
            questionId,
            cancellationToken
        );

        if (question is null)
        {
            return Errors.QuestionErrors.QuestionNotFound(query.Id, query.EssayId);
        }

        return new QuestionResult(
            question.Id.Value,
            question.EssayId,
            question.Label,
            question.Answer ?? string.Empty,
            question.IsCompleted,
            question.DifficultyLevel,
            question.CreatedDateTime,
            question.UpdatedDateTime
        );
    }
}
