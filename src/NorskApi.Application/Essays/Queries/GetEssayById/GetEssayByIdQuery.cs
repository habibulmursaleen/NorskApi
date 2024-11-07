using ErrorOr;
using MediatR;
using NorskApi.Application.Essays.Models;

namespace NorskApi.Application.Essays.Queries.GetEssayById;

public record GetEssayByIdQuery(Guid Id) : IRequest<ErrorOr<EssayResult>>;
