using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Roleplays.Commands.CreateRoleplay;
using NorskApi.Application.Roleplays.Commands.DeleteRoleplay;
using NorskApi.Application.Roleplays.Commands.UpdateRoleplay;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Application.Roleplays.Queries.GetAllRoleplays;
using NorskApi.Application.Roleplays.Queries.GetRoleplayById;
using NorskApi.Contracts.Roleplays.Request;
using NorskApi.Contracts.Roleplays.Response;

namespace NorskApi.Api.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1")]
public class RoleplaysController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public RoleplaysController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(RoleplayResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("essays/{essayId:guid}/roleplays")]
    public async Task<IActionResult> CreateRoleplay(
        [FromRoute] Guid essayId,
        [FromBody] CreateRoleplayRequest request
    )
    {
        CreateRoleplayCommand command = this.mapper.Map<CreateRoleplayCommand>((essayId, request));
        ErrorOr<RoleplayResult> result = await this.mediator.Send(command);

        return result.Match(
            roleplay => this.Ok(this.mapper.Map<RoleplayResponse>(roleplay)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<RoleplayResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/all/roleplays")]
    public async Task<IActionResult> GetRoleplays([FromQuery] QueryParamsBaseFilters filters)
    {
        GetAllRoleplaysQuery query = this.mapper.Map<GetAllRoleplaysQuery>((Guid.Empty, filters));
        ErrorOr<List<RoleplayResult>> result = await this.mediator.Send(query);

        return result.Match(
            roleplays => this.Ok(this.mapper.Map<List<RoleplayResponse>>(roleplays)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<RoleplayResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/roleplays")]
    public async Task<IActionResult> GetRoleplaysByEssayId(
        [FromRoute] Guid essayId,
        [FromQuery] QueryParamsBaseFilters filters
    )
    {
        GetAllRoleplaysQuery query = this.mapper.Map<GetAllRoleplaysQuery>((essayId, filters));

        ErrorOr<List<RoleplayResult>> result = await this.mediator.Send(query);

        return result.Match(
            roleplays => this.Ok(this.mapper.Map<List<RoleplayResponse>>(roleplays)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(RoleplayResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/roleplays/{id:guid}")]
    public async Task<IActionResult> GetRoleplay([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        GetRoleplayByIdQuery query = new(essayId, id);

        ErrorOr<RoleplayResult> result = await this.mediator.Send(query);

        return result.Match(
            roleplay => this.Ok(this.mapper.Map<RoleplayResponse>(roleplay)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(RoleplayResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("essays/{essayId:guid}/roleplays/{id:guid}")]
    public async Task<IActionResult> UpdateRoleplay(
        [FromRoute] Guid essayId,
        [FromRoute] Guid id,
        [FromBody] UpdateRoleplayRequest request
    )
    {
        UpdateRoleplayCommand command = this.mapper.Map<UpdateRoleplayCommand>(
            (essayId, id, request)
        );
        ErrorOr<RoleplayResult> result = await this.mediator.Send(command);

        return result.Match(
            roleplay => this.Ok(this.mapper.Map<RoleplayResponse>(roleplay)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(RoleplayResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("essays/{essayId:guid}/roleplays/{id:guid}")]
    public async Task<IActionResult> DeleteRoleplay([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        DeleteRoleplayCommand command = new(essayId, id);
        ErrorOr<DeleteRoleplayResult> result = await this.mediator.Send(command);

        return result.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
