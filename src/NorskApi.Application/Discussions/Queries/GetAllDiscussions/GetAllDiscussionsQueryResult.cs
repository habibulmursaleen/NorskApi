using NorskApi.Application.Discussions.Models;

namespace NorskApi.Application.Discussions.Queries.GetAllDiscussions;

public record GetAllDiscussionQueryResult(List<DiscussionResult> Discussions);