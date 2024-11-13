using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Application.Tags.Commands.UpdateTag;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, ErrorOr<TagResult>>
{
    private readonly ITagRepository tagRepository;

    public UpdateTagHandler(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public async Task<ErrorOr<TagResult>> Handle(
        UpdateTagCommand command,
        CancellationToken cancellationToken
    )
    {
        var tagId = TagId.Create(command.Id);
        Tag? tag = await tagRepository.GetById(tagId, cancellationToken);

        if (tag is null)
        {
            return Errors.TagErrors.TagNotFound(command.Id);
        }

        tag.Update(command.Label, command.Color, command.TagType);

        await this.tagRepository.Update(tag, cancellationToken);

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
