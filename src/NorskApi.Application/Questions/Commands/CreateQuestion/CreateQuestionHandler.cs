namespace NorskApi.Application.Questions.Commands.CreateQuestion;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Questions.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, ErrorOr<QuestionResult>>
{
    private readonly IQuestionRepository questionRepository;

    public CreateQuestionHandler(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }

    public async Task<ErrorOr<QuestionResult>> Handle(
        CreateQuestionCommand command,
        CancellationToken cancellationToken
    )
    {
        var essayId = EssayId.Create(command.EssayId);
        Question question = Question.Create(
            essayId,
            command.Label,
            command.Answer,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.questionRepository.Add(question, cancellationToken);

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
