namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.GrammarRules.Command.CreateGrammarRule;
using NorskApi.Application.GrammarRules.Command.DeleteGrammarRule;
using NorskApi.Application.GrammarRules.Command.UpdateGrammarRule;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Application.GrammarRules.Queries.GetAllGrammarRules;
using NorskApi.Application.GrammarRules.Queries.GetGrammarRuleById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.GrammarRules.Requests.Create;
using NorskApi.Contracts.GrammarRules.Requests.Update;
using NorskApi.Contracts.GrammarRules.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/grammars")]
public class GrammarRulesController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public GrammarRulesController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(GrammarRuleResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("topics/{topicId:guid}/rules")]
    public async Task<IActionResult> CreateGrammarRule(
        [FromRoute] Guid topicId,
        [FromBody] CreateGrammarRuleRequest request
    )
    {
        CreateGrammarRuleCommand command = this.mapper.Map<CreateGrammarRuleCommand>(
            (topicId, request)
        );
        ErrorOr<GrammarRuleResult> createGrammarRuleResult = await this.mediator.Send(command);

        return createGrammarRuleResult.Match(
            createGrammarRuleResult =>
                this.Ok(this.mapper.Map<GrammarRuleResponse>(createGrammarRuleResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<GrammarRuleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/all/rules")]
    public async Task<IActionResult> GetGrammarRules(
        [FromQuery] QueryParamsWithTopicFiltersRequest filters
    )
    {
        GetAllGrammarRulesQuery query = this.mapper.Map<GetAllGrammarRulesQuery>(
            (Guid.Empty, filters)
        );
        ErrorOr<List<GrammarRuleResult>> getGrammarRulesResult = await this.mediator.Send(query);

        return getGrammarRulesResult.Match(
            grammarRules => this.Ok(this.mapper.Map<List<GrammarRuleResponse>>(grammarRules)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<GrammarRuleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/{topicId:guid}/rules")]
    public async Task<IActionResult> GetGrammarRuleByTopicId(
        [FromRoute] Guid topicId,
        [FromQuery] QueryParamsWithTopicFiltersRequest filters
    )
    {
        GetAllGrammarRulesQuery query = this.mapper.Map<GetAllGrammarRulesQuery>(
            (topicId, filters)
        );

        ErrorOr<List<GrammarRuleResult>> result = await this.mediator.Send(query);

        return result.Match(
            tasks => this.Ok(this.mapper.Map<List<GrammarRuleResponse>>(tasks)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarRuleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("topics/{topicId:guid}/rules/{id:guid}")]
    public async Task<IActionResult> GetGrammarRule([FromRoute] Guid topicId, [FromRoute] Guid id)
    {
        GetGrammarRuleByIdQuery query = new(topicId, id);

        ErrorOr<GrammarRuleResult> getGrammarRuleResult = await this.mediator.Send(query);

        return getGrammarRuleResult.Match(
            getGrammarRuleResult =>
                this.Ok(this.mapper.Map<GrammarRuleResponse>(getGrammarRuleResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarRuleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("topics/{topicId:guid}/rules/{id:guid}")]
    public async Task<IActionResult> UpdateGrammarRule(
        [FromRoute] Guid topicId,
        [FromRoute] Guid id,
        [FromBody] UpdateGrammarRuleRequest request
    )
    {
        UpdateGrammarRuleCommand command = this.mapper.Map<UpdateGrammarRuleCommand>(
            (topicId, id, request)
        );
        ErrorOr<GrammarRuleResult> updateGrammarRuleResult = await this.mediator.Send(command);

        return updateGrammarRuleResult.Match(
            updateGrammarRuleResult =>
                this.Ok(this.mapper.Map<GrammarRuleResponse>(updateGrammarRuleResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(GrammarRuleResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("topics/{topicId:guid}/rules/{id:guid}")]
    public async Task<IActionResult> DeleteGrammarRule(
        [FromRoute] Guid topicId,
        [FromRoute] Guid id
    )
    {
        DeleteGrammarRuleCommand command = new(topicId, id);
        ErrorOr<DeleteGrammarRuleResult> deleteGrammarRuleResult = await this.mediator.Send(
            command
        );

        return deleteGrammarRuleResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
