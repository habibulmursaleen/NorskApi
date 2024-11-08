namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.LocalExpressions.Commands.CreateLocalExpression;
using NorskApi.Application.LocalExpressions.Commands.DeleteLocalExpression;
using NorskApi.Application.LocalExpressions.Commands.UpdateLocalExpression;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Application.LocalExpressions.Queries.GetAllLocalExpressions;
using NorskApi.Application.LocalExpressions.Queries.GetLocalExpressionById;
using NorskApi.Contracts.LocalExpressions.Request;
using NorskApi.Contracts.LocalExpressions.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/localexpressions")]
public class LocalExpressionsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public LocalExpressionsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(LocalExpressionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateLocalExpression(
        [FromBody] CreateLocalExpressionRequest request
    )
    {
        CreateLocalExpressionCommand command = this.mapper.Map<CreateLocalExpressionCommand>(
            request
        );
        ErrorOr<LocalExpressionResult> createLocalExpressionResult = await this.mediator.Send(
            command
        );

        return createLocalExpressionResult.Match(
            createLocalExpressionResult =>
                this.Ok(this.mapper.Map<LocalExpressionResponse>(createLocalExpressionResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<LocalExpressionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetLocalExpressions()
    {
        ErrorOr<List<LocalExpressionResult>> getLocalExpressionsResult = await this.mediator.Send(
            new GetAllLocalExpressionsQuery()
        );

        return getLocalExpressionsResult.Match(
            localExpressions =>
                this.Ok(this.mapper.Map<List<LocalExpressionResponse>>(localExpressions)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(LocalExpressionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLocalExpression([FromRoute] Guid id)
    {
        ErrorOr<LocalExpressionResult> getLocalExpressionResult = await this.mediator.Send(
            new GetLocalExpressionByIdQuery(id)
        );

        return getLocalExpressionResult.Match(
            getLocalExpressionResult =>
                this.Ok(this.mapper.Map<LocalExpressionResponse>(getLocalExpressionResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(LocalExpressionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateLocalExpression(
        [FromRoute] Guid id,
        [FromBody] UpdateLocalExpressionRequest request
    )
    {
        UpdateLocalExpressionCommand command = this.mapper.Map<UpdateLocalExpressionCommand>(
            (id, request)
        );
        ErrorOr<LocalExpressionResult> updateLocalExpressionResult = await this.mediator.Send(
            command
        );

        return updateLocalExpressionResult.Match(
            updateLocalExpressionResult =>
                this.Ok(this.mapper.Map<LocalExpressionResponse>(updateLocalExpressionResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(LocalExpressionResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocalExpression([FromRoute] Guid id)
    {
        ErrorOr<DeleteLocalExpressionResult> deleteLocalExpressionResult = await this.mediator.Send(
            new DeleteLocalExpressionCommand(id)
        );

        return deleteLocalExpressionResult.Match(
            _ => this.NoContent(),
            errors => this.Problem(errors)
        );
    }
}
