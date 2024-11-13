namespace NorskApi.Application.Tags.Commands.DeleteTag;

using ErrorOr;
using MediatR;

public record DeleteTagCommand(Guid Id) : IRequest<ErrorOr<DeleteTagResult>>;
