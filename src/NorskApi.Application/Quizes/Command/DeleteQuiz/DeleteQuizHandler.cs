namespace NorskApi.Application.Quizes.Command.DeleteQuiz;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.ValueObjects;

public class DeleteQuizHandler : IRequestHandler<DeleteQuizCommand, ErrorOr<DeleteQuizResult>>
{
    private readonly IQuizRepository quizRepository;

    public DeleteQuizHandler(IQuizRepository quizRepository)
    {
        this.quizRepository = quizRepository;
    }

    public async Task<ErrorOr<DeleteQuizResult>> Handle(
        DeleteQuizCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a QuizId from the Guid
        QuizId quizId = QuizId.Create(command.Id);

        Quiz? quiz = await quizRepository.GetById(quizId, cancellationToken);

        if (quiz is null)
        {
            return Errors.QuizesErrors.QuizesNotFound(command.Id);
        }

        quiz.Delete();

        await quizRepository.Delete(quiz, cancellationToken);

        return new DeleteQuizResult(quiz.Id.Value);
    }
}
