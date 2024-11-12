using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Questions.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

namespace NorskApi.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, ErrorOr<QuestionResult>>
{
    private readonly IQuestionRepository questionRepository;

    public UpdateQuestionHandler(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }

    public async Task<ErrorOr<QuestionResult>> Handle(
        UpdateQuestionCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = QuestionId.Create(command.Id);
        var essayId = EssayId.Create(command.EssayId);
        Question? question = await questionRepository.GetById(id, cancellationToken);

        if (question is null)
        {
            return Errors.QuestionErrors.QuestionNotFound(command.Id);
        }

        question.Update(
            essayId,
            command.Label,
            command.Answer,
            command.IsCompleted,
            command.QuestionType,
            command.DifficultyLevel
        );

        await this.questionRepository.Update(question, cancellationToken);

        return new QuestionResult(
            question.Id.Value,
            question.EssayId,
            question.Label,
            question.Answer ?? string.Empty,
            question.IsCompleted,
            question.QuestionType,
            question.DifficultyLevel,
            question.CreatedDateTime,
            question.UpdatedDateTime
        );
    }
}
