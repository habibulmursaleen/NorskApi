namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Quizes.Command.CreateQuiz;
using NorskApi.Application.Quizes.Command.DeleteQuiz;
using NorskApi.Application.Quizes.Command.UpdateQuiz;
using NorskApi.Application.Quizes.Models;
using NorskApi.Application.Quizes.Queries.GetAllQuizes;
using NorskApi.Application.Quizes.Queries.GetQuizById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Quizes.Requests;
using NorskApi.Contracts.Quizs.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/quizzes")]
public class QuizzesController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public QuizzesController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(QuizResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizRequest request)
    {
        CreateQuizCommand command = this.mapper.Map<CreateQuizCommand>(request);
        ErrorOr<QuizResult> createQuizResult = await this.mediator.Send(command);

        return createQuizResult.Match(
            createQuizResult => this.Ok(this.mapper.Map<QuizResponse>(createQuizResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<QuizResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetQuizes([FromQuery] QuizQueryParamsFiltersRequest filters)
    {
        GetAllQuizesQuery query = this.mapper.Map<GetAllQuizesQuery>(filters);
        ErrorOr<List<QuizResult>> getQuizsResult = await this.mediator.Send(query);

        return getQuizsResult.Match(
            quizs => this.Ok(this.mapper.Map<List<QuizResponse>>(quizs)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuizResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuiz([FromRoute] Guid id)
    {
        ErrorOr<QuizResult> getQuizResult = await this.mediator.Send(new GetQuizByIdQuery(id));

        return getQuizResult.Match(
            getQuizResult => this.Ok(this.mapper.Map<QuizResponse>(getQuizResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuizResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateQuiz(
        [FromRoute] Guid id,
        [FromBody] UpdateQuizRequest request
    )
    {
        UpdateQuizCommand command = this.mapper.Map<UpdateQuizCommand>((id, request));
        ErrorOr<QuizResult> updateQuizResult = await this.mediator.Send(command);

        return updateQuizResult.Match(
            updateQuizResult => this.Ok(this.mapper.Map<QuizResponse>(updateQuizResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuizResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuiz([FromRoute] Guid id)
    {
        ErrorOr<DeleteQuizResult> deleteQuizResult = await this.mediator.Send(
            new DeleteQuizCommand(id)
        );

        return deleteQuizResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
