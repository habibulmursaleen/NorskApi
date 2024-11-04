namespace NorskApi.Application.Dictations.Commands.DeleteDictation;

using ErrorOr;
using MediatR;

public record DeleteDictationCommand(Guid Id) : IRequest<ErrorOr<DeleteDictationResult>>;
