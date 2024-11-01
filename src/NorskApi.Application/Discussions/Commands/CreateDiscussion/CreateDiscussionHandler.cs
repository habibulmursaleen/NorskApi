namespace NorskApi.Application.Discussions.Commands.CreateDiscussion;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Discussions.Models;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.EssayAggregate.ValueObjects;

public class CreateDiscussionHandler : IRequestHandler<CreateDiscussionCommand, ErrorOr<DiscussionResult>>
{
    private readonly IDiscussionRepository discussionRepository;

    public CreateDiscussionHandler(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionResult>> Handle(CreateDiscussionCommand command, CancellationToken cancellationToken)
    {
        var essayId = EssayId.Create(command.EssayId);
        Discussion discussion = Discussion.Create(
            essayId,
            command.Title,
            command.DiscussionEssays,
            command.Note,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.discussionRepository.Add(discussion, cancellationToken);

        return new DiscussionResult(
            discussion.Id.Value,
            discussion.EssayId ?? Guid.Empty,
            discussion.Title,
            discussion.DiscussionEssays,
            discussion.Note ?? string.Empty,
            discussion.IsCompleted,
            discussion.DifficultyLevel,
            discussion.CreatedDateTime,
            discussion.UpdatedDateTime
        );
    }
}