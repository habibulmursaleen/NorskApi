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
using NorskApi.Application.Podcasts.Commands.CreatePodcast;
using NorskApi.Application.Podcasts.Commands.DeletePodcast;
using NorskApi.Application.Podcasts.Commands.UpdatePodcast;
using NorskApi.Application.Podcasts.Models;
using NorskApi.Application.Podcasts.Queries.GetAllPodcasts;
using NorskApi.Application.Podcasts.Queries.GetPodcastById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Podcasts.Request;
using NorskApi.Contracts.Podcasts.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/podcasts")]
public class PodcastsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public PodcastsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(PodcastResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreatePodcast([FromBody] CreatePodcastRequest request)
    {
        CreatePodcastCommand command = this.mapper.Map<CreatePodcastCommand>(request);
        ErrorOr<PodcastResult> createPodcastResult = await this.mediator.Send(command);

        return createPodcastResult.Match(
            createPodcastResult => this.Ok(this.mapper.Map<PodcastResponse>(createPodcastResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<PodcastResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetPodcasts(
        [FromQuery] QueryParamsWithEssayFiltersRequest filters
    )
    {
        GetAllPodcastsQuery query = this.mapper.Map<GetAllPodcastsQuery>(filters);
        ErrorOr<List<PodcastResult>> getPodcastsResult = await this.mediator.Send(query);

        return getPodcastsResult.Match(
            podcasts => this.Ok(this.mapper.Map<List<PodcastResponse>>(podcasts)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(PodcastResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPodcast([FromRoute] Guid id)
    {
        ErrorOr<PodcastResult> getPodcastResult = await this.mediator.Send(
            new GetPodcastByIdQuery(id)
        );

        return getPodcastResult.Match(
            getPodcastResult => this.Ok(this.mapper.Map<PodcastResponse>(getPodcastResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(PodcastResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePodcast(
        [FromRoute] Guid id,
        [FromBody] UpdatePodcastRequest request
    )
    {
        UpdatePodcastCommand command = this.mapper.Map<UpdatePodcastCommand>((id, request));
        ErrorOr<PodcastResult> updatePodcastResult = await this.mediator.Send(command);

        return updatePodcastResult.Match(
            updatePodcastResult => this.Ok(this.mapper.Map<PodcastResponse>(updatePodcastResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(PodcastResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePodcast([FromRoute] Guid id)
    {
        ErrorOr<DeletePodcastResult> deletePodcastResult = await this.mediator.Send(
            new DeletePodcastCommand(id)
        );

        return deletePodcastResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
