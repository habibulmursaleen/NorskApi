using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.TaskWorks.Models;

namespace NorskApi.Application.TaskWorks.Queries.GetAllTaskWorks;

public record GetAllTaskWorksQuery(Guid? TopicId, QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<TaskWorkResult>>>;
