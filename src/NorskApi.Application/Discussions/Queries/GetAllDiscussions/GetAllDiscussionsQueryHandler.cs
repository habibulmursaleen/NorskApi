using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Discussions.Models;
using NorskApi.Application.Discussions.Queries.GetAllDiscussions;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Discussions.Queries.GetAllDiscussions;

public class GetAllDiscussionsQueryHandler : IRequestHandler<GetAllDiscussionsQuery, ErrorOr<List<DiscussionResult>>>
{
    private readonly IDiscussionRepository discussionRepository;

    public GetAllDiscussionsQueryHandler(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<List<DiscussionResult>>> Handle(GetAllDiscussionsQuery query, CancellationToken cancellationToken)
    {
        List<Discussion> discussions = [];
        if (query.EssayId == Guid.Empty)
        {
            discussions = await this.discussionRepository.GetAll(cancellationToken);
        }
        else
        {
            var essayId = EssayId.Create(query.EssayId);
            discussions = await this.discussionRepository.GetAllByEssayId(essayId, cancellationToken);
        }

        List<DiscussionResult> discussionsResults = discussions
            .Select(discussions => new DiscussionResult(
                discussions.Id.Value,
                discussions.EssayId,
                discussions.Title,
                discussions.DiscussionEssays,
                discussions.Note,
                discussions.IsCompleted,
                discussions.DifficultyLevel,
                discussions.CreatedDateTime,
                discussions.UpdatedDateTime
            ))
            .ToList();

        return discussionsResults;
    }
}
