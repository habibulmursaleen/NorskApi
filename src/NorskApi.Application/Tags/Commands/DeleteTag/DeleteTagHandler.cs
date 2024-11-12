namespace NorskApi.Application.Tags.Commands.DeleteTag;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, ErrorOr<DeleteTagResult>>
{
    private readonly ITagRepository tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public async Task<ErrorOr<DeleteTagResult>> Handle(
        DeleteTagCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TagId from the Guid
        TagId tagId = TagId.Create(command.Id);

        Tag? tag = await tagRepository.GetById(tagId, cancellationToken);

        if (tag is null)
        {
            return Errors.TagErrors.TagNotFound(command.Id);
        }

        await tagRepository.Delete(tag, cancellationToken);

        return new DeleteTagResult(tag.Id.Value);
    }
}
