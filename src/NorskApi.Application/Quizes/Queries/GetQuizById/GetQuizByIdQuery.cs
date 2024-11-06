using ErrorOr;
using MediatR;
using NorskApi.Application.Quizes.Models;

namespace NorskApi.Application.Quizes.Queries.GetQuizById;

public record GetQuizByIdQuery(Guid Id) : IRequest<ErrorOr<QuizResult>>;
