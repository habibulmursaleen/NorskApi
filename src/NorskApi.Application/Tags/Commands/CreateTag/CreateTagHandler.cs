namespace NorskApi.Application.Tags.Commands.CreateTag;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.TagAggregate;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, ErrorOr<TagResult>>
{
    private readonly ITagRepository tagRepository;

    public CreateTagHandler(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public async Task<ErrorOr<TagResult>> Handle(
        CreateTagCommand command,
        CancellationToken cancellationToken
    )
    {
        Tag tag = Tag.Create(command.Label, command.Color, command.TagType);

        await this.tagRepository.Add(tag, cancellationToken);

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
