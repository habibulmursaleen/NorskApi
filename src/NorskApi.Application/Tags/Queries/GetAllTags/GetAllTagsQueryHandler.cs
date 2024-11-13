using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.TagAggregate;

namespace NorskApi.Application.Tags.Queries.GetAllTags;

public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, ErrorOr<List<TagResult>>>
{
    private readonly ITagRepository tagRepository;

    public GetAllTagsQueryHandler(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public async Task<ErrorOr<List<TagResult>>> Handle(
        GetAllTagsQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Tag> tags = new List<Tag>();
        TagsQueryParamsFilters? filters = query.Filters;
        var tag = await this.tagRepository.GetAll(filters, cancellationToken);

        var tagResults = tag.Select(tag => new TagResult(
                tag.Id.Value,
                tag.Label,
                tag.Color,
                tag.TagType,
                tag.CreatedDateTime,
                tag.UpdatedDateTime
            ))
            .ToList();

        return tagResults;
    }
}
