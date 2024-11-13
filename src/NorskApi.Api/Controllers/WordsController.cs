namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Words.Command.CreateWord;
using NorskApi.Application.Words.Command.DeleteWord;
using NorskApi.Application.Words.Command.UpdateWord;
using NorskApi.Application.Words.Models;
using NorskApi.Application.Words.Queries.GetAllWords;
using NorskApi.Application.Words.Queries.GetWordById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Words.Requests.Create;
using NorskApi.Contracts.Words.Requests.Update;
using NorskApi.Contracts.Words.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/words")]
public class WordsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public WordsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(WordResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateWord([FromBody] CreateWordRequest request)
    {
        CreateWordCommand command = this.mapper.Map<CreateWordCommand>(request);
        ErrorOr<WordResult> createWordResult = await this.mediator.Send(command);

        return createWordResult.Match(
            createWordResult => this.Ok(this.mapper.Map<WordResponse>(createWordResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<WordResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetWords(
        [FromQuery] QueryParamsWithEssayFiltersRequest filters
    )
    {
        GetAllWordsQuery query = this.mapper.Map<GetAllWordsQuery>(filters);
        ErrorOr<List<WordResult>> getWordsResult = await this.mediator.Send(query);

        return getWordsResult.Match(
            words => this.Ok(this.mapper.Map<List<WordResponse>>(words)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(WordResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWord([FromRoute] Guid id)
    {
        GetWordByIdQuery query = new(id);

        ErrorOr<WordResult> getWordResult = await this.mediator.Send(query);

        return getWordResult.Match(
            getWordResult => this.Ok(this.mapper.Map<WordResponse>(getWordResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(WordResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWord(
        [FromRoute] Guid id,
        [FromBody] UpdateWordRequest request
    )
    {
        UpdateWordCommand command = this.mapper.Map<UpdateWordCommand>((id, request));
        ErrorOr<WordResult> updateWordResult = await this.mediator.Send(command);

        return updateWordResult.Match(
            updateWordResult => this.Ok(this.mapper.Map<WordResponse>(updateWordResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(WordResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteWord([FromRoute] Guid id)
    {
        DeleteWordCommand command = new(id);
        ErrorOr<DeleteWordResult> deleteWordResult = await this.mediator.Send(command);

        return deleteWordResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
