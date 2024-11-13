namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Activities.Commands.CreateActivity;
using NorskApi.Application.Activities.Commands.DeleteActivity;
using NorskApi.Application.Activities.Commands.UpdateActivity;
using NorskApi.Application.Activities.Models;
using NorskApi.Application.Activities.Queries.GetActivityById;
using NorskApi.Application.Activities.Queries.GetAllActivities;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Contracts.Activities.Request;
using NorskApi.Contracts.Activities.Response;
using NorskApi.Contracts.Common.QueryParamsRequest;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/activities")]
public class ActivitiesController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public ActivitiesController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] CreateActivityRequest request)
    {
        CreateActivityCommand command = this.mapper.Map<CreateActivityCommand>(request);
        ErrorOr<ActivityResult> createActivityResult = await this.mediator.Send(command);

        return createActivityResult.Match(
            createActivityResult =>
                this.Ok(this.mapper.Map<ActivityResponse>(createActivityResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<ActivityResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        ErrorOr<List<ActivityResult>> getActivitiesResult = await this.mediator.Send(
            new GetAllActivitiesQuery()
        );

        return getActivitiesResult.Match(
            activitys => this.Ok(this.mapper.Map<List<ActivityResponse>>(activitys)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetActivity([FromRoute] Guid id)
    {
        ErrorOr<ActivityResult> getActivityResult = await this.mediator.Send(
            new GetActivityByIdQuery(id)
        );

        return getActivityResult.Match(
            getActivityResult => this.Ok(this.mapper.Map<ActivityResponse>(getActivityResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateActivity(
        [FromRoute] Guid id,
        [FromBody] UpdateActivityRequest request
    )
    {
        UpdateActivityCommand command = this.mapper.Map<UpdateActivityCommand>((id, request));
        ErrorOr<ActivityResult> updateActivityResult = await this.mediator.Send(command);

        return updateActivityResult.Match(
            updateActivityResult =>
                this.Ok(this.mapper.Map<ActivityResponse>(updateActivityResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteActivity([FromRoute] Guid id)
    {
        ErrorOr<DeleteActivityResult> deleteActivityResult = await this.mediator.Send(
            new DeleteActivityCommand(id)
        );

        return deleteActivityResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
