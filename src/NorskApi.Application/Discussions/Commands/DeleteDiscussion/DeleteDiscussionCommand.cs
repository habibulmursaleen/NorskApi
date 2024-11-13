namespace NorskApi.Application.Discussions.Commands.DeleteDiscussion;

using ErrorOr;
using MediatR;

public record DeleteDiscussionCommand(Guid Id) : IRequest<ErrorOr<DeleteDiscussionResult>>;
