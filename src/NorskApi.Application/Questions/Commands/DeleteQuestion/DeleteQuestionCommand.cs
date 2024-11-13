namespace NorskApi.Application.Questions.Commands.DeleteQuestion;

using ErrorOr;
using MediatR;

public record DeleteQuestionCommand(Guid Id) : IRequest<ErrorOr<DeleteQuestionResult>>;
