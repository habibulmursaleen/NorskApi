using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Discussions.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Discussions.Commands.UpdateDiscussion;

public class UpdateDiscussionHandler
    : IRequestHandler<UpdateDiscussionCommand, ErrorOr<DiscussionResult>>
{
    private readonly IDiscussionRepository discussionRepository;

    public UpdateDiscussionHandler(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionResult>> Handle(
        UpdateDiscussionCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = DiscussionId.Create(command.Id);
        var essayId = EssayId.Create(command.EssayId);
        Discussion? discussion = await discussionRepository.GetById(essayId, id, cancellationToken);

        if (discussion is null)
        {
            return Errors.DiscussionErrors.DiscussionNotFound(command.Id, command.EssayId);
        }

        discussion.Update(
            essayId,
            command.Title,
            command.DiscussionEssays,
            command.Note,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.discussionRepository.Update(discussion, cancellationToken);

        return new DiscussionResult(
            discussion.Id.Value,
            discussion.EssayId,
            discussion.Title,
            discussion.DiscussionEssays,
            discussion.Note,
            discussion.IsCompleted,
            discussion.DifficultyLevel,
            discussion.CreatedDateTime,
            discussion.UpdatedDateTime
        );
    }
}
