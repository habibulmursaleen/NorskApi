using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Discussions.Commands.CreateDiscussion;
using NorskApi.Application.Discussions.Commands.DeleteDiscussion;
using NorskApi.Application.Discussions.Commands.UpdateDiscussion;
using NorskApi.Application.Discussions.Models;
using NorskApi.Application.Discussions.Queries.GetAllDiscussions;
using NorskApi.Application.Discussions.Queries.GetDiscussionById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Discussions.Request;
using NorskApi.Contracts.Discussions.Response;

namespace NorskApi.Api.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1")]
public class DiscussionsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public DiscussionsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(DiscussionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("essays/{essayId:guid}/discussions")]
    public async Task<IActionResult> CreateDiscussion(
        [FromRoute] Guid essayId,
        [FromBody] CreateDiscussionRequest request
    )
    {
        CreateDiscussionCommand command = this.mapper.Map<CreateDiscussionCommand>(
            (essayId, request)
        );
        ErrorOr<DiscussionResult> result = await this.mediator.Send(command);

        return result.Match(
            discussion => this.Ok(this.mapper.Map<DiscussionResponse>(discussion)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<DiscussionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/all/discussions")]
    public async Task<IActionResult> GetDiscussions(
        [FromQuery] QueryParamsBaseFiltersRequest filters
    )
    {
        GetAllDiscussionsQuery query = this.mapper.Map<GetAllDiscussionsQuery>(
            (Guid.Empty, filters)
        );
        ErrorOr<List<DiscussionResult>> result = await this.mediator.Send(query);

        return result.Match(
            discussions => this.Ok(this.mapper.Map<List<DiscussionResponse>>(discussions)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<DiscussionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/discussions")]
    public async Task<IActionResult> GetDiscussionsByEssayId(
        [FromRoute] Guid essayId,
        [FromQuery] QueryParamsBaseFiltersRequest filters
    )
    {
        GetAllDiscussionsQuery query = this.mapper.Map<GetAllDiscussionsQuery>((essayId, filters));

        ErrorOr<List<DiscussionResult>> result = await this.mediator.Send(query);

        return result.Match(
            discussions => this.Ok(this.mapper.Map<List<DiscussionResponse>>(discussions)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(DiscussionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/discussions/{id:guid}")]
    public async Task<IActionResult> GetDiscussion([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        GetDiscussionByIdQuery query = new(essayId, id);

        ErrorOr<DiscussionResult> result = await this.mediator.Send(query);

        return result.Match(
            discussion => this.Ok(this.mapper.Map<DiscussionResponse>(discussion)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(DiscussionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("essays/{essayId:guid}/discussions/{id:guid}")]
    public async Task<IActionResult> UpdateDiscussion(
        [FromRoute] Guid essayId,
        [FromRoute] Guid id,
        [FromBody] UpdateDiscussionRequest request
    )
    {
        UpdateDiscussionCommand command = this.mapper.Map<UpdateDiscussionCommand>(
            (essayId, id, request)
        );
        ErrorOr<DiscussionResult> result = await this.mediator.Send(command);

        return result.Match(
            discussion => this.Ok(this.mapper.Map<DiscussionResponse>(discussion)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(DiscussionResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("essays/{essayId:guid}/discussions/{id:guid}")]
    public async Task<IActionResult> DeleteDiscussion([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        DeleteDiscussionCommand command = new(essayId, id);
        ErrorOr<DeleteDiscussionResult> result = await this.mediator.Send(command);

        return result.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
