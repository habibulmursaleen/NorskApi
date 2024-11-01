using ErrorOr;
using MediatR;
using NorskApi.Application.Discussions.Models;

namespace NorskApi.Application.Discussions.Queries.GetAllDiscussions;

public record GetAllDiscussionsQuery(Guid EssayId) : IRequest<ErrorOr<List<DiscussionResult>>>;
