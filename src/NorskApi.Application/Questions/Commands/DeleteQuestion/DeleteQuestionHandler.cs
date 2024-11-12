namespace NorskApi.Application.Questions.Commands.DeleteQuestion;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

public class DeleteQuestionHandler
    : IRequestHandler<DeleteQuestionCommand, ErrorOr<DeleteQuestionResult>>
{
    private readonly IQuestionRepository questionRepository;

    public DeleteQuestionHandler(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }

    public async Task<ErrorOr<DeleteQuestionResult>> Handle(
        DeleteQuestionCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a EssayId and QuestionId from the Guid
        QuestionId questionId = QuestionId.Create(command.Id);

        Question? question = await questionRepository.GetById(questionId, cancellationToken);

        if (question is null)
        {
            return Errors.QuestionErrors.QuestionNotFound(command.Id);
        }

        await questionRepository.Delete(question, cancellationToken);

        return new DeleteQuestionResult(question.Id.Value);
    }
}
