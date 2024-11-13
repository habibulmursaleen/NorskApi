namespace NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;

using ErrorOr;
using MediatR;

public record DeleteTaskWorkCommand(Guid Id) : IRequest<ErrorOr<DeleteTaskWorkResult>>;
