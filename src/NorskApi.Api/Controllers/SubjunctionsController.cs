namespace NorskApi.Api.Controllers;

using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorskApi.Application.Subjunctions.Models;
using NorskApi.Application.Subjunctions.Queries.GetAllSubjunctions;
using NorskApi.Contracts.Subjunctions.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/subjunctions")]
public class SubjunctionsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public SubjunctionsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(List<SubjunctionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetSubjunctions()
    {
        GetAllSubjunctionsQuery query = new GetAllSubjunctionsQuery();
        ErrorOr<List<SubjunctionResult>> getSubjunctionsResult = await this.mediator.Send(query);

        return getSubjunctionsResult.Match(
            subjunctions => this.Ok(this.mapper.Map<List<SubjunctionResponse>>(subjunctions)),
            errors => this.Problem(errors)
        );
    }
}
