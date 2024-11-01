using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Discussions.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Discussions.Queries.GetDiscussionById;

public record GetDiscussionByIdQueryHandler
    : IRequestHandler<GetDiscussionByIdQuery, ErrorOr<DiscussionResult>>
{
    private readonly IDiscussionRepository discussionRepository;

    public GetDiscussionByIdQueryHandler(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionResult>> Handle(
        GetDiscussionByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a DiscussionId from the Guid
        EssayId essayId = EssayId.Create(query.EssayId);
        DiscussionId discussionId = DiscussionId.Create(query.Id);
        Discussion? discussion = await discussionRepository.GetById(
            essayId,
            discussionId,
            cancellationToken
        );

        if (discussion is null)
        {
            return Errors.DiscussionErrors.DiscussionNotFound(query.Id, query.EssayId);
        }

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
