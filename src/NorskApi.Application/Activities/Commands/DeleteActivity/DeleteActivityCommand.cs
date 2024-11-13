namespace NorskApi.Application.Activities.Commands.DeleteActivity;

using ErrorOr;
using MediatR;

public record DeleteActivityCommand(Guid Id) : IRequest<ErrorOr<DeleteActivityResult>>;
