using ErrorOr;
using MediatR;
using NorskApi.Application.Words.Models;

namespace NorskApi.Application.Words.Queries.GetWordById;

public record GetWordByIdQuery(Guid Id) : IRequest<ErrorOr<WordResult>>;
