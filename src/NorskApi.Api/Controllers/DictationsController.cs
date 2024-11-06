namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Dictations.Commands.CreateDictation;
using NorskApi.Application.Dictations.Commands.DeleteDictation;
using NorskApi.Application.Dictations.Commands.UpdateDictation;
using NorskApi.Application.Dictations.Models;
using NorskApi.Application.Dictations.Queries.GetAllDictations;
using NorskApi.Application.Dictations.Queries.GetDictationById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Dictations.Request;
using NorskApi.Contracts.Dictations.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/dictations")]
public class DictationsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public DictationsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(DictationResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateDictation([FromBody] CreateDictationRequest request)
    {
        CreateDictationCommand command = this.mapper.Map<CreateDictationCommand>(request);
        ErrorOr<DictationResult> createDictationResult = await this.mediator.Send(command);

        return createDictationResult.Match(
            createDictationResult =>
                this.Ok(this.mapper.Map<DictationResponse>(createDictationResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<DictationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetDictations(
        [FromQuery] QueryParamsWithEssayFiltersRequest filters
    )
    {
        GetAllDictationsQuery query = this.mapper.Map<GetAllDictationsQuery>(filters);
        ErrorOr<List<DictationResult>> getDictationsResult = await this.mediator.Send(query);

        return getDictationsResult.Match(
            dictations => this.Ok(this.mapper.Map<List<DictationResponse>>(dictations)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(DictationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDictation([FromRoute] Guid id)
    {
        ErrorOr<DictationResult> getDictationResult = await this.mediator.Send(
            new GetDictationByIdQuery(id)
        );

        return getDictationResult.Match(
            getDictationResult => this.Ok(this.mapper.Map<DictationResponse>(getDictationResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(DictationResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDictation([FromRoute] Guid id)
    {
        ErrorOr<DeleteDictationResult> deleteDictationResult = await this.mediator.Send(
            new DeleteDictationCommand(id)
        );

        return deleteDictationResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }

    [ProducesResponseType(typeof(DictationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateDictation(
        [FromRoute] Guid id,
        [FromBody] UpdateDictationRequest request
    )
    {
        UpdateDictationCommand command = this.mapper.Map<UpdateDictationCommand>((id, request));
        ErrorOr<DictationResult> updateDictationResult = await this.mediator.Send(command);

        return updateDictationResult.Match(
            updateDictationResult =>
                this.Ok(this.mapper.Map<DictationResponse>(updateDictationResult)),
            errors => this.Problem(errors)
        );
    }
}
