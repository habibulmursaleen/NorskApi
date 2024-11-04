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
using NorskApi.Application.GrammarTopics.Commands.CreateGrammarTopic;
using NorskApi.Application.GrammarTopics.Commands.DeleteGrammarTopic;
using NorskApi.Application.GrammarTopics.Commands.UpdateGrammarTopic;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Application.GrammarTopics.Queries.GetAllGrammarTopics;
using NorskApi.Application.GrammarTopics.Queries.GetGrammarTopicById;
using NorskApi.Contracts.GrammarTopics.Request;
using NorskApi.Contracts.GrammarTopics.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/grammar/topics")]
public class GrammarTopicsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public GrammarTopicsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(GrammarTopicResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateGrammarTopic(
        [FromBody] CreateGrammarTopicRequest request
    )
    {
        CreateGrammarTopicCommand command = this.mapper.Map<CreateGrammarTopicCommand>(request);
        ErrorOr<GrammarTopicResult> createGrammarTopicResult = await this.mediator.Send(command);

        return createGrammarTopicResult.Match(
            createGrammarTopicResult =>
                this.Ok(this.mapper.Map<GrammarTopicResponse>(createGrammarTopicResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<GrammarTopicResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetGrammarTopics([FromQuery] QueryParamsBaseFilters filters)
    {
        GetAllGrammarTopicsQuery query = this.mapper.Map<GetAllGrammarTopicsQuery>(filters);
        ErrorOr<List<GrammarTopicResult>> getGrammarTopicsResult = await this.mediator.Send(query);

        return getGrammarTopicsResult.Match(
            grammarTopics => this.Ok(this.mapper.Map<List<GrammarTopicResponse>>(grammarTopics)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarTopicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGrammarTopic([FromRoute] Guid id)
    {
        ErrorOr<GrammarTopicResult> getGrammarTopicResult = await this.mediator.Send(
            new GetGrammarTopicByIdQuery(id)
        );

        return getGrammarTopicResult.Match(
            getGrammarTopicResult =>
                this.Ok(this.mapper.Map<GrammarTopicResponse>(getGrammarTopicResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarTopicResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteGrammarTopic([FromRoute] Guid id)
    {
        ErrorOr<DeleteGrammarTopicResult> deleteGrammarTopicResult = await this.mediator.Send(
            new DeleteGrammarTopicCommand(id)
        );

        return deleteGrammarTopicResult.Match(
            _ => this.NoContent(),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarTopicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateGrammarTopic(
        [FromRoute] Guid id,
        [FromBody] UpdateGrammarTopicRequest request
    )
    {
        UpdateGrammarTopicCommand command = this.mapper.Map<UpdateGrammarTopicCommand>(
            (id, request)
        );
        ErrorOr<GrammarTopicResult> updateGrammarTopicResult = await this.mediator.Send(command);

        return updateGrammarTopicResult.Match(
            updateGrammarTopicResult =>
                this.Ok(this.mapper.Map<GrammarTopicResponse>(updateGrammarTopicResult)),
            errors => this.Problem(errors)
        );
    }
}
