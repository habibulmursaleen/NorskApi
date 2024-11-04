using ErrorOr;
using MediatR;
using NorskApi.Application.Dictations.Models;

namespace NorskApi.Application.Dictations.Queries.GetDictationById;

public record GetDictationByIdQuery(Guid Id) : IRequest<ErrorOr<DictationResult>>;
