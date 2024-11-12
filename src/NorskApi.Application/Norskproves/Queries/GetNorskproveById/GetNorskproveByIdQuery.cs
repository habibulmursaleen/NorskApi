using ErrorOr;
using MediatR;
using NorskApi.Application.Norskproves.Models;

namespace NorskApi.Application.Norskproves.Queries.GetNorskproveById;

public record GetNorskproveByIdQuery(Guid Id) : IRequest<ErrorOr<NorskproveResult>>;
