namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Norskproves.Commands.CreateNorskprove;
using NorskApi.Application.Norskproves.Commands.DeleteNorskprove;
using NorskApi.Application.Norskproves.Commands.UpdateNorskprove;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Application.Norskproves.Queries.GetAllNorskproves;
using NorskApi.Application.Norskproves.Queries.GetNorskproveById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Norskproves.Request;
using NorskApi.Contracts.Norskproves.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/norskproves")]
public class NorskprovesController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public NorskprovesController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(NorskproveResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateNorskprove([FromBody] CreateNorskproveRequest request)
    {
        CreateNorskproveCommand command = this.mapper.Map<CreateNorskproveCommand>(request);
        ErrorOr<NorskproveResult> createNorskproveResult = await this.mediator.Send(command);

        return createNorskproveResult.Match(
            createNorskproveResult =>
                this.Ok(this.mapper.Map<NorskproveResponse>(createNorskproveResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<NorskproveResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetNorskproves(
        [FromQuery] QueryParamsBaseFiltersRequest filters
    )
    {
        GetAllNorskprovesQuery query = this.mapper.Map<GetAllNorskprovesQuery>(filters);
        ErrorOr<List<NorskproveResult>> getNorskprovesResult = await this.mediator.Send(query);

        return getNorskprovesResult.Match(
            norskproves => this.Ok(this.mapper.Map<List<NorskproveResponse>>(norskproves)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(NorskproveResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNorskprove([FromRoute] Guid id)
    {
        ErrorOr<NorskproveResult> getNorskproveResult = await this.mediator.Send(
            new GetNorskproveByIdQuery(id)
        );

        return getNorskproveResult.Match(
            getNorskproveResult =>
                this.Ok(this.mapper.Map<NorskproveResponse>(getNorskproveResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(NorskproveResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateNorskprove(
        [FromRoute] Guid id,
        [FromBody] UpdateNorskproveRequest request
    )
    {
        UpdateNorskproveCommand command = this.mapper.Map<UpdateNorskproveCommand>((id, request));
        ErrorOr<NorskproveResult> updateNorskproveResult = await this.mediator.Send(command);

        return updateNorskproveResult.Match(
            updateNorskproveResult =>
                this.Ok(this.mapper.Map<NorskproveResponse>(updateNorskproveResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(NorskproveResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNorskprove([FromRoute] Guid id)
    {
        ErrorOr<DeleteNorskproveResult> deleteNorskproveResult = await this.mediator.Send(
            new DeleteNorskproveCommand(id)
        );

        return deleteNorskproveResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
