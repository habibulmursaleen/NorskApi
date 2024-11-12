namespace NorskApi.Application.Norskproves.Commands.DeleteNorskprove;

using ErrorOr;
using MediatR;

public record DeleteNorskproveCommand(Guid Id) : IRequest<ErrorOr<DeleteNorskproveResult>>;
