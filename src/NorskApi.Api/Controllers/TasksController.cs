using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.TaskWorks.Commands.CreateTaskWork;
using NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;
using NorskApi.Application.TaskWorks.Commands.UpdateTaskWork;
using NorskApi.Application.TaskWorks.Models;
using NorskApi.Application.TaskWorks.Queries.GetAllTaskWorks;
using NorskApi.Application.TaskWorks.Queries.GetTaskById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.TaskWorks.Request;
using NorskApi.Contracts.TaskWorks.Response;

namespace NorskApi.Api.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1")]
public class TasksController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public TasksController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(TaskWorkResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("topics/{topicId:guid}/tasks")]
    public async Task<IActionResult> CreateTask(
        [FromRoute] Guid topicId,
        [FromBody] CreateTaskWorkRequest request
    )
    {
        CreateTaskWorkCommand command = this.mapper.Map<CreateTaskWorkCommand>((topicId, request));
        ErrorOr<TaskWorkResult> result = await this.mediator.Send(command);

        return result.Match(
            task => this.Ok(this.mapper.Map<TaskWorkResponse>(task)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<TaskWorkResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/all/tasks")]
    public async Task<IActionResult> GetTasks([FromQuery] QueryParamsBaseFiltersRequest filters)
    {
        GetAllTaskWorksQuery query = this.mapper.Map<GetAllTaskWorksQuery>((Guid.Empty, filters));
        ErrorOr<List<TaskWorkResult>> result = await this.mediator.Send(query);

        return result.Match(
            tasks => this.Ok(this.mapper.Map<List<TaskWorkResponse>>(tasks)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<TaskWorkResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/{topicId:guid}/tasks")]
    public async Task<IActionResult> GetTasksByTopicId(
        [FromRoute] Guid topicId,
        [FromQuery] QueryParamsBaseFiltersRequest filters
    )
    {
        GetAllTaskWorksQuery query = this.mapper.Map<GetAllTaskWorksQuery>((topicId, filters));

        ErrorOr<List<TaskWorkResult>> result = await this.mediator.Send(query);

        return result.Match(
            tasks => this.Ok(this.mapper.Map<List<TaskWorkResponse>>(tasks)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TaskWorkResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/{topicId:guid}/tasks/{id:guid}")]
    public async Task<IActionResult> GetTask([FromRoute] Guid topicId, [FromRoute] Guid id)
    {
        GetTaskWorkByIdQuery query = new(topicId, id);

        ErrorOr<TaskWorkResult> result = await this.mediator.Send(query);

        return result.Match(
            task => this.Ok(this.mapper.Map<TaskWorkResponse>(task)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TaskWorkResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("topics/{topicId:guid}/tasks/{id:guid}")]
    public async Task<IActionResult> UpdateTask(
        [FromRoute] Guid topicId,
        [FromRoute] Guid id,
        [FromBody] UpdateTaskWorkRequest request
    )
    {
        UpdateTaskWorkCommand command = this.mapper.Map<UpdateTaskWorkCommand>(
            (topicId, id, request)
        );
        ErrorOr<TaskWorkResult> result = await this.mediator.Send(command);

        return result.Match(
            task => this.Ok(this.mapper.Map<TaskWorkResponse>(task)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TaskWorkResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("topics/{topicId:guid}/tasks/{id:guid}")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid topicId, [FromRoute] Guid id)
    {
        DeleteTaskWorkCommand command = new(topicId, id);
        ErrorOr<DeleteTaskWorkResult> result = await this.mediator.Send(command);

        return result.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
