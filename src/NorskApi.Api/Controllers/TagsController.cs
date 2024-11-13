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
using NorskApi.Application.Tags.Commands.CreateTag;
using NorskApi.Application.Tags.Commands.DeleteTag;
using NorskApi.Application.Tags.Commands.UpdateTag;
using NorskApi.Application.Tags.Models;
using NorskApi.Application.Tags.Queries.GetAllTags;
using NorskApi.Application.Tags.Queries.GetTagById;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Tags.Request;
using NorskApi.Contracts.Tags.Response;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v2/tags")]
public class TagsController : ApiController
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public TagsController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [ProducesResponseType(typeof(TagResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateTag([FromBody] CreateTagRequest request)
    {
        CreateTagCommand command = this.mapper.Map<CreateTagCommand>(request);
        ErrorOr<TagResult> createTagResult = await this.mediator.Send(command);

        return createTagResult.Match(
            createTagResult => this.Ok(this.mapper.Map<TagResponse>(createTagResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(List<TagResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetTags([FromQuery] TagsQueryParamsFiltersRequest filters)
    {
        GetAllTagsQuery query = this.mapper.Map<GetAllTagsQuery>(filters);
        ErrorOr<List<TagResult>> getTagsResult = await this.mediator.Send(query);

        return getTagsResult.Match(
            tags => this.Ok(this.mapper.Map<List<TagResponse>>(tags)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TagResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTag([FromRoute] Guid id)
    {
        ErrorOr<TagResult> getTagResult = await this.mediator.Send(new GetTagByIdQuery(id));

        return getTagResult.Match(
            getTagResult => this.Ok(this.mapper.Map<TagResponse>(getTagResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TagResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTag(
        [FromRoute] Guid id,
        [FromBody] UpdateTagRequest request
    )
    {
        UpdateTagCommand command = this.mapper.Map<UpdateTagCommand>((id, request));
        ErrorOr<TagResult> updateTagResult = await this.mediator.Send(command);

        return updateTagResult.Match(
            updateTagResult => this.Ok(this.mapper.Map<TagResponse>(updateTagResult)),
            errors => this.Problem(errors)
        );
    }

    [ProducesResponseType(typeof(TagResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTag([FromRoute] Guid id)
    {
        ErrorOr<DeleteTagResult> deleteTagResult = await this.mediator.Send(
            new DeleteTagCommand(id)
        );

        return deleteTagResult.Match(_ => this.NoContent(), errors => this.Problem(errors));
    }
}
