namespace NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;

using ErrorOr;
using MediatR;

public record DeleteTaskWorkCommand(Guid TopicId, Guid Id)
    : IRequest<ErrorOr<DeleteTaskWorkResult>>;
