using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Application.Tags.Queries.GetTagById;

public record GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, ErrorOr<TagResult>>
{
    private readonly ITagRepository tagRepository;

    public GetTagByIdQueryHandler(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public async Task<ErrorOr<TagResult>> Handle(
        GetTagByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TagId from the Guid
        TagId tagId = TagId.Create(query.Id);
        Tag? tag = await tagRepository.GetById(tagId, cancellationToken);

        if (tag is null)
        {
            return Errors.TagErrors.TagNotFound(query.Id);
        }

        return new TagResult(
            tag.Id.Value,
            tag.Label,
            tag.Color,
            tag.TagType,
            tag.CreatedDateTime,
            tag.UpdatedDateTime
        );
    }
}
