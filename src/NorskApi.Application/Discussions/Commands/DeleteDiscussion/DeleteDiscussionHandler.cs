namespace NorskApi.Application.Discussions.Commands.DeleteDiscussion;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

public class DeleteDiscussionHandler
    : IRequestHandler<DeleteDiscussionCommand, ErrorOr<DeleteDiscussionResult>>
{
    private readonly IDiscussionRepository discussionRepository;

    public DeleteDiscussionHandler(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DeleteDiscussionResult>> Handle(
        DeleteDiscussionCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a EssayId and DiscussionId from the Guid
        EssayId essayId = EssayId.Create(command.EssayId);
        DiscussionId discussionId = DiscussionId.Create(command.Id);

        Discussion? localExpression = await discussionRepository.GetById(
            essayId,
            discussionId,
            cancellationToken
        );

        if (localExpression is null)
        {
            return Errors.DiscussionErrors.DiscussionNotFound(command.Id, command.EssayId);
        }

        await discussionRepository.Delete(localExpression, cancellationToken);

        return new DeleteDiscussionResult(localExpression.Id.Value);
    }
}
