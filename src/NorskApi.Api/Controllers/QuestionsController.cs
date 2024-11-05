using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Questions.Commands.CreateQuestion;
using NorskApi.Application.Questions.Commands.DeleteQuestion;
using NorskApi.Application.Questions.Commands.UpdateQuestion;
using NorskApi.Application.Questions.Models;
using NorskApi.Application.Questions.Queries.GetAllQuestions;
using NorskApi.Application.Questions.Queries.GetQuestionById;
using NorskApi.Contracts.Questions.Request;
using NorskApi.Contracts.Questions.Response;

namespace NorskApi.Api.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1")]
public class QuestionsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public QuestionsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("essays/{essayId:guid}/questions")]
    public async Task<IActionResult> CreateQuestion(
        [FromRoute] Guid essayId,
        [FromBody] CreateQuestionRequest request
    )
    {
        CreateQuestionCommand command = this.mapper.Map<CreateQuestionCommand>((essayId, request));
        ErrorOr<QuestionResult> result = await this.mediator.Send(command);

        return result.Match(
            question => this.Ok(this.mapper.Map<QuestionResponse>(question)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<QuestionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/all/questions")]
    public async Task<IActionResult> GetQuestions([FromQuery] QueryParamsBaseFilters filters)
    {
        GetAllQuestionsQuery query = this.mapper.Map<GetAllQuestionsQuery>((Guid.Empty, filters));
        ErrorOr<List<QuestionResult>> result = await this.mediator.Send(query);

        return result.Match(
            questions => this.Ok(this.mapper.Map<List<QuestionResponse>>(questions)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<QuestionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/questions")]
    public async Task<IActionResult> GetQuestionsByEssayId(
        [FromRoute] Guid essayId,
        [FromQuery] QueryParamsBaseFilters filters
    )
    {
        GetAllQuestionsQuery query = this.mapper.Map<GetAllQuestionsQuery>((essayId, filters));

        ErrorOr<List<QuestionResult>> result = await this.mediator.Send(query);

        return result.Match(
            questions => this.Ok(this.mapper.Map<List<QuestionResponse>>(questions)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("essays/{essayId:guid}/questions/{id:guid}")]
    public async Task<IActionResult> GetQuestion([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        GetQuestionByIdQuery query = new(essayId, id);

        ErrorOr<QuestionResult> result = await this.mediator.Send(query);

        return result.Match(
            question => this.Ok(this.mapper.Map<QuestionResponse>(question)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("essays/{essayId:guid}/questions/{id:guid}")]
    public async Task<IActionResult> UpdateQuestion(
        [FromRoute] Guid essayId,
        [FromRoute] Guid id,
        [FromBody] UpdateQuestionRequest request
    )
    {
        UpdateQuestionCommand command = this.mapper.Map<UpdateQuestionCommand>(
            (essayId, id, request)
        );
        ErrorOr<QuestionResult> result = await this.mediator.Send(command);

        return result.Match(
            question => this.Ok(this.mapper.Map<QuestionResponse>(question)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("essays/{essayId:guid}/questions/{id:guid}")]
    public async Task<IActionResult> DeleteQuestion([FromRoute] Guid essayId, [FromRoute] Guid id)
    {
        DeleteQuestionCommand command = new(essayId, id);
        ErrorOr<DeleteQuestionResult> result = await this.mediator.Send(command);

        return result.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
