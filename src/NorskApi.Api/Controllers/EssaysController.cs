namespace NorskApi.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Essays.Command.CreateEssay;
using NorskApi.Application.Essays.Command.DeleteEssay;
using NorskApi.Application.Essays.Command.UpdateEssay;
using NorskApi.Application.Essays.Models;
using NorskApi.Application.Essays.Queries.GetAllEssays;
using NorskApi.Application.Essays.Queries.GetEssayById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Essays.Requests;
using NorskApi.Contracts.Essays.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/essays")]
public class EssaysController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public EssaysController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(EssayResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateEssay([FromBody] CreateEssayRequest request)
    {
        CreateEssayCommand command = this.mapper.Map<CreateEssayCommand>(request);
        ErrorOr<EssayResult> createEssayResult = await this.mediator.Send(command);

        return createEssayResult.Match(
            createEssayResult => this.Ok(this.mapper.Map<EssayResponse>(createEssayResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<EssayLiteResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetEssays([FromQuery] QueryParamsBaseFiltersRequest filters)
    {
        GetAllEssaysQuery query = this.mapper.Map<GetAllEssaysQuery>(filters);
        ErrorOr<List<EssayResult>> getEssaysResult = await this.mediator.Send(query);

        return getEssaysResult.Match(
            essays => this.Ok(this.mapper.Map<List<EssayLiteResponse>>(essays)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(EssayResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEssay([FromRoute] Guid id)
    {
        ErrorOr<EssayResult> getEssayResult = await this.mediator.Send(new GetEssayByIdQuery(id));

        return getEssayResult.Match(
            getEssayResult => this.Ok(this.mapper.Map<EssayResponse>(getEssayResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(EssayResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEssay(
        [FromRoute] Guid id,
        [FromBody] UpdateEssayRequest request
    )
    {
        UpdateEssayCommand command = this.mapper.Map<UpdateEssayCommand>((id, request));
        ErrorOr<EssayResult> updateEssayResult = await this.mediator.Send(command);

        return updateEssayResult.Match(
            updateEssayResult => this.Ok(this.mapper.Map<EssayResponse>(updateEssayResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(EssayResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEssay([FromRoute] Guid id)
    {
        ErrorOr<DeleteEssayResult> deleteEssayResult = await this.mediator.Send(
            new DeleteEssayCommand(id)
        );

        return deleteEssayResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
