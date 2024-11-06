namespace NorskApi.Application.Quizes.Command.DeleteQuiz;

using ErrorOr;
using MediatR;

public record DeleteQuizCommand(Guid Id) : IRequest<ErrorOr<DeleteQuizResult>>;
