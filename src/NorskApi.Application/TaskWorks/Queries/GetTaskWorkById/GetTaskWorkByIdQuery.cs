using ErrorOr;
using MediatR;
using NorskApi.Application.TaskWorks.Models;

namespace NorskApi.Application.TaskWorks.Queries.GetTaskById;

public record GetTaskWorkByIdQuery(Guid Id) : IRequest<ErrorOr<TaskWorkResult>>;
